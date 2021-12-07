using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickSize : MonoBehaviour
{
    public GameObject joystickFire, joystickMove;

    void Start()
    {
        if (PlayerPrefs.GetInt("JoystickValue") == 0)
        {
            joystickFire.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            joystickMove.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (PlayerPrefs.GetInt("JoystickValue") == 1)
        {
            joystickFire.transform.localScale = new Vector3(1, 1, 1);
            joystickMove.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (PlayerPrefs.GetInt("JoystickValue") == 2)
        {
            joystickFire.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            joystickMove.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
    }
}
