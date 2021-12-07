using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject effect;
    


    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyControlScript>().TakeDamage(damage);       
            }
            else if (hitInfo.collider.CompareTag("RedEnemy"))
            {
                hitInfo.collider.GetComponent<EnemyControlScript>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("BlackEnemy"))
            {
                hitInfo.collider.GetComponent<EnemyControlScript>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("OrangeEnemy"))
            {
                hitInfo.collider.GetComponent<EnemyControlScript>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<BossControl>().TakeDamage(damage);
            }


            DestroyBullet();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        

    }

    public void DestroyBullet()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
