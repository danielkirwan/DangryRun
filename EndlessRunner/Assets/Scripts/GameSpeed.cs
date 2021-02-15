using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{

    AudioSource[] sfx;
    public GameObject saveText;

    private void Start()
    {
        sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
    }

    public void NormalSpeed()
    {
        PlayerPrefs.SetFloat("PlayerGameSpeed", 1f);
        sfx[11].Play();
        saveText.SetActive(true);
        Invoke("DisableText", 2);
    }

    public void HardSpeed()
    {
        PlayerPrefs.SetFloat("PlayerGameSpeed", 2f);
        sfx[11].Play();
        saveText.SetActive(true);
        Invoke("DisableText", 2);
    }

    public void InsaneSpeed()
    {
        PlayerPrefs.SetFloat("PlayerGameSpeed", 3f);
        sfx[11].Play();
        saveText.SetActive(true);
        Invoke("DisableText", 2);
    }

    void DisableText()
    {
        saveText.SetActive(false);
        CancelInvoke("DisableText");
    }


}
