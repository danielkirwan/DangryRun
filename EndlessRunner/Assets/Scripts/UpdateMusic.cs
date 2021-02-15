using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMusic : MonoBehaviour
{

    List<AudioSource> music = new List<AudioSource>();

    // Start is called before the first frame update
    public void Start()
    {
        AudioSource[] allAudioSources = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        music.Add(allAudioSources[0]);

        Slider musicSlider = this.GetComponent<Slider>();
        Slider gameSpeedSlider = this.GetComponent<Slider>();
        if (PlayerPrefs.HasKey("musicvolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicvolume");
            UpdateMusicVolume(musicSlider.value);
        }
        else
        {
            musicSlider.value = 1;
            UpdateMusicVolume(1);
        }

    }

    public void UpdateMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("musicvolume", value);
        foreach(AudioSource m in music)
        {
            m.volume = value;
        }
    }

}
