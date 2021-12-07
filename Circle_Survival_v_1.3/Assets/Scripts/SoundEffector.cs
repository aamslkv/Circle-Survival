using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource uiSource;
    public AudioSource effectSource;

    public AudioClip _playerShotSound, _PlayerExplosionSound, _orangeEnemyShotSound, _bossShotSound, _BossExplosionSound, _coinTakeSound, _boostTakeSound, _BlackEnemyExplosionSound, _AnyEnemyExplosionSound;

    public AudioClip[] _playerShotSounds;

    void Start()
    {
        musicSource.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 10;
        uiSource.volume = (float)PlayerPrefs.GetInt("UIVolume") / 10;
        effectSource.volume = (float)PlayerPrefs.GetInt("UIVolume") / 10;
    }

    public void Play_playerShotSound()
    {
        effectSource.PlayOneShot(_playerShotSound);
    }

    public void Play_playerAutoShotSound()
    {

        /*int rand = Random.Range(0, _playerShotSounds.Length);

        audioSource.PlayOneShot(_playerShotSounds[rand]);*/
    }

    public void Play_bossShotSound()
    {
        effectSource.PlayOneShot(_bossShotSound);
    }

    public void Play_coinTakeSound()
    {
        effectSource.PlayOneShot(_coinTakeSound);
    }

    public void Play_boostTakeSound()
    {
        effectSource.PlayOneShot(_boostTakeSound);
    }

    public void Play__orangeEnemyShotSound()
    {
        effectSource.PlayOneShot(_orangeEnemyShotSound);
    }

    public void Play_BossExplosionSound()
    {
        effectSource.PlayOneShot(_BossExplosionSound);
    }
    public void Play_BlackEnemyExplosionSound()
    {
        effectSource.PlayOneShot(_BlackEnemyExplosionSound);

    }
    public void Play_AnyEnemyExplosionSound()
    {
        effectSource.PlayOneShot(_AnyEnemyExplosionSound);
    }
    public void Play_PlayerExplosionSound()
    {
        effectSource.PlayOneShot(_PlayerExplosionSound);
    }
}
