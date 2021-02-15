using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageInteractions : MonoBehaviour
{
    public GameObject saveIcon;
    AudioSource[] sfx;

    private void Start()
    {
        saveIcon.SetActive(false);
        sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
    }


    public void SaveLanguage()
    {
        saveIcon.SetActive(true);
        sfx[11].Play();
        Invoke("DisableSaveIcon", 2);
    }

    void DisableSaveIcon()
    {
        saveIcon.SetActive(false);
        CancelInvoke("DisableSaveIcon");
    }

}
