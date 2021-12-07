using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRainCount : MonoBehaviour
{
    public float lifetime;
    public int damage;


    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("RedEnemy") || other.gameObject.CompareTag("BlackEnemy") || other.gameObject.CompareTag("OrangeEnemy"))
        {
            other.gameObject.GetComponent<EnemyControlScript>().TakeDamage(damage); 
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<BossControl>().TakeDamage(damage);
        }
    }
}
