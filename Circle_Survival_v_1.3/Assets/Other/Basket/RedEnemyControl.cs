using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyControl : MonoBehaviour
{
    public float speed;
    private Transform target;
    public GameObject blackEnemy;

    private Vector3 whereToSpawn;
    public int health;

    private Animation anim;
    private Animator camAnim;

    public GameObject effect;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private PlayerControl player;

    public int damage;

    private Rigidbody2D rb;

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
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            for(int i = 3; i > 0; i--)
            {
                whereToSpawn = new Vector3(Random.Range(-0.4f,0.4f), Random.Range(-0.5f, 0.5f), 0f);
                Instantiate(blackEnemy, this.transform.position + whereToSpawn, Quaternion.identity);
            }
            
        }
        if (Vector2.Distance(this.transform.position, target.position) > 8f)
        {
            speed = 1.5f;
        }
        else if (Vector2.Distance(this.transform.position, target.position) < 8f)
        {
            speed = 1.0f;
        }

        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // голимая хуета, но работает

    }

    private void FixedUpdate()
    {
        //rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);

        Vector3 dir = (target.transform.position - rb.transform.position).normalized;

        if (Vector3.Distance(target.transform.position, rb.transform.position) > 0.09f)
        {
            rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
        }
    }
}
