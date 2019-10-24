using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Scavenger))]
public class ScavengeManager : MonoBehaviour
{
    public int maxTries;
    public LootTable lootTable;
    [Header("Control Button References")]
    public Button scavengeButton;
    public Button continueButton;
    [Header("Display Text References")]
    public Text energyText;
    public Text inventoryText;
    public DialogueManager dialogueManager;
    private Scavenger scav;
    private int triesLeft;
    private static readonly string invTitle = "Current Haul:\n";
    private int TriesLeft
    {
        get => triesLeft;
        set
        {
            triesLeft = value;
            energyText.text = "Energy: " + triesLeft;
        }
    }

    private void Awake()
    {
        scav = GetComponent<Scavenger>();
        TriesLeft = maxTries;
        continueButton.gameObject.SetActive(false);
        inventoryText.text = invTitle;
    }
    public void StartScavenge()
    {
        var sentences = new List<string>();
        var item = scav.Scavenge(lootTable);
        if (item.partClass == Part.Class.None)
        {
            sentences.Add("You found: nothing. Better luck next time!");
        }
        else
        {
            Player.instance.inventory.Add(item);
            inventoryText.text += inventoryText.text == invTitle ? item.DisplayName : ", " + item.DisplayName; 
            sentences.Add("You found: " + item.DisplayName + " x1");
        }
        if (--TriesLeft <= 0)
        {
            scavengeButton.interactable = false;
            continueButton.gameObject.SetActive(true);         
            sentences.Add("You are out of energy!");
        }
        dialogueManager.StartDialogue(new Dialogue() { sentences = sentences.ToArray() });
    }
}
