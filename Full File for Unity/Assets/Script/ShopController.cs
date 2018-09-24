using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

    public GameObject shopPanel;
    public AudioClip Smith, Bartender;
    public bool isSmith;
    public AudioSource aSource;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.B) )
        {
            if (isSmith)
            {
                aSource.PlayOneShot(Smith);
            }
            else
            {
                aSource.PlayOneShot(Bartender);
            }
            OpenShop();
        }
    }


    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
