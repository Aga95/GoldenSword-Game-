using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuListner : MonoBehaviour {
    public GameObject escManuPanel, saveGameToast;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escManuPanel.SetActive(true);
            Time.timeScale = 0;
        }
	}
    public void closePanel()
    {
        escManuPanel.SetActive(false);
        Time.timeScale = 1;
        saveGameToast.GetComponent<Text>().text = "";
    }
    public void loadMainHub()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main_Hub");
    }
    public void saveGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("currentScene", currentScene.name);
        saveGameToast.GetComponent<Text>().text = "Game saved";
    }
    public void saveAndQuitGame()
    {
        saveGame();
        SceneManager.LoadScene("main_Menu");
    }
    public void reloadCurrentLevel()
    {
        saveGame();
        string currentScene = PlayerPrefs.GetString("currentScene");
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }
    public void deadReturnToMainHub()
    {
        saveGame();
        string currentScene = PlayerPrefs.GetString("currentScene");
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }
    public void returnToHUB()
    {
        saveGame();
        SceneManager.LoadScene("main_Hub");
        Time.timeScale = 1;

    }
}
