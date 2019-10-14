using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scavenger))]
public class ScavengeManager : MonoBehaviour
{
    public LootTable lootTable;
    private Scavenger scav;

    private void Awake()
    {
        scav = GetComponent<Scavenger>();
    }
    public void StartScavenge()
    {
        Debug.Log("The player scavenged: " + scav.Scavenge(lootTable).name);
    }
}
