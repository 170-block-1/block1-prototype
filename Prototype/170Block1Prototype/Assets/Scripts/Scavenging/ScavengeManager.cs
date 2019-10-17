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
    public Text displayText;
    public Text energyText;
    public Text inventoryText;
    private Scavenger scav;
    private int triesLeft;
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
        displayText.text = "Click the button to scavenge";
        continueButton.gameObject.SetActive(false);
        DisplayInventory();
    }
    public void StartScavenge()
    {
        var item = scav.Scavenge(lootTable);
        if (item.partClass == Part.Class.None)
        {
            displayText.text = "You found: nothing. Better luck next time!";
        }
        else
        {
            TempPlayer.instance.inventory.Add(item);
            DisplayInventory();
            displayText.text = "You found: " + item.DisplayName + " x1";
        }
        if (--TriesLeft <= 0)
        {
            scavengeButton.interactable = false;
            continueButton.gameObject.SetActive(true);         
            displayText.text += "\n You are out of energy!";
        }
    }

    private void DisplayInventory()
    {
        string invStr = "Inventory:\n";
        foreach (var item in TempPlayer.instance.inventory)
            invStr += item.DisplayName + ", ";     
        inventoryText.text = invStr.TrimEnd(' ', ',');
    }
}
