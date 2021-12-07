using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyControlScript : MonoBehaviour
{
    [Header("Choos enemy type")]

    [Space]

    public EnemyType enemyType;
    public enum EnemyType { BlackEnemy, OrangeEnemy, PurpleEnemy, RedEnemy }

    [Range(0, 10)] [SerializeField] private int health;
    [Range(0, 10)] [SerializeField] private int damage;
    [Range(0, 10)] [SerializeField] private float speed;
    [Range(0, 10)] [SerializeField] private int exp;
    [Range(0, 10)] [SerializeField] private float startTimeBtwAttack;
                                    private float timeBtwAttack;

    [Space]

    [Range(0, 10)] [SerializeField] private float chaseDistance;
    [Range(0, 10)] [SerializeField] private float stoppingDistance;
    [Range(0, 10)] [SerializeField] private float retreatDistance;

    [Space]

    [Header("Orange enemy settings")]

    [Space]

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    private float offset = -90.0f;
    private float rotZ;
    private Vector3 difference;

    [Space]

    [Header("Red enemy settings")]

    [Space]

    [SerializeField] private GameObject blackEnemy;

    [Space]

    [Header("Destroy effect")]

    [SerializeField] private GameObject effect;

    private Animation _animTakeDamage;
    private Animator _animGiveDamage;

    private GameObject[] _redEnemies;
    private Transform[] _redEnemiesTransform = null;

    private Transform _playerTarget;
    private Rigidbody2D _rbThis;
    private Vector3 _whereToSpawn;  
    private PlayerControl _playerScript;

    public GameObject diamondCoin;

    private SoundEffector soundEffector;

    private void Start()
    {
        _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _rbThis = GetComponent<Rigidbody2D>();

        _animTakeDamage = gameObject.GetComponent<Animation>();
        _animGiveDamage = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

        _playerScript = FindObjectOfType<PlayerControl>();

        soundEffector = FindObjectOfType<SoundEffector>();

    }

    private void Update()
    {
        if (_playerTarget != null)
        {
            if (enemyType == EnemyType.PurpleEnemy || enemyType == EnemyType.OrangeEnemy)
            {
                _redEnemies = GameObject.FindGameObjectsWithTag("RedEnemy");

                for (int i = 0; i < _redEnemies.Length; i++)
                {
                    Array.Resize(ref _redEnemiesTransform, _redEnemies.Length);
                    _redEnemiesTransform[i] = _redEnemies[i].GetComponent<Transform>();
                }
            }



            if (enemyType == EnemyType.BlackEnemy)
            {
                _animTakeDamage.Play("BlackEnemyAnim");
            }

            if (enemyType == EnemyType.RedEnemy)
            {
                if (health <= 0)
                {
                    //soundEffector.Play_AnyEnemyExplosionSound();
                    Instantiate(effect, transform.position, Quaternion.identity);
                    CoinRandom();
                    _playerScript.GetComponent<PlayerControl>().TakeExp(exp);
                    Destroy(gameObject);
                    for (int i = 3; i > 0; i--)
                    {
                        _whereToSpawn = new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.5f, 0.5f), 0f);
                        Instantiate(blackEnemy, this.transform.position + _whereToSpawn, Quaternion.identity);
                    }

                }

                if (Vector2.Distance(this.transform.position, _playerTarget.position) > stoppingDistance)
                {
                    speed = 1.5f;
                }
                else if (Vector2.Distance(this.transform.position, _playerTarget.position) < stoppingDistance)
                {
                    speed = 1.0f;
                }

            }
            else
            {
                if (health <= 0)
                {
                    if (enemyType == EnemyType.BlackEnemy)
                        soundEffector.Play_BlackEnemyExplosionSound();

                    Instantiate(effect, transform.position, Quaternion.identity);
                    CoinRandom();
                    _playerScript.GetComponent<PlayerControl>().TakeExp(exp);
                    Destroy(gameObject);
                }
            }


            if (enemyType == EnemyType.OrangeEnemy)
            {
                difference = _playerTarget.transform.position - transform.position;
                rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

                if ((timeBtwAttack <= 0) && (Vector2.Distance(transform.position, _playerTarget.position) < chaseDistance))
                {
                    soundEffector.Play__orangeEnemyShotSound();
                    Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                    timeBtwAttack = startTimeBtwAttack;

                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
            }
        }
        else if (_playerTarget == null)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        if (_playerTarget != null)
        {

            Vector3 dir = (_playerTarget.transform.position - _rbThis.transform.position).normalized;

            if ((enemyType == EnemyType.PurpleEnemy) && (_playerScript.level < 4) && (health == 4))
            {
                if (Vector3.Distance(_playerTarget.transform.position, _rbThis.transform.position) > chaseDistance)
                {
                    this.transform.position = this.transform.position;
                }
                else if (Vector3.Distance(_playerTarget.transform.position, _rbThis.transform.position) < chaseDistance)
                {
                    _rbThis.MovePosition(_rbThis.transform.position + dir * speed * Time.fixedDeltaTime);
                }

                if (_redEnemiesTransform == null)
                {
                    return;
                }
                else if (_redEnemiesTransform != null)
                {
                    foreach (Transform trans in _redEnemiesTransform)
                    { 
                        if ((trans != null) && (Vector3.Distance(trans.transform.position, _rbThis.transform.position) < 3.5f))
                        {

                            _rbThis.MovePosition(_rbThis.transform.position + dir * speed * Time.fixedDeltaTime);
                        }
                    }
                }      
            }
            else if (enemyType == EnemyType.OrangeEnemy && _playerScript.level < 6 && health == 5)
            {
                if ((Vector3.Distance(_rbThis.transform.position, _playerTarget.transform.position) < chaseDistance) && (Vector3.Distance(_rbThis.transform.position, _playerTarget.transform.position) > stoppingDistance))
                {
                    _rbThis.MovePosition(_rbThis.transform.position + dir * speed * Time.fixedDeltaTime);
                }
                else if (Vector3.Distance(_rbThis.transform.position, _playerTarget.transform.position) < retreatDistance)
                {
                    _rbThis.MovePosition(_rbThis.transform.position + dir * -speed * Time.fixedDeltaTime);
                }
                else
                {
                    if (_redEnemiesTransform == null)
                    {
                        return;
                    }
                    else if (_redEnemiesTransform != null)
                    {
                        foreach (Transform trans in _redEnemiesTransform)
                        {
                            if ((trans != null) && (Vector3.Distance(trans.transform.position, _rbThis.transform.position) < 3.5f))
                            {

                                _rbThis.MovePosition(_rbThis.transform.position + dir * speed * Time.fixedDeltaTime);
                            }
                        }
                    }
                }
            }
            else
            {
                _rbThis.MovePosition(_rbThis.transform.position + dir * speed * Time.fixedDeltaTime);

                if (enemyType == EnemyType.OrangeEnemy)
                {
                    if (Vector3.Distance(_rbThis.transform.position, _playerTarget.transform.position) > stoppingDistance)
                    {
                        _rbThis.MovePosition(_rbThis.transform.position + dir * speed * Time.fixedDeltaTime);
                    }
                    else if (Vector3.Distance(_rbThis.transform.position, _playerTarget.transform.position) < retreatDistance)
                    {
                        _rbThis.MovePosition(_rbThis.transform.position + dir * -speed * Time.fixedDeltaTime);
                    }
                }
            }
        }
        else if (_playerTarget == null)
        {
            return;
        }
    }

    public void TakeDamage(int damage)
    {
        if (enemyType == EnemyType.BlackEnemy)
        {
            _animTakeDamage.Play("BlackEnemyAnimTakeDamage");
        }
        else
        {
            _animTakeDamage.Play();
        }
            
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemyType == EnemyType.BlackEnemy)
            {
                soundEffector.Play_BlackEnemyExplosionSound();
                _playerScript.health -= damage;
                _animGiveDamage.SetTrigger("shke");
                _playerScript._animTakeDamage.Play();
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if(enemyType == EnemyType.RedEnemy || enemyType == EnemyType.PurpleEnemy)
            {
                if (timeBtwAttack <= 0)
                {
                    _playerScript.health -= damage;
                    _animGiveDamage.SetTrigger("shke");
                    _playerScript._animTakeDamage.Play();
                    timeBtwAttack = startTimeBtwAttack;
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeBtwAttack = timeBtwAttack / 3f;
        }
    }

    private void CoinRandom()
    {
        int rand = Random.Range(1, 100);

        if (enemyType == EnemyType.BlackEnemy)
        {
            if (rand >= 98)
            {
                Instantiate(diamondCoin, transform.position, Quaternion.identity);
            }
        }
        else if (enemyType == EnemyType.RedEnemy)
        {
            if (rand >= 96)
            {
                Instantiate(diamondCoin, transform.position, Quaternion.identity);
            }
        }
        else if (enemyType == EnemyType.OrangeEnemy)
        {
            if (rand >= 96)
            {
                Instantiate(diamondCoin, transform.position, Quaternion.identity);
            }

        }
        else if (enemyType == EnemyType.PurpleEnemy)
        {
            if (rand >= 99)
            {
                Instantiate(diamondCoin, transform.position, Quaternion.identity);
            }
        }
    }


}
