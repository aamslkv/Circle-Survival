using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject playerPrefab;
    public GameObject shieldPrefab;

    public float doubleDamageTime;
    public float reloadTime;
    public float shieldTime;

    public bool shieldBoost = false;

    public void Start()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (bulletPrefab.GetComponent<BulletControl>().damage >= 2)
        {
            if (doubleDamageTime > 0)
                doubleDamageTime -= Time.deltaTime;
            else if (doubleDamageTime <= 0)
                bulletPrefab.GetComponent<BulletControl>().damage = 1;      
        }

        if (playerPrefab != null)
        {
            if (playerPrefab.GetComponent<PointerRotation>().startTimeBtwShots <= 0.1f)
            {
                if (reloadTime > 0)
                    reloadTime -= Time.deltaTime;
                else if (reloadTime <= 0)
                    playerPrefab.GetComponent<PointerRotation>().startTimeBtwShots = playerPrefab.GetComponent<PointerRotation>().startTimeBtwShots * 2f;
            }
        }
        else if (playerPrefab == null)
        {
            return;
        }

        if (shieldBoost == true)
        {
            if (shieldTime > 0)
                shieldTime -= Time.deltaTime;
            else if (shieldTime <= 0)
                shieldPrefab.SetActive(false);
        }
    }
}
