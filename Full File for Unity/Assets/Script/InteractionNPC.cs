using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{ 

    public class InteractionNPC : MonoBehaviour
    {

        public GameObject dialogueBox;
        public Text dialogueText;

        public bool dialogActive;

        public string[] dialogLines;
        public int currentLine;

        private Movement thePlayer;

        void Start()
        {
            thePlayer = FindObjectOfType<Movement>();
        }

        void Update()
        {
            if(dialogActive && Input.GetKeyUp(KeyCode.F))
            {
                currentLine++;
            }

            if(currentLine >= dialogLines.Length)
            {
                dialogueBox.SetActive(false);
                dialogActive = false;

                currentLine = 0;
                thePlayer.canMove = true;
            }

            dialogueText.text = dialogLines[currentLine];

        }

        public void ShowBox(string dialogue)
        {
            dialogActive = true;
            dialogueBox.SetActive(true);
            dialogueText.text = dialogue;
        }

        public void ShowDialogue()
        {
            dialogActive = true;
            dialogueBox.SetActive(true);
            thePlayer.canMove = false;
        }

    }
}
