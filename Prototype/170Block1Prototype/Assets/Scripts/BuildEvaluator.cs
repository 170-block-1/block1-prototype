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
        bonus = 0;
        var sentences = new List<string>();

        // Fail if you don't have a tool
        if(!parts.Any((p) => p.partClass == Part.Class.Tool))
        {          
            sentences.Add("Your robot was a failure!");
            sentences.Add("Try adding a tool!");
            dialog = new Dialogue() { sentences = sentences.ToArray() };
            return false;
        }
        
        sentences.Add("success");
        // Bonus and mesaage for having a monitor
        if(parts.Any((p) => p.DisplayName.ToLower() == "monitor"))
        {
            ++bonus;
            sentences.Add("Bonus: has monitor");
        }
        // Bonus and mesaage for having storage
        if (parts.Any((p) => p.DisplayName.ToLower() == "storage compartment"))
        {
            ++bonus;
            sentences.Add("Bonus: has storage");
        }
        // Bonus and mesaage for having treads
        if (parts.Any((p) => p.DisplayName.ToLower() == "rotary treads"))
        {
            ++bonus;
            sentences.Add("Bonus: has treads");
        }
        sentences.Add("Your bonus was: " + bonus);
        dialog = new Dialogue() { sentences = sentences.ToArray() };      
        return true;        
    }

    private bool EvaluateSecondQuest(List<Part> parts, out int bonus, out Dialogue dialog)
    {
        bonus = 0;
        var sentences = new List<string>();

        // Fail if you don't have a hand
        if (!parts.Any((p) => p.DisplayName.ToLower() == "hand"))
        {
            sentences.Add("Your robot was a failure!");
            sentences.Add("Try adding something to hold objects!");
            dialog = new Dialogue() { sentences = sentences.ToArray() };
            return false;
        }

        int satisfaction = 0;

        #region Specific Part stuff

        // Treads bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "rotary treads"))
        {
            satisfaction += 2;
            sentences.Add("Your robot benefits greatly from its treads' mobility!");
        }
        else
        {
            sentences.Add("Your robot suffers greatly from its lack of mobility!");
        }
        // Monitor bonus / penalty
        if(parts.Any((p) => p.DisplayName.ToLower() == "monitor"))
        {
            satisfaction += 1;
            sentences.Add("Your robot benefits greatly from its vision!");
        }
        else
        {
            sentences.Add("Your robot suffers from its lack of vision!");
        }

        // Compassion core bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "compassion core"))
        {
            satisfaction += 1;
            sentences.Add("Your robot benefits from its compassion!");
        }
        else
        {
            sentences.Add("Your robot suffers from its lack of compassion!");
        }

        // Thermos bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "thermos"))
        {
            satisfaction += 1;
            sentences.Add("Your robot benefits from its temperature control components!");
        }
        else
        {
            sentences.Add("Your robot suffers from its lack of temperature control components!");
        }

        // Vital Scope bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "vital scope"))
        {
            satisfaction += 1;
            sentences.Add("Your robot benefits greatly from its ability to check vitals!");
        }
        else
        {
            sentences.Add("Your robot suffers from its lack of ability to check vitals!");
        }

        // storage core bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "storage compartment"))
        {
            satisfaction += 1;
            sentences.Add("Your robot benefits from its expanded storage!");
        }
        else
        {
            sentences.Add("Your robot suffers from its lack of storage!");
        }

        #endregion

        if (satisfaction < 4)
        {
            bonus = 0;
            sentences.Add("Your robot was a failure!");
            sentences.Add("Your satisfaction wasn't high enough!");
            dialog = new Dialogue() { sentences = sentences.ToArray() };
            return false;
        }

        bonus = satisfaction - 4;
        sentences.Add("Success!");
        sentences.Add("Your bonus was: " + bonus);
        dialog = new Dialogue() { sentences = sentences.ToArray() };
        return true;
    }

}
