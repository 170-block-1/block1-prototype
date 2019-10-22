using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildEvaluator : MonoBehaviour
{
    public DialogueManager manager;
    public void EvaluateBuild(List<Part> parts)
    {
        Dialogue d;
        int bonus;
        bool success;
        switch (Player.instance.currentQuest.name)
        {
            case "First Quest":
                success = EvaluateFirstQuest(parts, out bonus, out d);
                manager.StartDialogue(d);
                break;
            case "Second Quest":
                success = EvaluateSecondQuest(parts, out bonus, out d);
                manager.StartDialogue(d);
                break;
        }     
    }

    private bool EvaluateFirstQuest(List<Part> parts, out int bonus, out Dialogue dialog)
    {
        var sentences = new List<string>();
        // Does the part list have a tool?
        bool hasTool = parts.FirstOrDefault((p) => p.partClass == Part.Class.Tool) != null;

        // Fail if you don't have a tool
        if(!hasTool)
        {
            bonus = 0;
            sentences.Add("Your robot was a failure!");
            sentences.Add("Try adding a tool!");
            dialog = new Dialogue() { sentences = sentences.ToArray() };
            return false;
        }
  
        sentences.Add("success");
        bool hasMonitor = ;
        if(parts.FirstOrDefault((p) => p.DisplayName.ToLower() == "monitor") != null)
        {

        }
        if(parts.FirstOrDefault((p) => p.DisplayName.ToLower() == "storage") != null)
        {

        }
        bool hasTreads = parts.FirstOrDefault((p) => p.DisplayName.ToLower() == "treads");
        dialog = new Dialogue() { sentences = sentences.ToArray() };
        
        return true;

        // Success: have a tool (failure otherwise)
        // Bonus:
        // +1, monitor, storage, treads
        // having more than one tool gives a bonus

        // Success but with no bonus
        // Extra Successs messages: monitor, storage, treads
        // Failure
        
    }

    private bool EvaluateSecondQuest(List<Part> parts, out int bonus, out Dialogue dialog)
    {
        // sucess: have a tool (failure otherwise)
        // Must have a hand
        // Must have 4 or more points from this table
        // +2: Treads
        // +1: Compassion core, monitor, thermos, storage, scope
        // Any additional points above the threshold are bonus

        // Success w/ treads
        // Success w/out treads
        // Extra messages: no compassion core, no monitor, no thermos, no storage, no scope, 
        // Failure due to not having hands
        // Fail due to not having enough additional satisfaction
        // Both failure conditions
    }

}
