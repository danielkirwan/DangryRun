using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    //public Text lastScore;
    public Text highScore;

    private void OnEnable()
    {
        //if (PlayerPrefs.HasKey("lastscore"))
        //{
        //    //lastScore.text = "Last score: " + PlayerPrefs.GetInt("lastscore");
        //    lastScore.text =  "" +PlayerPrefs.GetInt("lastscore");
        //}
        //else
        //{
        //    lastScore.text = "0";
        //}
        //PlayerPrefs.DeleteKey("highscore");
        if (PlayerPrefs.HasKey("highscore"))
        {
            //highScore.text = "High score: " + PlayerPrefs.GetInt("highscore");
            highScore.text = "" + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highScore.text = "0";
        }







    }
}
