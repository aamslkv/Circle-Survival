using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] Boosts;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRate50;

    private int id;
    private float RandX;
    private float RandY;
    private Vector2 whereToSpawn;
    private float nextSpawn = 0.0f;
    private float nextSpawnAid = 0.0f;
    private Transform player;

    private PlayerControl _playerScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerScript = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        if (_playerScript.health <= 35)
        {
            if (Time.time > nextSpawnAid)
            {

                RandX = Random.Range(-19.0f, 19.0f);
                RandY = Mathf.Sqrt(Mathf.Pow(19.0f, 2) - Mathf.Pow(RandX, 2));
                RandY = Random.Range(-RandY, RandY);

                whereToSpawn = new Vector2(RandX, RandY);

                if (Vector2.Distance(player.position, whereToSpawn) < 1f)
                {
                    print("не спавни, сука");
                }
                else if (Vector2.Distance(player.position, whereToSpawn) > 1f)
                {
                    Instantiate(Boosts[4], whereToSpawn, Quaternion.identity);
                }

                nextSpawnAid = Time.time + spawnRate50;
            }
        }

        if (Time.time > nextSpawn)
        {
            int rand = Random.Range(0, 1000);

            if (rand <= 250)
            {
                id = 0;
            }
            else if ((rand > 250) && (rand <= 500))
            {
                id = 1;
            }
            else if ((rand > 500) && (rand <= 750))
            {
                id = 2;
            }
            else if (rand > 750)
            {
                id = 3;
            }

            nextSpawn = Time.time + spawnRate;

            RandX = Random.Range(-19.0f, 19.0f);
            RandY = Mathf.Sqrt(Mathf.Pow(19.0f, 2) - Mathf.Pow(RandX, 2));
            RandY = Random.Range(-RandY, RandY);

            whereToSpawn = new Vector2(RandX, RandY);



            if (Vector2.Distance(player.position, whereToSpawn) < 1f)
            {
                print("не спавни, сука");
            }
            else if (Vector2.Distance(player.position, whereToSpawn) > 1f)
            {
                Instantiate(Boosts[id], whereToSpawn, Quaternion.identity);
            }
        }
    }
}