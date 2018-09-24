using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    
    public class dialogNPC : MonoBehaviour {

        public string dialogue;
        private InteractionNPC dialogueMan;
        private bool talkedTo;

        public string[] dialogueLines;

	    // Use this for initialization
	    void Start () {
            dialogueMan = FindObjectOfType<InteractionNPC>();
            talkedTo = false;
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.name == "Player")
            {
                if (Input.GetKeyUp(KeyCode.F) || !talkedTo)
                {

                    if (!dialogueMan.dialogActive)
                    {
                        dialogueMan.dialogLines = dialogueLines;
                        dialogueMan.currentLine = 0;
                        dialogueMan.ShowDialogue();
                        talkedTo = true;
                    }
                }
            }
        }

    }
}
