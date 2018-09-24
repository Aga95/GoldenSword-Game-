using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TellYouWhatToDo : MonoBehaviour {

    public string toastMessage, secondMessage;
    public GameObject toastPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            toastPanel.SetActive(true);
            toastPanel.GetComponentInChildren<Text>().text = toastMessage;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        toastPanel.SetActive(false);
    }

}
