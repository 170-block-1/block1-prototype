using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]

public class QuestManger : MonoBehaviour
{
    // Start is called before the first frame update
    public static QuestManger instance = null;
    public Quest[] quests;

    public Text questName;

    public Text discription;

    public Text fullDiscription;

    private Queue<Quest> questList;
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject.transform);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("DEBUG");

        questList = new Queue<Quest>();

        foreach(Quest q in quests)
        {
            questList.Enqueue(q);
        }
    }

    void Start() 
    {
        if(questList.Count > 0) 
        {
            Player.instance.currentQuest = questList.Dequeue();
            updateQuestInfo();
        }
    }

    // Update is called once per frame
    public void QuestComplete() {
        if(questList.Count > 0) {
            if(Player.instance.currentQuest.completed){
                Player.instance.currentQuest = questList.Dequeue();
            }
        }
        updateQuestInfo();
    }

    private void updateQuestInfo() 
    {
        questName.text = Player.instance.currentQuest.name;
        discription.text = Player.instance.currentQuest.discription;
        fullDiscription.text = Player.instance.currentQuest.fullDiscription;
    }
}
