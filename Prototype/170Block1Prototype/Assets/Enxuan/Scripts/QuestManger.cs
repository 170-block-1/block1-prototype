using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManger : MonoBehaviour
{
    // Start is called before the first frame update
    public Quest[] quests;

    public Text questName;

    public Text discription;

    public Text fullDiscription;
    void Start()
    {
        if(quests.Length > 0) {
            questName.text = quests[0].name;
            discription.text = quests[0].discription;
            fullDiscription.text = quests[0].fullDiscription;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
