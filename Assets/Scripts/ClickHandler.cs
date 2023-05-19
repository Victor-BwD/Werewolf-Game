using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private GameManager gameManager;
    private DayManager dayManager;
    private Player player;

    private void Start()
    {
        dayManager = FindObjectOfType<DayManager>();
        gameManager = FindObjectOfType<GameManager>();
        player = GetComponent<Player>();

        TurnManager.WerewolfTurn = true;
    }

    private void OnMouseDown()
    {
        if (player != null)
        {
            if (!gameManager.AreWerewolvesAlive())
            {
                HandleVillagersWin();
            }
            else if (!gameManager.AreVillagersAlive())
            {
                HandleWerewolvesWin();
            }
            else if (TurnManager.WerewolfTurn)
            {
                HandleWerewolfTurn();
            }
            else if (TurnManager.DetectiveTurn)
            {
                HandleDetectiveTurn();
            }
            else if (TurnManager.PeopleTurn)
            {
                HandlePeopleTurn();
            }
        }
    }

    private void HandleVillagersWin()
    {
        gameManager.VillageScreenWin.SetActive(true);

        foreach (var player in gameManager.players)
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void HandleWerewolvesWin()
    {
        gameManager.WerewolfsScreenWin.SetActive(true);

        foreach (var player in gameManager.players)
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void HandleWerewolfTurn()
    {
        Debug.Log("Ação do lobisomem para o jogador: " + player.name);
        Werewolf.Kill(player, gameManager.HelpText, gameManager.players);

        TurnManager.DetectiveTurn = true;
        TurnManager.WerewolfTurn = false;
        dayManager.ChangeToDetectiveText();
    }

    private void HandleDetectiveTurn()
    {
        Debug.Log("Ação do detetive para o jogador: " + player.name);
        Detective.Investigate(player, gameManager.HelpText);
        TurnManager.DetectiveTurn = false;
        TurnManager.PeopleTurn = true;
        dayManager.StartDay();
    }

    private void HandlePeopleTurn()
    {
        Debug.Log("Ação dos villagers: " + player.name);
        Villager.KillWerewolf(player, gameManager.HelpText, gameManager.players);
        TurnManager.WerewolfTurn = true;
        TurnManager.PeopleTurn = false;
        dayManager.StartNight();
    }
}
