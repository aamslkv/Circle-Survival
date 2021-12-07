using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostControl : MonoBehaviour
{
    public BoostType boostType;
    public enum BoostType { hpBoost, ddBoost, reloadBoost, shieldBoost }

    [Range(0, 30)] public float lifetime;
    [Range(0, 30)] public float duration;
    public GameObject effect;

    private int _hpPoint = 30;
 
    private PlayerControl _playerScript;
    private BoostManager _boostScript;

    private SoundEffector soundEffector;


    private void Start()
    {
        
        _playerScript = FindObjectOfType<PlayerControl>();
        _boostScript = FindObjectOfType<BoostManager>();

        soundEffector = FindObjectOfType<SoundEffector>();

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            soundEffector.Play_boostTakeSound();
            Instantiate(effect, transform.position, Quaternion.identity);
            if (boostType == BoostType.hpBoost)
            {
                if ((_playerScript.health + _hpPoint) > 100)
                {
                    int hp = 100 - _playerScript.health;
                    _playerScript.health += hp;
                }
                else
                {
                    _playerScript.health += _hpPoint;
                }
            }

            if (boostType == BoostType.ddBoost)
            {
                _boostScript.bulletPrefab.GetComponent<BulletControl>().damage = 2;
                _boostScript.doubleDamageTime = duration;
            }

            if (boostType == BoostType.reloadBoost)
            {
                _boostScript.playerPrefab.GetComponent<PointerRotation>().startTimeBtwShots = _boostScript.playerPrefab.GetComponent<PointerRotation>().startTimeBtwShots / 2f;
                _boostScript.reloadTime = duration;
            }

            if (boostType == BoostType.shieldBoost)
            {
                _boostScript.shieldPrefab.SetActive(true);
                _boostScript.shieldBoost = true;
                _boostScript.shieldTime = duration;
            }

            Destroy(gameObject);
        }
    }
}
