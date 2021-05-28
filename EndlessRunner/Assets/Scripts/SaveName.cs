using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public Text saveNameText;
  public void SaveTheName()
    {
        PlayerPrefs.SetString("PlayerName", saveNameText.text);
        Debug.Log("Player name is: " + PlayerPrefs.GetString("PlayerName"));
    }
}
