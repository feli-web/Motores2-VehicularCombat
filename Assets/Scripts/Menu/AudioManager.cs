using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audios;
    public Slider bgmSlider;
    public Slider sfxSlider;
    float bgm;
    float sfx;
   
    void Start()
    {
        bgm = PlayerPrefs.GetFloat("BGM", 0);
        sfx = PlayerPrefs.GetFloat("SFX", 0);
        bgmSlider.minValue = -80;
        sfxSlider.minValue = -80;
        bgmSlider.maxValue = 0;
        sfxSlider.maxValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sfx = sfxSlider.value;
        bgm = bgmSlider.value;
        audios.SetFloat("BGMvol", bgm);
        audios.SetFloat("SFXvol", sfx);
        PlayerPrefs.SetFloat("BGM", bgm);
        PlayerPrefs.SetFloat("SFX", sfx);
    }
}

