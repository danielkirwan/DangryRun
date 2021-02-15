using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSound : MonoBehaviour
{

    List<AudioSource> sfx = new List<AudioSource>();

    // Start is called before the first frame update
   public void Start()
    {
        AudioSource[] allAudioSources = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        //loop through all sounds in the GamaData component from [1] as the first in the background music for the game
        for(int i = 1; i< allAudioSources.Length; i++)
        {
            sfx.Add(allAudioSources[i]);
        }

        sfx.Add(allAudioSources[1]);

        //set the volume of the sfx if none has already been set and update the playerprefs with the new uipdated value
        Slider sfxSlider = this.GetComponent<Slider>();
        if (PlayerPrefs.HasKey("sfxvolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxvolume");
            UpdateSoundVolume(sfxSlider.value);
        }
        else
        {
            sfxSlider.value = 1;
            UpdateSoundVolume(1);
        }
    }

    public void UpdateSoundVolume(float value)
    {
        PlayerPrefs.SetFloat("sfxvolume", value);
        foreach (AudioSource s in sfx)
        {
            s.volume = value;
        }
    }

}
