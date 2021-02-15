using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject statsPanel;
    public GameObject optionsPanel;
    public GameObject skinPanel;
    public GameObject languagePanel;

    int maxLives = 3;
    AudioSource[] sfx;

    public void Start()
    {
        helpPanel.SetActive(false);
        statsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        skinPanel.SetActive(false);
        languagePanel.SetActive(false);
        sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
    }

    public void LoadGameScene()
    {
        //sets number of lives at start of game
        PlayerPrefs.SetInt("lives", maxLives);
        SceneManager.LoadScene("Game",LoadSceneMode.Single);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void PlaySound()
    {
        sfx[11].Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            QuitGame();
        }
    }

    public void CloseHelpPanel()
    {
        PlaySound();
        helpPanel.SetActive(false);
    }

    public void OpenHelpPanel()
    {
        PlaySound();
        helpPanel.SetActive(true);
    }

    public void CloseStatsPanel()
    {
        PlaySound(); 
        statsPanel.SetActive(false);
    }

    public void OpenStatsPanel()
    {
        PlaySound();
        statsPanel.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        PlaySound();
        optionsPanel.SetActive(false);
    }

    public void OpenOptionsPanel()
    {
        PlaySound();
        optionsPanel.SetActive(true);
    }

    public void OpenSkinPanel()
    {
        PlaySound();
        skinPanel.SetActive(true);
    }

    public void CloseSkinPanel()
    {
        PlaySound();
        skinPanel.SetActive(false);
    }

    public void OpenLanguagePanel()
    {
        PlaySound();
        languagePanel.SetActive(true);
    }

    public void CloseLanguagePanel()
    {
        PlaySound();
        languagePanel.SetActive(false);
    }

}
