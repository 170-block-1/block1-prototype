using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Manages the customer dialogue by having a queue store all sentences.
 */
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Dialogue dialogue;
    public bool startOnStart;

    private Queue<string> sentences = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        if(startOnStart)
            StartDialogue(dialogue);
        else
            animator.SetBool("IsOpen", false);
    }

    // Starts the dialogue and displays next sentence
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting Convo");
   
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Displays next sentences until all have been displayed
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        // Wait for all animations to finish before starting next one
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        Debug.Log(sentence);
    }

    // Animates the sentences by displaying one letter at a time
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    // End dialogue by moving the dialogue box out of the way
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of Convo");
    }

}
