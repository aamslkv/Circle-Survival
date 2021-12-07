using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public enum bossType { game, menu}
    public bossType bossT;

    [Range(0, 200)] [SerializeField] private int health;
    [Range(0, 10)] [SerializeField] private int damage;
    [Range(0, 10)] [SerializeField] private float speed;
    [Range(0, 360)] [SerializeField] private int speedRotate;
    [Range(0, 100)] [SerializeField] private int exp;

    [Range(0, 10)] [SerializeField] private float startTimeBtwAttack;
                                    private float timeBtwAttack;

    [Range(0, 10)] [SerializeField] private float autoAttack;
    [Range(0, 10)] [SerializeField] private float autoSpawnB_E;
    [SerializeField] private GameObject blackEnemy;


    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] shotPoints;

    private Vector3 _whereToSpawn;

    private Transform _playerTarget;
    private Rigidbody2D _rbThis;
    private PlayerControl _playerScript;

    public GameObject diamondCoin;
    public GameObject effect;

    private Animation _animRAGE;

    private float stage_1 = 3f;
    private float stage_2 = 3.5f;

    private SoundEffector soundEffector;

    private void Start()
    {
        if (bossT == bossType.game)
        {
            _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(AutoSpawnBlackEnemy());
            soundEffector = FindObjectOfType<SoundEffector>();
        }
        
        _rbThis = GetComponent<Rigidbody2D>();

        _playerScript = FindObjectOfType<PlayerControl>();

        _animRAGE = gameObject.GetComponent<Animation>();

        StartCoroutine(AutoAttack());
        //StartCoroutine(AutoSpawnBlackEnemy());

    }
    private void Update()
    {
        if (health > 100)
        {
            transform.Rotate(0, 0, speedRotate * Time.deltaTime);
        }
        else if ((health <= 100) && (health > 50))
        {
            if (stage_1 > 0f)
            {
                _animRAGE.Play("BossRageAnim");
                stage_1 -= Time.deltaTime;
                autoAttack = 0.09f;
                speed = 2.85f;
                transform.Rotate(0, 0, speedRotate * Time.deltaTime);
            }
            else if(stage_1 <= 0f)
            {
                //_animRAGE.Stop("BossRageAnim");
                autoAttack = 0.8f;
                transform.Rotate(0, 0, speedRotate * Time.deltaTime);
            }
        }
        else if ((health <= 50) && (health > 0))
        {
            if (stage_2 > 0f)
            {
                _animRAGE.Play("BossRageAnim");
                stage_2 -= Time.deltaTime;
                autoAttack = 0.09f;
                speed = 3.1f;
                transform.Rotate(0, 0, speedRotate * Time.deltaTime);
            }
            else if (stage_2 <= 0f)
            {
                //_animRAGE.Stop("BossRageAnim");
                autoAttack = 0.8f;
                transform.Rotate(0, 0, speedRotate * Time.deltaTime);
            }
        }
        else if (health <= 0)
        {
            if (bossT == bossType.game)
            {
                soundEffector.Play_BossExplosionSound();
            }
            _playerScript.GetComponent<PlayerControl>().TakeExp(exp);
            Instantiate(effect, this.transform.position, Quaternion.identity);

            for (int i = 6; i > 0; i--)
            {
                _whereToSpawn = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                Instantiate(blackEnemy, this.transform.position + _whereToSpawn, Quaternion.identity);
            }

            for (int i = 2; i > 0; i--)
            {
                Instantiate(diamondCoin, this.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (bossT == bossType.game)
        {
            Vector3 dir = (_playerTarget.transform.position - _rbThis.transform.position).normalized;

            _rbThis.MovePosition(_rbThis.transform.position + dir * speed * Time.fixedDeltaTime);
        } 

    }

    public void TakeDamage(int damage)
    {
        _animRAGE.Play("BossTakeDamag");
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                _playerScript.health -= damage;
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeBtwAttack = timeBtwAttack / 4f;
        }
    }

    IEnumerator AutoAttack()
    {
        yield return new WaitForSeconds(autoAttack);

        foreach (Transform shotPointsArr in shotPoints)
        {
            Instantiate(bullet, shotPointsArr.position, shotPointsArr.rotation);
        }

        if (bossT == bossType.game)
        {
            soundEffector.Play_bossShotSound();
        }

        Repeat();
    }
    private void Repeat()
    {
        StartCoroutine(AutoAttack());
    }

    IEnumerator AutoSpawnBlackEnemy()
    {
        yield return new WaitForSeconds(autoSpawnB_E);

        Instantiate(blackEnemy, transform.position, Quaternion.identity);

        RepeatAutoSpawnBlackEnemy();
    }
    private void RepeatAutoSpawnBlackEnemy()
    {
        StartCoroutine(AutoSpawnBlackEnemy());
    }


    
}
