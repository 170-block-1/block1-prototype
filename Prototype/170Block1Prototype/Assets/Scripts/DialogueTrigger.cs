using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Calls the function to start the customer dialogue
 */
public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
