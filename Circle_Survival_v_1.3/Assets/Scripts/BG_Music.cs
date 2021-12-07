using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Music : MonoBehaviour
{
    public AudioSource music_BG_Source;
    public AudioClip[] music_BG_Sounds;

    private PlayerControl _playerScript;

    void Start()
    {
        _playerScript = FindObjectOfType<PlayerControl>();

        music_BG_Source.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 10;

        int rand = Random.Range(0, music_BG_Sounds.Length);

        music_BG_Source.PlayOneShot(music_BG_Sounds[rand]);

        //music_BG_Source.AudioClip = music_BG_Sounds[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (!music_BG_Source.isPlaying)
        {
            int rand = Random.Range(0, music_BG_Sounds.Length);

            music_BG_Source.PlayOneShot(music_BG_Sounds[rand]);
        }

        if (_playerScript.game_over == true)
            music_BG_Source.GetComponent<AudioSource>().mute = true;
    }
}
