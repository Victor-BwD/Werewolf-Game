using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsAlive { get; set; }
    public int NumberOfVotes { get; set; }
}
