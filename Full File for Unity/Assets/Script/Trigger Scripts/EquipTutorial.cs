using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipTutorial : MonoBehaviour
{

    public string toastMessage;
    public GameObject toastPanel;
    public GameObject key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (key.activeInHierarchy)
        {
            toastPanel.gameObject.SetActive(true);
            toastPanel.GetComponentInChildren<Text>().text = toastMessage;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        toastPanel.gameObject.SetActive(false);
        Destroy(this);
    }


}
