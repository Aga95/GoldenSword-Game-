using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{ 
    public class TriggerLoadNewArea : MonoBehaviour {

        public string levelToLoad;

        public string exitPoint;

        private Movement thePlayer;

        void Start()
        {
            thePlayer = FindObjectOfType<Movement>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                SceneManager.LoadScene(levelToLoad);
                thePlayer.startPoint = exitPoint;
            }
        }
    }
}