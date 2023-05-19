using UnityEngine;

public class Player : MonoBehaviour
{
    private Role role;
    private static int nextId = 1;

    public Role Role
    {
        get => role; set { role = value; }
    }

    public int Id { get; private set; }

    private void Awake()
    {
        Id = GenerateId();
    }

    private static int GenerateId()
    {
        int id = nextId;
        nextId++;
        return id;
    }
}
