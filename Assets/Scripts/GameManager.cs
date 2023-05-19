using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> tMP_Texts = new List<TMP_Text>();
    
    private List<Role> roles = new List<Role>();
    private static GameManager instance;

    public List<Player> players;
    public TMP_Text HelpText;
    public GameObject VillageScreenWin;
    public GameObject WerewolfsScreenWin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        roles.Add(new Werewolf());
        roles.Add(new Werewolf());
        roles.Add(new Villager());
        roles.Add(new Villager());
        roles.Add(new Villager());
        roles.Add(new Detective());

        roles = ShuffleList(roles);
   
        AssignRoles();
    }

    void AssignRoles()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            Role role = roles[i];
            Player player = players[i].GetComponent<Player>();
            player.Role = role;

            TMP_Text text = tMP_Texts[i];
            text.text = role.Name;
        }
    }

    List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }

    public bool AreWerewolvesAlive()
    {
        return players.Any(player => player.Role is Werewolf);
    }

    public bool AreVillagersAlive()
    {
        return players.Any(player => player.Role is Villager);
    }

    public bool AreDetectiveAlive()
    {
        return players.Any(player => player.Role is Detective);
    }

    
}
