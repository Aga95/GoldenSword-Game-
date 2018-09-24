using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpTutorial : MonoBehaviour {

    public string toastMessage;
    public GameObject toastPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            toastPanel.gameObject.SetActive(true);
            toastPanel.GetComponentInChildren<Text>().text = toastMessage;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            toastPanel.gameObject.SetActive(false);
        }
    }


}
