using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    private SkinnedMeshRenderer skinmesh;
    public Material[] skinMaterials;
    private int selectedCharacter = 0;
    public GameObject saveText;
    AudioSource[] sfx;


    // Start is called before the first frame update
    void Start()
    {
        skinmesh = GetComponentInChildren<SkinnedMeshRenderer>();
        PlayerPrefs.SetInt("CharSkins", selectedCharacter);
        saveText.SetActive(false);
        sfx = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
    }

    public void NextSkin()
    {
        sfx[11].Play();
        selectedCharacter = (selectedCharacter + 1) % skinMaterials.Length;
        skinmesh.material = skinMaterials[selectedCharacter];
    }

    public void PreviouSkin()
    {
        sfx[11].Play();
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += skinMaterials.Length;
        }
        skinmesh.material = skinMaterials[selectedCharacter];
    }

    public void GetStoredSkin()
    {
        PlayerPrefs.GetInt("CharSkins");
    }
    
    public void SelectSkin()
    {
        sfx[11].Play();
        skinmesh.material = skinMaterials[selectedCharacter];
        PlayerPrefs.SetInt("CharSkins", selectedCharacter);
        saveText.SetActive(true);
        Invoke("DisableText", 2);
    }

    void DisableText()
    {
        saveText.SetActive(false);
        CancelInvoke("DisableText");
    }
}
