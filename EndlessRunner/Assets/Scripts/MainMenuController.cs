using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject statsPanel;
    public GameObject optionsPanel;
    public GameObject skinPanel;
    public GameObject languagePanel;
    public GameObject namePanel;

    public Text nameText;

    int maxLives = 3;
    AudioSource[] sfx;

    public void Start()
    {
        helpPanel.SetActive(false);
        //statsPanel.SetActive(true);
        statsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        skinPanel.SetActive(false);
        languagePanel.SetActive(false);
        namePanel.SetActive(false);
        sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();

        //PlayerPrefs.DeleteKey("PlayerName");

        if (PlayerPrefs.HasKey("PlayerName"))
        {
            nameText.text = PlayerPrefs.GetString("PlayerName");
            OpenStatsPanel();
        }
        if(!PlayerPrefs.HasKey("PlayerName")){
            OpenNamePanel();
        }

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

    public void OpenNamePanel()
    {
        PlaySound();
        namePanel.SetActive(true);
        LeanTween.scaleX(namePanel, 1, 1);
        LeanTween.scaleY(namePanel, 1, 1);
        CloseStatsPanel();
    }

    public void CloseNamePanel()
    {
        PlaySound();
        
        LeanTween.scaleX(namePanel, 0, 1);
        LeanTween.scaleY(namePanel, 0, 1);
        namePanel.SetActive(false);
        Invoke("OpenStatsPanel", 1);
        //OpenStatsPanel();
        //SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void CloseHelpPanel()
    {
        PlaySound();
        //LeanTween.init(800);
        LeanTween.scaleX(helpPanel, 0, 1);
        LeanTween.scaleY(helpPanel, 0, 1);
        helpPanel.SetActive(false);
        OpenStatsPanel();
    }

    public void OpenHelpPanel()
    {
        PlaySound();
        helpPanel.SetActive(true);
        //LeanTween.init(800);
        LeanTween.scaleX(helpPanel, 1, 1);
        LeanTween.scaleY(helpPanel, 1, 1);
        CloseStatsPanel();
    }

    public void CloseStatsPanel()
    {
        PlaySound();
        LeanTween.init(800);
        LeanTween.scaleX(statsPanel, 0, 1);
        LeanTween.scaleY(statsPanel, 0, 1);
        statsPanel.SetActive(false);
    }

    public void OpenStatsPanel()
    {
        PlaySound();
        LeanTween.init(800);
        statsPanel.SetActive(true);
        nameText.text = PlayerPrefs.GetString("PlayerName");
        Debug.Log(nameText.text);
        LeanTween.scaleX(statsPanel, 1, 1);
        LeanTween.scaleY(statsPanel, 1, 1);
    }

    public void CloseOptionsPanel()
    {
        PlaySound();
        LeanTween.init(800);
        LeanTween.scaleX(optionsPanel, 0, 1);
        LeanTween.scaleY(optionsPanel, 0, 1);
        optionsPanel.SetActive(false);
        OpenStatsPanel();
    }

    public void OpenOptionsPanel()
    {
        PlaySound();
        Debug.Log("Clicked");
        optionsPanel.SetActive(true);
        LeanTween.scaleX(optionsPanel, 1, 1);
        LeanTween.scaleY(optionsPanel, 1, 1);
        CloseStatsPanel();
    }

    public void OpenSkinPanel()
    {
        PlaySound();
        skinPanel.SetActive(true);
        LeanTween.init(800);
        LeanTween.scaleX(skinPanel, 1, 1);
        LeanTween.scaleY(skinPanel, 1, 1);
        CloseStatsPanel();
    }

    public void CloseSkinPanel()
    {
        PlaySound();
        LeanTween.init(800);
        LeanTween.scaleX(skinPanel, 0, 1);
        LeanTween.scaleY(skinPanel, 0, 1);
        skinPanel.SetActive(false);
        OpenStatsPanel();
    }

    public void OpenLanguagePanel()
    {
        PlaySound();
        languagePanel.SetActive(true);
        LeanTween.init(800);
        LeanTween.scaleX(languagePanel, 1, 1);
        LeanTween.scaleY(languagePanel, 1, 1);
        CloseStatsPanel();
    }

    public void CloseLanguagePanel()
    {
        PlaySound();
        LeanTween.init(800);
        LeanTween.scaleX(languagePanel, 0, 1);
        LeanTween.scaleY(languagePanel, 0, 1);
        languagePanel.SetActive(false);
        OpenStatsPanel();
    }

    public void OpenTwitter()
    {
        PlaySound();
        Debug.Log("Clicked");
        Application.OpenURL("https://twitter.com/DangryGames");
    }

    public void OpenYoutube()
    {
        PlaySound();
        Application.OpenURL("https://www.youtube.com/channel/UCijlLKAY2ddkDBGqommWOtg");
    }

    public void OpenWebsite()
    {
        PlaySound();
        Application.OpenURL("https://dangrygames.co.uk/");
    }

}
