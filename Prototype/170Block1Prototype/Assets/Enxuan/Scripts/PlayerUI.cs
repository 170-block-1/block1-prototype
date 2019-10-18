using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerUI", menuName = "PlayerUI")]
public class PlayerUI : ScriptableObject
{
    public int day;
    public int maxAp;
    public int ap;
    public int overTime;
    public int maxOverTime;
}
