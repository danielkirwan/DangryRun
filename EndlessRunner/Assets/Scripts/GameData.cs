using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    public static GameData singleton;
    int score = 0;
    public Text scoreText = null;
    public GameObject musicSlider;
    public GameObject soundSlider;
    Scroll scroll;

    //Singleton - only one exists in the whole game
    private void Awake()
    {
        GameObject[] gd = GameObject.FindGameObjectsWithTag("GameData");
        if(gd.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        singleton = this;

        PlayerPrefs.SetInt("score", 0);
        //updates the sound volumes that are stored in player prefs.
        //Before you had to open up the options panel for the sounds to work. Start methods in the relevant classes are not public for access
        musicSlider.GetComponent<UpdateMusic>().Start();
        soundSlider.GetComponent<UpdateSound>().Start();

    }

    public void UpdateScore(int updatedScore)
    {
        score += updatedScore;
        PlayerPrefs.SetInt("score", score);
        if (scoreText != null)
        {
            //scoreText.text = "Score: " + score;
            scoreText.text = "" + score;
        }
    }

}
