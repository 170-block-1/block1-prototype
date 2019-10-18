using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCotroller : MonoBehaviour
{
    public PlayerUI player;
    public Text dayText;
    public Text apText;
    private bool overTimeFlag = false;
    void Start()
    {
        player.day = 1;
        player.maxAp = 5;
        player.ap = player.maxAp;
        player.maxOverTime = 2;
        player.overTime = player.maxOverTime;
        updatePanel();
    }
    public void BuildButton() 
    {
        if(player.overTime >= 2) 
        {
            if(player.ap > 0) 
            {
                if(overTimeFlag == false)
                {
                    --player.ap;
                }
                else 
                {
                    player.ap -= 2;
                }
            }
            else 
            {
                --player.overTime;
            }
        }
        updatePanel();
    }
    public void SleepButton()
    {
        if(player.overTime < 2) {
            overTimeFlag = true;
        }
        ++player.day;
        player.ap = player.maxAp;
        player.overTime = player.maxOverTime;
        updatePanel();
    }
    public void ScavengButton() 
    {
        if(player.overTime >= 2) 
        {
            if(player.ap > 0) 
            {
                player.ap -= 2;
            }
            else 
            {
                player.overTime -= 2;
            }
        }
        updatePanel();
    }
    public void TestButton()
    {

    }
    public void updatePanel() {
        dayText.text = "Day: " + player.day;
        if(player.ap >= 0) 
        {
            apText.text = "AP: " + player.ap;
        }
        else
        {
            apText.text = "AP: Over Time";
        }
    }
}
