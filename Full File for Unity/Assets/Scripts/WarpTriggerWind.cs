using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarpTriggerWind : MonoBehaviour {

    
    private SpriteRenderer spriteRender;
    public GameObject sword;
    private SpriteRenderer swd;
    public AudioClip audioClip;
    public AudioSource aSource;

    private void Start()
    {
        swd = sword.GetComponent<SpriteRenderer>();
    }

    public string sceneName, toastMessage, needMessage;
    public GameObject toastPanel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (swd.sprite.name == "Gold")
            {
                toastPanel.SetActive(true);
                toastPanel.GetComponentInChildren<Text>().text = toastMessage;
                if (Input.GetKey(KeyCode.F))
                {
                    aSource.PlayOneShot(audioClip);
                    print("going to level: " + sceneName);
                    SceneManager.LoadScene(sceneName);
                }
            }
            else
            {
                toastPanel.SetActive(true);
                toastPanel.GetComponentInChildren<Text>().text = needMessage;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        toastPanel.SetActive(false);
    }
}
