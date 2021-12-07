using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBulletControl : MonoBehaviour
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

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerControl>().ChangeHealth(-damage);
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
