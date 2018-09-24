using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{ 
    public class QuestObject : MonoBehaviour {

        public int questNumber;

        public QuestManager theQM;

        public string startText;
        public string endText;

        public bool isItemQuest;
        public string targetItem;
        public bool started;

        public bool isEnemyQuest;
        public string targetEnemy;
        public int enemiesToKill;
        private int enemyKillCount;

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {

            if (isItemQuest)
            {
                if(theQM.itemCollected == targetItem)
                {
                    theQM.itemCollected = null;

                    EndQuest();
                }
            }

            if (isEnemyQuest)
            {
                if(theQM.enemyKilled == targetEnemy)
                {
                    theQM.enemyKilled = null;

                    enemyKillCount++;
                }

                if(enemyKillCount >= enemiesToKill)
                {
                    EndQuest();
                }
            }

	    }

        public void StartQuest()
        {
            theQM.ShowQuestText(startText, true);
        }
        public void StartQuestNoText()
        {
            theQM.ShowQuestText(startText, false);
        }

        public void EndQuest()
        {
            theQM.ShowQuestText(endText,true);
            theQM.questCompleted[questNumber] = true;
            gameObject.SetActive(false);
        }
        public void EndQuestNoText()
        {
            theQM.ShowQuestText(endText,false);
            theQM.questCompleted[questNumber] = true;
            gameObject.SetActive(false);
        }

    }
}
