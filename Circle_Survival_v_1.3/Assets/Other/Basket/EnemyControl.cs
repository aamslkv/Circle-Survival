using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    public int health;
    //public float agrDistanse;

    public GameObject effect;
    public GameObject[] redEnemies;
    public Transform[] redEnemiesTransform = null;

    private Transform target;
    private Animation anim;
    private Animator camAnim;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private PlayerControl player;

    public int damage;

    private Rigidbody2D rb;

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.Play();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        anim = gameObject.GetComponent<Animation>();

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        target = GameObject.FindGameObjectWithTag("Player").transform;
        redEnemies = GameObject.FindGameObjectsWithTag("RedEnemy");

        for (int i = 0; i < redEnemies.Length; i++)
        {
            Array.Resize(ref redEnemiesTransform, redEnemies.Length);
            redEnemiesTransform[i] = redEnemies[i].GetComponent<Transform>();
  
        }

        /*if (Vector2.Distance(this.transform.position, target.position) < 6f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            foreach (Transform trans in redEnemiesTransform)
            {
                if (trans == null)
                {
                    return;
                } 
                else if ((trans != null) && (Vector2.Distance(this.transform.position, trans.position) < 3.5f))
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
        }*/

    }

    private void FixedUpdate()
    {
        /*if (Vector2.Distance(this.transform.position, target.position) < 6f)
        {
            
            rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            foreach (Transform trans in redEnemiesTransform)
            {
                if (trans == null)
                {
                    return;
                }
                else if ((trans != null) && (Vector2.Distance(this.transform.position, trans.position) < 3.5f))
                {
                    
                    rb.position = Vector2.MoveTowards(rb.position, trans.position, speed * Time.fixedDeltaTime);
                }
            }
        }*/

        Vector3 dir = (target.transform.position - rb.transform.position).normalized;

        if (Vector3.Distance(target.transform.position, rb.transform.position) > 6.0f)
        {
            rb.transform.position = rb.transform.position;
        }
        else if (Vector3.Distance(target.transform.position, rb.transform.position) < 6.0f)
        {    
            rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);       
        }

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



        /*Vector3 dir = (target.transform.position - rb.transform.position).normalized;
        
        if (Vector3.Distance(target.transform.position, rb.transform.position) > 0.09f)
        {
            rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
        }*/

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                player.health -= damage;
                camAnim.SetTrigger("shke");
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }


}
