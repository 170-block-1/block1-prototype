using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCotroller : MonoBehaviour
{
    public Text dayText;
    public Text apText;
    private bool overTimeFlag = false;

    void Start()
    {
        updatePanel();
    }
    public void BuildButton() 
    {
        if(Player.instance.overTime >= 2) 
        {
            if(Player.instance.ap > 0) 
            {
                if(overTimeFlag == false)
                {
                    --Player.instance.ap;
                }
                else 
                {
                    Player.instance.ap -= 2;
                }
            }
            else 
            {
                --Player.instance.overTime;
            }
        }
        updatePanel();
    }
    public void SleepButton()
    {
        if(Player.instance.overTime < 2) {
            overTimeFlag = true;
        }
        ++Player.instance.day;
        Player.instance.ap = Player.instance.maxAp;
        Player.instance.overTime = Player.instance.maxOverTime;
        updatePanel();
    }
    public void ScavengButton() 
    {
        if(Player.instance.overTime >= 2) 
        {
            if(Player.instance.ap > 0) 
            {
                Player.instance.ap -= 2;
            }
            else 
            {
                Player.instance.overTime -= 2;
            }
        }
        updatePanel();
    }
    public void TestButton()
    {

    }
    public void updatePanel() {
        dayText.text = "Day: " + Player.instance.day;
        if(Player.instance.ap >= 0) 
        {
            apText.text = "AP: " + Player.instance.ap;
        }
        else
        {
            apText.text = "AP: Over Time";
        }
    }
}
