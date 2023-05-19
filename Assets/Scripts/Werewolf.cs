using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Werewolf : Role
{
    public static int numberOfVictims { get; private set; }

    public Werewolf()
    {
        Name = "Werewolf";
        Description = "A fierce creature that hunts at night.";
        IsAlive = true;
    }

    public static void Kill(Player player, TMP_Text text, List<Player> players)
    {
        if(player.Role is Werewolf)
        {
            text.text = "You can't kill a werewolf.";
            return;
        }

        if(player.Role is Villager)
        {
            text.text = "You killed a villager.";
            Destroy(player.gameObject);
            players.Remove(player);
            numberOfVictims++;
            return;
        }
        else
        {
            text.text = "You killed a detective.";
            Destroy(player.gameObject);
            numberOfVictims++;
            return;
        }
    }
}
