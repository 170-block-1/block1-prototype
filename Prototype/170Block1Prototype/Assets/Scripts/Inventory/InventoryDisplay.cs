using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Text displayText;

    // also display description
    public void displayInv() {
        displayText.text = "Inventory:";
        foreach (var item in Player.instance.inventory)
        {
            Debug.Log(item.DisplayName + ": " + item.description);
            displayText.text = displayText.text + "\n" + item.DisplayName;
        } 
    }
}
