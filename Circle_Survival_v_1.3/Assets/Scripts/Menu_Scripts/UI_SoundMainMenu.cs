using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SoundMainMenu : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource effectSource; //uiSound
    public AudioClip _swichSound, _errorSound;

    void Start()
    {
        Invoke("UI_Mute", 1f);
    }

    private void UI_Mute()
    {
        effectSource.GetComponent<AudioSource>().mute = false;
    }

    void Update()
    {
        musicSource.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 10;
        effectSource.volume = (float)PlayerPrefs.GetInt("UIVolume") / 10;
    }

    public void Play_swichSound()
    {
        effectSource.PlayOneShot(_swichSound);
    }
    public void Play_errorSound()
    {
        effectSource.PlayOneShot(_errorSound);
    }
}
