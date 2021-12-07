using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostsTimer : MonoBehaviour
{
    public GameObject boostsTimerGO;
    public Image boostsTimer;
    public BoostManager boostsManager;

    public Sprite[] boostsImages;

    void Start()
    {
        //bosstsTimer.GetComponent<Image>().image = boostsImages[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(boostsManager.doubleDamageTime > 0)
        {
            boostsTimerGO.SetActive(true);
            boostsTimer.fillAmount = boostsManager.doubleDamageTime / 10;
            boostsTimer.GetComponent<Image>().sprite = boostsImages[0];
        }
        else if (boostsManager.reloadTime > 0)
        {
            boostsTimerGO.SetActive(true);
            boostsTimer.fillAmount = boostsManager.reloadTime / 10;
            boostsTimer.GetComponent<Image>().sprite = boostsImages[1];
        }
        else if (boostsManager.shieldTime > 0)
        {
            boostsTimerGO.SetActive(true);
            boostsTimer.fillAmount = boostsManager.shieldTime / 10;
            boostsTimer.GetComponent<Image>().sprite = boostsImages[2];
        }

        if (boostsTimer.fillAmount <= 0.01)
            boostsTimerGO.SetActive(false);
    }
}
