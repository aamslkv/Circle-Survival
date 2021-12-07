using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    private PlayerControl _playerScript;
    public GameObject effect;

    private SoundEffector soundEffector;

    private void Start()
    {
        _playerScript = FindObjectOfType<PlayerControl>();

        soundEffector = FindObjectOfType<SoundEffector>();
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //_playerScript.coin += 1;

            soundEffector.Play_coinTakeSound();

            StaticCoins._Coins += 1;
            PlayerPrefs.SetInt("_Coins", StaticCoins._Coins);

            //PlayerPrefs.SetInt("coins", _playerScript.coin);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
