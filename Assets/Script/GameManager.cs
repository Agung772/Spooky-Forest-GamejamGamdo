using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool iniMainmenu;
    public int iniSceneBerapa;
    public static GameManager instance;
    public PlayerController playerController;
    public Vector3 savePosisiPlayer;
    public GameObject pauseUI, exitUI, buttonMainMenu, notifPauseText, creditUI;
    public CameraController cameraMainMenu;
    int saveScene;
    public int notifPause;
    
    private void Awake()
    {
        Application.targetFrameRate = 60;

        notifPause = PlayerPrefs.GetInt("NotifPause");
        saveScene = PlayerPrefs.GetInt("SaveLevel");
        instance = this;
        if (playerController != null)
        {
            savePosisiPlayer = playerController.transform.position;
        }

        if (iniSceneBerapa == 1 || iniSceneBerapa == 2 || iniSceneBerapa == 3)
        {
            PlayerPrefs.SetInt("SaveLevel", iniSceneBerapa);
            cameraMainMenu.transform.position = savePosisiPlayer;
        }

        if (notifPause == 0)
        {
            notifPauseText.SetActive(true);
        }
        else if (notifPause == 1)
        {
            notifPauseText.SetActive(false);
        }

        if (iniMainmenu)
        {
            notifPauseText.GetComponent<TextMeshProUGUI>().text = "Tekan P untuk Setting Audio";
        }

    }
    public void PlayerDeath()
    {
        playerController.PlayerOperation = false;
        playerController.gameObject.SetActive(false);
        StartCoroutine(PlayerDeathCoroutine());
        IEnumerator PlayerDeathCoroutine()
        {
            yield return new WaitForSeconds(5f);
            PlayerSpawn();
        }
    }

    public void PlayerSpawn()
    {
        playerController.transform.position = savePosisiPlayer;
        cameraMainMenu.transform.position = savePosisiPlayer;
        playerController.gameObject.SetActive(true);
        StartCoroutine(PlayerSpawnCoroutine());
        IEnumerator PlayerSpawnCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            playerController.PlayerOperation = true;
        }

    }
    bool conditionPauseUI;
    bool EscapeCondition;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (!iniMainmenu)
            {
                PlayerPrefs.SetInt("NotifPause", 1);
            }

            notifPauseText.SetActive(false);
            if (!conditionPauseUI)
            {
                conditionPauseUI = true;
                pauseUI.SetActive(true);
                Time.timeScale = 0;

                EscapeCondition = false;
                exitUI.SetActive(false);
            }
            else if (conditionPauseUI)
            {
                conditionPauseUI = false;
                pauseUI.SetActive(false);
                Time.timeScale = 1;
            }

            AudioManager.instance.SfxBuutonUI();
        }
        if (!iniMainmenu)
        {

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (!EscapeCondition)
                {
                    EscapeCondition = true;
                    exitUI.SetActive(true);
                    Time.timeScale = 0;

                    conditionPauseUI = false;
                    pauseUI.SetActive(false);
                }
                else if (EscapeCondition)
                {
                    EscapeCondition = false;
                    exitUI.SetActive(false);

                    Time.timeScale = 1;
                }

                AudioManager.instance.SfxBuutonUI();
            }
        }

        if (Input.GetKeyUp(KeyCode.Delete))
        {
            PlayerPrefs.DeleteKey("SaveLevel");
            PlayerPrefs.DeleteKey("NotifPause");
            saveScene = 0;
            AudioManager.instance.SfxBuutonUI();
        }
        if (iniSceneBerapa == 1 || iniSceneBerapa == 2 || iniSceneBerapa == 3)
        {
            if (Input.GetKeyUp(KeyCode.L))
            {
                SceneManager.LoadScene(iniSceneBerapa);
                AudioManager.instance.SfxBuutonUI();
            }
        }
        if (Input.GetKeyUp(KeyCode.End))
        {
            bool aktif = false;
            if (!aktif)
            {
                aktif = true;
                playerController.antiMati = true;
            }
        }
    }

    public void SceneLevel(int levelIndex)
    {
        StartCoroutine(DelayCoroutine());
        IEnumerator DelayCoroutine()
        {
            if (levelIndex != 10)
            {
                if (cameraMainMenu != null) cameraMainMenu.CameraOut();
                if (buttonMainMenu != null) buttonMainMenu.SetActive(false);
            }
            else if (levelIndex == 10)
            {
                if (saveScene != 0)
                {
                    if (cameraMainMenu != null) cameraMainMenu.CameraOut();
                    if (buttonMainMenu != null) buttonMainMenu.SetActive(false);
                }
            }
            yield return new WaitForSeconds(2f);
            if (levelIndex == 1 || levelIndex == 2)
            {
                SceneManager.LoadScene(iniSceneBerapa + 1);
            }
            else if (levelIndex == 3)
            {
                SceneManager.LoadScene(6);
            }
            else if (levelIndex == 0)
            {
                SceneManager.LoadScene(0);
            }
            else if (levelIndex == 4)
            {
                SceneManager.LoadScene(4);
            }
            else if (levelIndex == 10)
            {
                if (saveScene != 0)
                {

                    SceneManager.LoadScene(saveScene);

                }
                else
                {
                    NotifikasiManager.instance.SpawnNotifkasi("Belom ada yang di save, mulai game baru dulu");
                }
                
            }

        }

    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void CreditUI()
    {
        creditUI.SetActive(true);
        buttonMainMenu.SetActive(false);
    }
    public void UnCreditUI()
    {
        creditUI.SetActive(false);
        buttonMainMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();

        AudioManager.instance.SfxBuutonUI();
    }
    public void UnExit()
    {
        exitUI.SetActive(false);
        EscapeCondition = false;
        Time.timeScale = 1;

        AudioManager.instance.SfxBuutonUI();
    }

}
