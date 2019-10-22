using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {

    public bool completed = false;

    public string name;
    
    [TextArea(2,10)]
    public string discription;

    [TextArea(5,10)]
    public string fullDiscription;
}
