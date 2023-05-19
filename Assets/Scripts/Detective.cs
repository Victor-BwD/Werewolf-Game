using TMPro;
using UnityEngine;

public class Detective : Role
{
    public Detective()
    {
        Name = "Detective";
        Description = string.Empty;
        IsAlive = true;
    }

    public static void Investigate(Player player, TMP_Text text)
    {
        if(player.Role is Werewolf)
        {
            text.text = "Voc� encontrou um werewolf!";
            return;
        }
        else
        {
            text.text = "O jogador � uma pessoa normal.";
            return;
        }
    }
}
