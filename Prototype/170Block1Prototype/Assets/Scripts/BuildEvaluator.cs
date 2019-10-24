using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildEvaluator : MonoBehaviour
{
    public BuildSystem system;
    public DialogueManager manager;

    public void EvaluateBuild()
    {
        EvaluateBuild(system.AddPart);
    }
    public void EvaluateBuild(List<Part> parts)
    {
        Dialogue d;
        int bonus;
        bool success = false;
        switch (Player.instance.currentQuest.index)
        {
            case 1:
                success = EvaluateFirstQuest(parts, out bonus, out d);
                manager.StartDialogue(d);
                break;
            case 2:
                success = EvaluateSecondQuest(parts, out bonus, out d);
                manager.StartDialogue(d);
                break;
        }
        if(success)
        {
            Player.instance.currentQuest.completed = true;
            QuestManger.instance.QuestComplete();
        }
    }

    private bool EvaluateFirstQuest(List<Part> parts, out int bonus, out Dialogue dialog)
    {
        bonus = 0;
        var sentences = new List<string>();

        // Fail if you don't have a tool
        if(!parts.Any((p) => p.partClass == Part.Class.Tool))
        {
            sentences.Add("When I said I wanted a robot that could break down wood, I didn’t think you’d try to give me... that.");
            dialog = new Dialogue() { sentences = sentences.ToArray() };
            return false;
        }

        sentences.Add("Yeah, your robot did a pretty good job of it!");
        // Bonus and mesaage for having a monitor
        if(parts.Any((p) => p.DisplayName.ToLower() == "monitor"))
        {
            ++bonus;
            sentences.Add("It made some of the cleanest cuts I’ve ever seen.");
        }
        // Bonus and mesaage for having storage
        if (parts.Any((p) => p.DisplayName.ToLower() == "storage compartment"))
        {
            ++bonus;
            sentences.Add("It was pretty helpful for holding the wood, too.");
        }
        // Bonus and mesaage for having treads
        if (parts.Any((p) => p.DisplayName.ToLower() == "rotary treads"))
        {
            ++bonus;
            sentences.Add("And it was pretty handy at carrying around the logs!");
        }
        sentences.Add("Your bonus was: " + bonus);
        sentences.Add("You got a new quest: Build-A-Nanny!");
        sentences.Add("Check your quest description for details.");
        dialog = new Dialogue() { sentences = sentences.ToArray() };
        return true;
    }

    private bool EvaluateSecondQuest(List<Part> parts, out int bonus, out Dialogue dialog)
    {
        bonus = 0;
        var sentences = new List<string>();

        int satisfaction = 0;

        #region Specific Part stuff

        // Treads bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "rotary treads"))
        {
            satisfaction += 2;
            sentences.Add("She’s sleeping soundly now, thanks to that robot.");
            sentences.Add("It worked marvelously!");            
        }
        else
        {
            sentences.Add("She seemed a bit cranky, but overall I think your robot did a good enough job.");
        }
        // Monitor bonus / penalty
        if(parts.Any((p) => p.DisplayName.ToLower() == "monitor"))
        {
            satisfaction += 1;
            sentences.Add("Your robot benefits greatly from its vision!");
        }
        else
        {
            sentences.Add("She knocked over some stuff nearby though.");
            sentences.Add("Is there any way you could have allowed the robot to keep an eye on her?");
        }

        // Compassion core bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "compassion core"))
        {
            satisfaction += 1;
        }
        else
        {
            sentences.Add("She seemed a bit distressed.");
            sentences.Add("I guess it is impossible for robots to fully replace humans in some regards.");
        }

        // Thermos bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "thermos"))
        {
            satisfaction += 1;
        }
        else
        {
            sentences.Add("It seemed like she didn’t eat much food.");
            sentences.Add("I guess it’d be hard to teach a robot to cook, huh?");
        }

        // Vital Scope bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "vital scope"))
        {
            satisfaction += 1;
        }
        else
        {
            sentences.Add("This might just be me being paranoid, but it would also take a load off my shoulders if the robot could make sure she’s alright.");
        }

        // storage core bonus / penalty
        if (parts.Any((p) => p.DisplayName.ToLower() == "storage compartment"))
        {
            satisfaction += 1;
        }
        else
        {
            sentences.Add("The robot was still doing some stuff when I got back.");
            sentences.Add("Maybe it should have some way to hold more than one or two things at a time?");
        }

        #endregion

        // Fail if you don't have a hand
        if (!parts.Any((p) => p.DisplayName.ToLower() == "hand"))
        {
            sentences.Clear();
            if (satisfaction < 4)
            {
                sentences.Add("Is this some kind of joke?");
                sentences.Add("We’re talking about a human child here, not some piece of modern art!");
            }
            else
            { 
                sentences.Add("This wouldn’t be alright for taking care of a pet rock, let alone a human child!");
                sentences.Add("The robot needs something to pick up objects with!");               
            }
            dialog = new Dialogue() { sentences = sentences.ToArray() };
            return false;
        }
        else if (satisfaction < 4)
        {
            bonus = 0;
            sentences.Clear();
            sentences.Add("I let the robot look after her for a few hours, but I didn’t like what I saw.");
            sentences.Add("I’m sorry, but I can’t pay you for this.");
            dialog = new Dialogue() { sentences = sentences.ToArray() };
            return false;
        }

        bonus = satisfaction - 4;
        sentences.Add("Your bonus was: " + bonus);
        dialog = new Dialogue() { sentences = sentences.ToArray() };
        return true;
    }

}
