using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerRotation : MonoBehaviour
{
    public GunType gunType;

    public float offset;
    public GameObject bullet;
    public Joystick joystick;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public enum GunType {Default, Enemy}

    private float rotZ;
    private Vector3 difference;

    private PlayerControl player;

    [Header("AutoShotSKill")]
    public Transform[] autoShotPoints;
    private float AutoShot;
    public float nextAutoShot;
    [HideInInspector] public int pumpingSkill;

    private SoundEffector soundEffector;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        soundEffector = FindObjectOfType<SoundEffector>();

        if (player.controlType == PlayerControl.ControlType.PC && gunType == GunType.Default)
        {
            joystick.gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        if (gunType == GunType.Default)
        {
            if (player.controlType == PlayerControl.ControlType.PC)
            {
                difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            }
            else if (player.controlType == PlayerControl.ControlType.Android && Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
            {
                rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            }
        }
        else if(gunType == GunType.Enemy)
        {
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }
       



        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && player.controlType == PlayerControl.ControlType.PC || gunType == GunType.Enemy)
            {
                Shoot();
            }
            else if (player.controlType == PlayerControl.ControlType.Android)
            {
                if(joystick.Horizontal !=0 || joystick.Vertical != 0)
                {
                    Shoot();
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        AutoShotSkill();
    }

    public void Shoot()
    {

        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        soundEffector.Play_playerShotSound();
        timeBtwShots = startTimeBtwShots;
    }

    public void AutoShotSkill()
    {
        if (Time.time > AutoShot)
        {
            soundEffector.Play_playerAutoShotSound();
            AutoShot = Time.time + nextAutoShot;
            for (int i = 0; i < pumpingSkill; i++)
            {
                
                Instantiate(bullet, autoShotPoints[i].position, autoShotPoints[i].rotation);
            }
        }
    }
}
