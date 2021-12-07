using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbRotationControl : MonoBehaviour
{
    public Transform center;
    public float speed;

    private void Update()
    {
        center.transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
