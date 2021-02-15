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
        LeanTween.init(800);
        LeanTween.scaleX(helpPanel, 0, 1);
        LeanTween.scaleY(helpPanel, 0, 1);
        helpPanel.SetActive(false);
    }

    public void OpenHelpPanel()
    {
        PlaySound();
        helpPanel.SetActive(true);
        LeanTween.init(800);
        LeanTween.scaleX(helpPanel, 1, 1);
        LeanTween.scaleY(helpPanel, 1, 1);
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
        LeanTween.init(800);
        LeanTween.scaleX(optionsPanel, 0, 1);
        LeanTween.scaleY(optionsPanel, 0, 1);
        optionsPanel.SetActive(false);
       
    }

    public void OpenOptionsPanel()
    {
        PlaySound();
        optionsPanel.SetActive(true);
        LeanTween.scaleX(optionsPanel, 1, 1);
        LeanTween.scaleY(optionsPanel, 1, 1);
    }

    public void OpenSkinPanel()
    {
        PlaySound();
        skinPanel.SetActive(true);
        LeanTween.init(800);
        LeanTween.scaleX(skinPanel, 1, 1);
        LeanTween.scaleY(skinPanel, 1, 1);
    }

    public void CloseSkinPanel()
    {
        PlaySound();
        LeanTween.init(800);
        LeanTween.scaleX(skinPanel, 0, 1);
        LeanTween.scaleY(skinPanel, 0, 1);
        skinPanel.SetActive(false);
        
    }

    public void OpenLanguagePanel()
    {
        PlaySound();
        languagePanel.SetActive(true);
        LeanTween.init(800);
        LeanTween.scaleX(languagePanel, 1, 1);
        LeanTween.scaleY(languagePanel, 1, 1);
    }

    public void CloseLanguagePanel()
    {
        PlaySound();
        LeanTween.init(800);
        LeanTween.scaleX(languagePanel, 0, 1);
        LeanTween.scaleY(languagePanel, 0, 1);
        languagePanel.SetActive(false);
    }

    public void OpenTwitter()
    {
        PlaySound();
        Application.OpenURL("https://twitter.com/DangryGames");
    }

}
