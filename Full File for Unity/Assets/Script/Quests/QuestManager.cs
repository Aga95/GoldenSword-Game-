using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{ 
    public class QuestManager : MonoBehaviour {

        public QuestObject[] quests;
        public bool[] questCompleted;
        public int questNumber;

        public InteractionNPC theDM;

        public string itemCollected;

        public string enemyKilled;

	    // Use this for initialization
	    void Start () {
            questCompleted = new bool[quests.Length];
            checkForQuestStatus();
	    }

        public void checkForQuestStatus()
        {
            int questCounter = PlayerPrefs.GetInt("questCounter");
            for (var i = 0; i < questCounter; i++)
            {
                string currentQuest = "quest" + i;
                print("Checking quest: " + i);
                if (PlayerPrefs.GetInt(currentQuest) == 2)
                {
                    print("Ending quest: " + i);
                    quests[i].EndQuestNoText();

                }
                else if (PlayerPrefs.GetInt(currentQuest) == 1)
                {
                    print("Starting quest: " + i);
                    quests[i].StartQuestNoText();

                }
            }
        }

        // Update is called once per frame
        void Update () {
		
	    }

        public void ShowQuestText(string questText, bool show)
        {
            if (show) { 
            theDM.dialogLines = new string[1];
            theDM.dialogLines[0] = questText;

            theDM.currentLine = 0;
            theDM.ShowDialogue();
            }
        }
    }
}