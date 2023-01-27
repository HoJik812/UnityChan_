using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{

    public AudioClip[] audios;

    public AudioMixer setting;

    public Slider slider;
    

    public void AudioSet()
    {
        float sound = slider.value;
        
        if(sound == -40f)
        {
            setting.SetFloat("BGM", -80);
        }
        else
        {
            setting.SetFloat("BGM", sound);
        }

    }


}
