using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10];

	public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        // Find the first open slot in the inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                // Do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        //Inventory full
        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item Not Added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i] == item)
            {
                //We found the item
                return true;
            }
        }
        //Item not found
        return false;
    }

    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] != null)
            {
                if(inventory[i].GetComponent<InteractionObject>().itemType == itemType)
                {
                    //We found an item of the type we were looking for
                    return inventory[i];
                }
            }
        }
        //Item of type not found
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i] == item)
                {
                    //We found the item - Remove it 
                    inventory[i] = null;
                    Debug.Log(item.name + " was removed from inventory");
                    break;
                }
            }
        }
    }

}
