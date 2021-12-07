using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelControl : MonoBehaviour
{
    private GameObject player;
    

    public GameObject orbOne;
    public GameObject orbTwo;
    public GameObject orbThree;
    public GameObject orbFour;

    public Image progressSkillBar_1;
    public Image progressSkillBar_2;
    public Image progressSkillBar_3;


    public GameObject levelText;
    public GameObject skillPointText;

    [HideInInspector] public float skillPoint_1;
    [HideInInspector] public float skillPoint_2;
    [HideInInspector] public float skillPoint_3;

    private bool down = false;

    private Animation skill_panelUpDown;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        skill_panelUpDown = gameObject.GetComponent<Animation>();

    }

    public void Update()
    {
        if (player != null)
        {
            skillPointText.GetComponent<Text>().text = "Skill points : " + player.GetComponent<PlayerControl>().skillPoint.ToString();
            levelText.GetComponent<Text>().text = "Level : " + player.GetComponent<PlayerControl>().level.ToString();



            if (player.GetComponent<PlayerControl>().skillPoint > 0)
            {
                skill_panelUpDown.Play("CanvasAnimUp");
                down = true;
            }
            else if ((player.GetComponent<PlayerControl>().skillPoint == 0) && (down == true))
            {
                skill_panelUpDown.Play("CanvasAnimDown");
                down = false;
            }
        }
        else if (player == null)
        {
            return;
        }
    }


    public void SkillButton1()
    {
        if ((player.GetComponent<PlayerControl>().skillPoint > 0) && (skillPoint_1 < 3))
        {
            player.GetComponent<PlayerControl>().skillPoint--;

            skillPoint_1++;

            if (skillPoint_1 == 1)
            {
                orbOne.SetActive(true);
            }
            else if (skillPoint_1 == 2)
            {
                orbTwo.SetActive(true);
            }
            else if (skillPoint_1 == 3)
            {
                orbThree.SetActive(true); 
                orbFour.SetActive(true);
            }
            progressSkillBar_1.fillAmount = skillPoint_1 / 3f;
        }
    }

    public void SkillButton2()
    {
        if ((player.GetComponent<PlayerControl>().skillPoint > 0) && (skillPoint_2 < 3))
        {
            player.GetComponent<PlayerControl>().skillPoint--;

            skillPoint_2++;

            if (skillPoint_2 == 1)
            {
                player.GetComponent<PointerRotation>().pumpingSkill = 2;
            }
            else if (skillPoint_2 == 2)
            {
                player.GetComponent<PointerRotation>().pumpingSkill = 4;
                player.GetComponent<PointerRotation>().nextAutoShot = 1f * 0.8f;
            }
            else if (skillPoint_2 == 3)
            {
                player.GetComponent<PointerRotation>().pumpingSkill = 9;
                player.GetComponent<PointerRotation>().nextAutoShot = 0.8f * 0.8f;

            }
            progressSkillBar_2.fillAmount = skillPoint_2 / 3f;
        }
    }

    public void SkillButton3()
    {
        if ((player.GetComponent<PlayerControl>().skillPoint > 0) && (skillPoint_3 < 3))
        {
            player.GetComponent<PlayerControl>().skillPoint--;

            skillPoint_3++;

            if (skillPoint_3 == 1)
            {
                player.GetComponent<FireRainControl>().spawnRate = 1.5f ;
            }
            else if (skillPoint_3 == 2)
            {
                player.GetComponent<FireRainControl>().spawnRate = 1f;
            }
            else if (skillPoint_3 == 3)
            {
                player.GetComponent<FireRainControl>().spawnRate = 0.375f;

            }
            progressSkillBar_3.fillAmount = skillPoint_3 / 3f;
        }
    }
}
