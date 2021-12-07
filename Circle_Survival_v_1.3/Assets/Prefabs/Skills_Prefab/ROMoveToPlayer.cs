using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROMoveToPlayer : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if (player != null)
            transform.position = Vector2.MoveTowards(transform.position, player.position, 20f * Time.deltaTime);
        else if (player == null)
            return;
    }
}
