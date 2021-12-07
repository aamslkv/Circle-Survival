using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemyControl : MonoBehaviour
{
    public float speed;
    public int health;

    public GameObject effect;
    private Animation anim;
    private Animator camAnim;

    private Transform target;

    private PlayerControl player;
    public int damage;

    private Rigidbody2D rb;

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.Play("BlackEnemyAnimTakeDamage");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.health -= damage;
            camAnim.SetTrigger("shke");
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play("BlackEnemyAnim");
        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        target = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 dir = (target.transform.position - rb.transform.position).normalized;

        if (Vector3.Distance(target.transform.position, rb.transform.position) > 0.09f)
        {
            rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
        }

    }
}
