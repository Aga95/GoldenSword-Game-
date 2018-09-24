using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour {


    public bool inventory;          //If true this object can be stored in inventory
    public bool openable;           //If true this object can be opened
    public bool locked;             //If true the object is locked
    public bool talks;              //If true then the object can talk to the player
    private bool opened;             //if true the door has been opened.
    public string itemType;         //This will tell what type of item this object is

    public GameObject itemNeeded;   //Item needed in order to interact with this item
    public string message;          //The message this object will give the player
    public GameObject toastPanel;   //Where the message is pushed
    public GameObject doorTrigger;  //Trigger for how to open door.


    public Animator anim;

    public void DoInteraction()
    {
        //Piced up and put in inventory
        gameObject.SetActive(false);
    }

    public void Open()
    {
        if (!opened) {
            anim.SetBool("open", true);
            opened = true;
            print("Åpner ");
            toastPanel.gameObject.SetActive(true);
            toastPanel.GetComponentInChildren<Text>().text = "Door is opening";
            Destroy(doorTrigger);
            StartCoroutine(delayToast());
        }
    }

    public void Talk()
    {
        if (locked) { 
        Debug.Log(message);
        toastPanel.gameObject.SetActive(true);
        toastPanel.GetComponentInChildren<Text>().text = message;
        StartCoroutine(delayToast());
        }
    }
    IEnumerator delayToast()
    {
        yield return new WaitForSeconds(5);
        toastPanel.gameObject.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }        
    }



}
