using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{ 
    public class PlayerInteract : MonoBehaviour {

        public GameObject currentInterObj = null;
        public InteractionObject currentInterObjScript = null;
        public InteractionNPC currentInterNPCScript = null;
        public Inventory inventory;


        void Update()
        {
            if(Input.GetButtonDown("Interact") && currentInterObj)
            {
                //Check to see if this object is to be stored in inventory
                if (currentInterObjScript.inventory)
                {
                    inventory.AddItem(currentInterObj);
                }

                //Check to see if this object can be opened
                if (currentInterObjScript.openable)
                {
                    //Check to see if the object is locked
                    if (currentInterObjScript.locked)
                    {
                        //check to see if we have the object needed to unlock
                        //Search our inventory for the item needed - if found unlock object
                        if (inventory.FindItem (currentInterObjScript.itemNeeded))
                        {
                            //We found the item needed
                            currentInterObjScript.locked = false;
                            Debug.Log(currentInterObj.name + " was unlocked");
                        }
                        else
                        {
                            Debug.Log(currentInterObj.name + " was not unlocked");
                        }
                    }
                    else
                    {
                        //Object in not locked - open the object
                        Debug.Log(currentInterObj.name + " is unlocked");
                        currentInterObjScript.Open();
                    }
                }

                //Check to see if the object talks and has a message
               /* if (currentInterNPCScript.talks)
                {
                    Debug.Log(currentInterObj.name);
                    //Tell the object to give its message
                    currentInterNPCScript.Talk();
                }*/


            }

       


            //Use a Potion
            if (Input.GetButtonDown ("Use Potion"))
            {
                //Check the inventory for a potion
                GameObject potion = inventory.FindItemByType("Health Potion");
                if(potion != null)
                {
                    //Use the potion - apply its effect

                    //Remove the potion from inventory

                }

            }

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("interObject"))
            {
                Debug.Log(other.name);
                currentInterObj = other.gameObject;
                currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
            }

           /* if(other.CompareTag("NPC"))
            {
                Debug.Log(other.name);
                currentInterObj = other.gameObject;
                currentInterObjScript = currentInterObj.GetComponent<InteractionNPC>();
            }*/
        }	

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("interObject"))
            {
                if(other.gameObject == currentInterObj)
                {
                    currentInterObj = null;
                }
            }

            if (other.CompareTag("NPC"))
            {
                if (other.gameObject == currentInterObj)
                {
                    currentInterObj = null;
                }
            }
        }

    }
}