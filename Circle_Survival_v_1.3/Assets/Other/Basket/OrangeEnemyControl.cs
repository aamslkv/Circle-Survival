using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrangeEnemyControl : MonoBehaviour
{

    public float speed;
    public int health;
    public float chaseDistance;
    public float stoppingDistance;
    public float retreatDistance;
    private Transform player;


    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private float rotZ;
    private Vector3 difference;
    private Animation anim;
    public GameObject effect;

    public GameObject[] redEnemies;
    public Transform[] redEnemiesTransform = null;

    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        anim.Play();
        health -= damage;
    }

    private void FixedUpdate()
    {
        Vector3 dir = (player.transform.position - rb.transform.position).normalized;

        if ((Vector3.Distance(rb.transform.position, player.transform.position) < chaseDistance) && (Vector3.Distance(rb.transform.position, player.transform.position) > stoppingDistance))
        {
            rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
        }
        else if (Vector3.Distance(rb.transform.position, player.transform.position) < retreatDistance)
        {
            rb.MovePosition(rb.transform.position + dir * -speed * Time.fixedDeltaTime);
        }
        else
        {
            foreach (Transform trans in redEnemiesTransform)
            {
                if (trans == null)
                {
                    return;
                }
                else if ((trans != null) && (Vector3.Distance(trans.transform.position, rb.transform.position) < 3.5f))
                {

                    rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
                }
            }
        }
    }

    private void Update()
    {
        anim = gameObject.GetComponent<Animation>();

        redEnemies = GameObject.FindGameObjectsWithTag("RedEnemy");

        for (int i = 0; i < redEnemies.Length; i++)
        {
            Array.Resize(ref redEnemiesTransform, redEnemies.Length);
            redEnemiesTransform[i] = redEnemies[i].GetComponent<Transform>();

        }

        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        difference = player.transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if ((timeBtwShots <= 0) && (Vector2.Distance(transform.position, player.position) < chaseDistance))
        {
            
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}
