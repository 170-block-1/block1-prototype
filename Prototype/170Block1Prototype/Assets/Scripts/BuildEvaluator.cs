using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildEvaluator : MonoBehaviour
{
    public void EvaluateBuild(List<Part> parts)
    {
        switch (Player.instance.currentQuest.name)
        {
            case "First Quest":
                break;
            case "Second Quest":
                break;
        }
    }

    //private bool EvaluateFirstQuest(List<Part> parts, out int bonus)
    //{ 
    //    // sucess: have a tool (failure otherwise)
    //    // having more than one tool gives a bonus
    //    // 
    //}

}
