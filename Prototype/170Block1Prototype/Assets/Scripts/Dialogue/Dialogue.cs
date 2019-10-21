using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// For creating more dialoguein unity 
public class Dialogue
{
    [TextArea(3,10)]
    public string[] sentences;
}