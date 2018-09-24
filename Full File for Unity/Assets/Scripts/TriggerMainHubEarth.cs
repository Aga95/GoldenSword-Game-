using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerMainHubEarth : MonoBehaviour {

    public string levelToLoad;
    public int xpValue;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            SceneManager.LoadScene(levelToLoad);
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Movement>().gainXP(xpValue);
        }
    }
}
