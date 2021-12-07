using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private float spawnRate;

    private int id;
    private float RandX;
    private float RandY;
    private Vector2 whereToSpawn;
    private float nextSpawn = 0.0f;
    private Transform player;

    public GameObject boss;

    private PlayerControl _playerScript;
    private EnemyControlScript[] _enemyFindObject;

    public int maxEnemy;
    public int EnemyCount;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerScript = FindObjectOfType<PlayerControl>();
    }

    private void CountEnemy()
    {
        _enemyFindObject = FindObjectsOfType<EnemyControlScript>();
        EnemyCount = _enemyFindObject.Length;
        
    }

    private void Update()
    {

        boss = GameObject.FindGameObjectWithTag("Boss");

        CountEnemy();

        if (_playerScript != null)
        {
            if (EnemyCount <= maxEnemy)
            {
                if (_playerScript.level == 1)
                {
                    maxEnemy = 60;
                    spawnRate = 1.00f;
                }
                else if (_playerScript.level == 2)
                {
                    maxEnemy = 70;
                    spawnRate = 0.90f;
                }
                else if (_playerScript.level == 3)
                {
                    maxEnemy = 80;
                    spawnRate = 0.80f;
                }
                else if (_playerScript.level == 4)
                {
                    maxEnemy = 90;
                    spawnRate = 0.70f;
                }
                else if (_playerScript.level == 5)
                {
                    maxEnemy = 100;
                    spawnRate = 0.60f;
                }
                else if (_playerScript.level == 6)
                {
                    maxEnemy = 110;
                    spawnRate = 0.50f;
                }
                else if (_playerScript.level == 7)
                {
                    maxEnemy = 120;
                    spawnRate = 0.40f;
                }
                else if (_playerScript.level == 8)
                {
                    maxEnemy = 130;
                    spawnRate = 0.30f;
                }
                else if (_playerScript.level == 9)
                {
                    maxEnemy = 140;
                    spawnRate = 0.25f;
                }
                else if (_playerScript.level == 10)
                {
                    maxEnemy = 150;
                    spawnRate = 0.20f;
                }

                if (Time.time > nextSpawn)
                {
                    int rand = Random.Range(1, 1000);

                    if (rand < 848)
                    {
                        id = 0;
                    }
                    else if (rand >= 848 && rand < 850)
                    {
                        if (boss == null && _playerScript.level >= 4)
                            id = 3;
                        else
                            id = 2;
                    }
                    else if (rand >= 850 && rand < 930)
                    {
                        id = 1;
                    }
                    else if (rand >= 930)
                    {
                        id = 2;
                    }

                    nextSpawn = Time.time + spawnRate;

                    RandX = Random.Range(-17.0f, 17.0f);
                    RandY = Mathf.Sqrt(Mathf.Pow(17.0f, 2) - Mathf.Pow(RandX, 2));
                    RandY = Random.Range(-RandY, RandY);

                    whereToSpawn = new Vector2(RandX, RandY);


                    if (player != null)
                    {
                        if (Vector2.Distance(player.position, whereToSpawn) < 10f)
                        {
                            do
                            {
                                RandX = Random.Range(-17.0f, 17.0f);
                                RandY = Mathf.Sqrt(Mathf.Pow(17.0f, 2) - Mathf.Pow(RandX, 2));
                                RandY = Random.Range(-RandY, RandY);

                                whereToSpawn = new Vector2(RandX, RandY);

                            } while (Vector2.Distance(player.position, whereToSpawn) < 10f);

                            if (Vector2.Distance(player.position, whereToSpawn) > 10f)
                            {
                                Instantiate(Enemies[id], whereToSpawn, Quaternion.identity);
                            }
                        }
                        else if (Vector2.Distance(player.position, whereToSpawn) > 10f)
                        {
                            Instantiate(Enemies[id], whereToSpawn, Quaternion.identity);
                        }
                    }
                    else if (player == null)
                    {
                        return;
                    }

                }
            }
            else if (EnemyCount >= maxEnemy)
            {
                return;
            }
        }
    }
}