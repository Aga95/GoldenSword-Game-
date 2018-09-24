
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Defined objects for access.
    public Camera mainCamera;
    public Slider sliderMusic, sliderEffects;
    public GameObject buttonMusic, buttonEffects, playerNameInput, loadPlayerInfo;
    public bool goingMain, goingOptions, goingNewGame, goingMainFNG, goingLoadGame, goingMainLG;
    public Canvas canvas_Load, canvas_New;

    public float speed;

    // Use this for initialization
    void Awake()
    {
        goingMain = false;
        goingOptions = false;
        goingNewGame = false;
        goingMainFNG = false;
        goingLoadGame = false;
        goingMainLG = false;
        speed = 0.0f;
        Time.timeScale = 1;
    }
    void Start()
    {
        goingMain = false;
        goingOptions = false;
        goingNewGame = false;
        goingMainFNG = false;
        goingLoadGame = false;
        goingMainLG = false;
        speed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingMain)
        {
            float camera_Rotation = mainCamera.transform.eulerAngles.y;
            if (camera_Rotation <= 180f)
            {
                speed += 2.0f;
                mainCamera.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f, Space.Self);

            }
            if (camera_Rotation >= 180f)
            {
                mainCamera.transform.Rotate(0.0f, -5.0f * Time.deltaTime, 0.0f, Space.Self);
                if (camera_Rotation < 180.5f && camera_Rotation > 180f)
                {
                    goingMain = false;
                }
            }
        }
        if (goingOptions)
        {
            float camera_Rotation = mainCamera.transform.eulerAngles.y;
            if (camera_Rotation >= 90f)
            {
                speed += 2.0f;
                mainCamera.transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f, Space.Self);
            }
            if (camera_Rotation <= 90f)
            {
                mainCamera.transform.Rotate(0.0f, 5.0f * Time.deltaTime, 0.0f, Space.Self);
                if (camera_Rotation < 90f && camera_Rotation > 89.5f)
                {
                    goingOptions = false;
                }
            }
        }
        if (goingNewGame)
        {
            float camera_Rotation = mainCamera.transform.eulerAngles.y;
            if (camera_Rotation <= 270f)
            {
                speed += 2.0f;
                mainCamera.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f, Space.Self);
            }
            if (camera_Rotation >= 270f)
            {
                mainCamera.transform.Rotate(0.0f, -5.0f * Time.deltaTime, 0.0f, Space.Self);
                if (camera_Rotation < 270.5f && camera_Rotation > 270f)
                {
                    goingNewGame = false;
                }
            }
        }
        if (goingMainFNG)
        {
            float camera_Rotation = mainCamera.transform.eulerAngles.y;
            if (camera_Rotation >= 180f)
            {
                speed += 2.0f;
                mainCamera.transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f, Space.Self);
            }
            if (camera_Rotation <= 180f)
            {
                mainCamera.transform.Rotate(0.0f, 5.0f * Time.deltaTime, 0.0f, Space.Self);
                if (camera_Rotation < 180f && camera_Rotation > 179.5f)
                {
                    goingMainFNG = false;
                }

            }
        }
        if (goingLoadGame)
        {
            float camera_Rotation = mainCamera.transform.eulerAngles.y;
            if (camera_Rotation <= 270f)
            {
                speed += 2.0f;
                mainCamera.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f, Space.Self);
            }
            if (camera_Rotation >= 270f)
            {
                mainCamera.transform.Rotate(0.0f, -5.0f * Time.deltaTime, 0.0f, Space.Self);
                if (camera_Rotation < 270.5f && camera_Rotation > 270f)
                {
                    goingLoadGame = false;
                }
            }
        }
        if (goingMainLG)
        {
            float camera_Rotation = mainCamera.transform.eulerAngles.y;
            if (camera_Rotation >= 180f)
            {
                speed += 2.0f;
                mainCamera.transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f, Space.Self);
            }
            if (camera_Rotation <= 180f)
            {
                mainCamera.transform.Rotate(0.0f, 5.0f * Time.deltaTime, 0.0f, Space.Self);
                if (camera_Rotation < 180f && camera_Rotation > 179.5f)
                {
                    goingMainLG = false;
                }

            }
        }
    }
    //Method for starting a new game.
    public void newGame()
    {
        print("Starter nytt spell.");
        goingNewGame = true;
        canvas_Load.gameObject.SetActive(false);
        canvas_New.gameObject.SetActive(true);
        speed = 0.0f;
    }
    //Method to load a previous game. Deactivated untill developed.
    public void loadGame()
    {
        print("Haru main?");
        goingLoadGame = true;
        canvas_Load.gameObject.SetActive(true);
        canvas_New.gameObject.SetActive(false);
        speed = 0.0f;
        getPreviousGame();
    }
    public void startLoadedGame()
    {
        if (PlayerPrefs.HasKey("currentScene") && PlayerPrefs.HasKey("playerName"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("currentScene").ToString());
        }
        else
        {
            loadPlayerInfo.GetComponent<Text>().text = "You have no previous save";
        }
    }
    public void panBackLoadGame()
    {
        print("Tilbake.");
        goingMainLG = true;
        speed = 0.0f;

    }
    //Method to move the camera to the Options canvas
    public void panToOptions()
    {
        print("Nå ordnææær vi litt da.");
        goingOptions = true;
        speed = 0.0f;
    }
    //Method to move the camerae to the MainMenu Canvas
    public void panToMain()
    {
        print("Tilbake.");
        goingMain = true;
        speed = 0.0f;
    }
    public void panToMainFNG()
    {
        print("Tilbake.");
        goingMainFNG = true;
        speed = 0.0f;
    }
    public void panToMainLG()
    {
        print("Tilbake.");
        goingMainLG = true;
        speed = 0.0f;

    }
    //Quits the Application, During development this function wont work. So it only Prints to the console.
    public void exitGame()
    {
        Application.Quit();
        print("Ferdig da.");
    }
    public void startNewGame()
    {
        print("Bytt Scene og start spillet da.");
        float tmpVol = PlayerPrefs.GetFloat("VolMusic");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("playerName", playerNameInput.GetComponentInChildren<Text>().text);
        PlayerPrefs.SetInt("playerLvl", 1);
        PlayerPrefs.SetFloat("VolMusic", tmpVol);
        print(PlayerPrefs.GetString("playerName"));
        SceneManager.LoadScene("1_TrainingGround");
    }
    void getPreviousGame()
    {
        string playerName = PlayerPrefs.GetString("playerName");
        loadPlayerInfo.GetComponent<Text>().text = "Character name: " + playerName;
    }
}
