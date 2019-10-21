using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCotroller : MonoBehaviour
{
    public Text dayText;
    public Text apText;
    void Start()
    {
        updatePanel();
    }
    public void BuildButton()
    {
        if(!Player.instance.overTime && Player.instance.buildCost <= Player.instance.maxAp)
        {
            if(Player.instance.ap >= Player.instance.buildCost)
            {
                Player.instance.ap -= Player.instance.buildCost;
            }
            else
            {
                Player.instance.overTime = true;
            }
        }
        updatePanel();
    }
    public void SleepButton()
    {
        if(Player.instance.overTime) {
            ++Player.instance.buildCost;
            ++Player.instance.scavengCost;
        }
        else
        {
            Player.instance.buildCost = 1;
            Player.instance.scavengCost = 2;
        }
        ++Player.instance.day;
        Player.instance.ap = Player.instance.maxAp;
        Player.instance.overTime = false;
        updatePanel();
    }
    public void ScavengButton()
    {
        if(!Player.instance.overTime && Player.instance.scavengCost <= Player.instance.maxAp)
        {
            if(Player.instance.ap >= Player.instance.scavengCost)
            {
                Player.instance.ap -= Player.instance.scavengCost;
            }
            else
            {
                Player.instance.overTime = true;
            }
            updatePanel();
            SceneManager.LoadScene(1);
        }
        updatePanel();
    }
    public void TestButton()
    {

    }
    public void updatePanel() {
        dayText.text = "Day: " + Player.instance.day;
        if(!Player.instance.overTime)
        {
            apText.text = "AP: " + Player.instance.ap;
        }
        else
        {
            apText.text = "AP: Over Time";
        }
        Player.instance.toString();
    }
}
