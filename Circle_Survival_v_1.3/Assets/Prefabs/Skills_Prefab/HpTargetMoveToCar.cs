using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpTargetMoveToCar : MonoBehaviour
{
    private Transform player;
    private Vector3 dir;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

       dir = new Vector3(0, 0.75f, 0);
    }

    private void Update()
    {
        //transform.position = player.position + dir;
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position + dir, 3.5f * Time.deltaTime);
        }
        else if (player == null)
        {
            return;
        }
    }
}
