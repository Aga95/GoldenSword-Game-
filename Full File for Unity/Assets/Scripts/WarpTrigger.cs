using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarpTrigger : MonoBehaviour {

    public string sceneName, toastMessage;
    public GameObject toastPanel;
    public AudioClip audioClip;
    public AudioSource aSource;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        toastPanel.SetActive(false);
    }

}
