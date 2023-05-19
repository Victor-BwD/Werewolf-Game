using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Villager : Role
{
    public Villager()
    {
        Name = "Villager";
        Description = string.Empty;
        IsAlive = true;
    }

    public static void KillWerewolf(Player player, TMP_Text text, List<Player> players)
    {
        if(ReferenceEquals(player, null)) return;

        if(player.Role.Name == "Werewolf")
        {
            text.text = "Você matou um werewolf";
            Destroy(player.gameObject);
            players.Remove(player);
        }
        else
        {
            text.text = "You killed a villager";
            Destroy(player.gameObject);
            players.Remove(player);
        }
    }
}
