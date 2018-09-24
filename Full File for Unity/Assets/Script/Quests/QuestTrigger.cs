using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{ 
    public class QuestTrigger : MonoBehaviour {

        private QuestManager theQM;

        public int questNumber;

        public bool startQuest;
        public bool endQuest;

	    // Use this for initialization
	    void Start () {
            theQM = FindObjectOfType<QuestManager>();
            string currentQuest = "quest" + questNumber;
            int questCounter = PlayerPrefs.GetInt(currentQuest);
            print(questCounter);
        }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            { 
                if (!theQM.questCompleted[questNumber])
                {
                    if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                    {
                        theQM.quests[questNumber].gameObject.SetActive(true);
                        theQM.quests[questNumber].StartQuest();
                        string currentQuest = "quest" + questNumber;
                        int questCounter = PlayerPrefs.GetInt("questCounter");
                        PlayerPrefs.SetInt("questCounter", questCounter + 1);
                        PlayerPrefs.SetInt(currentQuest, 1);
                        print(questCounter + " Quests");
                        print(currentQuest + " Started");
                    }

                    if (endQuest)
                    {
                        string currentQuest = "quest" + questNumber;
                        theQM.quests[questNumber].EndQuest();
                        PlayerPrefs.SetInt(currentQuest, 2);
                        print(currentQuest + "Finished");
                    }
                }
            }
        }

    }
}