using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    public static Player instance = null;
    public int day;
    public int maxAp;
    public int ap;
    public bool overTime;
    public int buildCost;
    public int scavengCost;
    public List<Part> inventory;

    public Quest currentQuest = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject.transform);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void toString()
    {
        Debug.Log("Day: " + day);
        Debug.Log("Max AP: " + maxAp);
        Debug.Log("AP: " + ap);
        Debug.Log("Overtime: " + overTime);
        Debug.Log("Build Cost: " + buildCost);
        Debug.Log("Scaveng Cost: " + scavengCost);
    }

}
