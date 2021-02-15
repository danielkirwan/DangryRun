using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject optionsPanel;
    public static bool GameIsPaused = false;
    private Speed speed;
    private float pauseMenuSpeed;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void LoadMenuScene()
    {
        PlayerController.sfx[11].Play();
        GameIsPaused = false;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
       // Time.timeScale = PlayerPrefs.GetFloat("GameSpeed");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void CloseOptionsPanel()
    {
        PlayerController.sfx[11].Play();
        optionsPanel.SetActive(false);
    }

    public void OpenOptionsPanel()
    {
        PlayerController.sfx[11].Play();
        optionsPanel.SetActive(true);
    }

    public void Pause()
    {
        //stores the current gamespeed in the playerprefs
        PlayerPrefs.SetFloat("PlayerGameSpeed", Time.timeScale);
        OpenOptionsPanel();
        //sets timescale to 0 for pause menu
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        CloseOptionsPanel();
        //sets local pausementspeed to GameSpeed store in thePause()
        pauseMenuSpeed = PlayerPrefs.GetFloat("PlayerGameSpeed");
        //Set the timescale back to what it was when the player hit pause
        Time.timeScale = pauseMenuSpeed;
        GameIsPaused = false;
    }

}
