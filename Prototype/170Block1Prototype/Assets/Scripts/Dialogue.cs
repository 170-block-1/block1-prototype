using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Decalre text component for dialogue
    Text dialogue;
    private string[] text;

    // Start is called before the first frame update
    void Start()
    {
        // Get the canvas's current text component
        dialogue = GetComponent<Text>();

        // Initialize variables
        text = new string[]{"1", "2", "3", "4", "5"};

        // Move to update later
        // Greeting -> Request
        // Update the current text
        dialogue.text = "testing: " + text[Random.Range(0, text.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        // Click to cycle through diaglue

    }
}
