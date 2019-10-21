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

    private Quest currentQuest;

    private Queue<Quest> questList;
    void Start()
    {
        questList = new Queue<Quest>();

        foreach(Quest q in quests) {
            questList.Enqueue(q);
        }
        if(questList.Count > 0) {
            currentQuest = questList.Dequeue();
            updateQuestInfo();
        }
    }

    // Update is called once per frame
    public void QuestComplete() {
        if(questList.Count > 0) {
            if(currentQuest.completed){
                currentQuest = questList.Dequeue();
            }
        }
        updateQuestInfo();
    }

    private void updateQuestInfo() 
    {
        questName.text = currentQuest.name;
        discription.text = currentQuest.discription;
        fullDiscription.text = currentQuest.fullDiscription;
    }
}
