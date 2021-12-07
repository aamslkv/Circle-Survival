using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireRainControl : MonoBehaviour
{
    public GameObject frSkillPrefab;
    public GameObject canvas;
    private Transform player;

    public float spawnRate;

    private float RandX;
    private float RandY;
    private Vector3 whereToSpawn;
    private float nextSpawn = 0.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (canvas.GetComponent<SkillPanelControl>().skillPoint_3 > 0)
        {


            if (Time.time > nextSpawn)
            {

                nextSpawn = Time.time + spawnRate;


                RandX = Random.Range(-3.5f, 3.5f);
                RandY = Mathf.Sqrt(Mathf.Pow(3.5f, 2) - Mathf.Pow(RandX, 2));
                RandY = Random.Range(-RandY, RandY);

                whereToSpawn = new Vector3(RandX, RandY, 0f);

                Instantiate(frSkillPrefab, player.position - whereToSpawn, Quaternion.identity);



            }
        }
    }
}
