using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;

    public DialogueManager theDm;
    public string itemCollected;
    public string enemyKilled;
  

	// Use this for initialization
	void Start () {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
       
	}

    public void ShowQuestText(string textQuest){
        theDm.dLines = new string[1];
        theDm.dLines[0] = textQuest;

        theDm.currentLine = 0;
        theDm.ShowDialogue();
    }
}
