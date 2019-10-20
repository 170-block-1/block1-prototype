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
    public int overTime;
    public int maxOverTime;
    public List<Part> inventory;

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

}
