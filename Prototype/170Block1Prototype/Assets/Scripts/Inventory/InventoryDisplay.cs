using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Text displayText;

    public void displayInv() {
        displayText.text = "Inventory:";

        foreach (var item in Player.instance.inventory)
        {
            displayText.text = displayText.text + "\n" + item.DisplayName + ": " + item.description;
            Debug.Log(item.DisplayName + ": " + item.description);
        } 
        
    }
}
