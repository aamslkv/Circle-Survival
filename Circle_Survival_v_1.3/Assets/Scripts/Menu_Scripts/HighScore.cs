using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public GameObject HigtScore;
    private int Hscore;

    void Start()
    {
        Hscore = PlayerPrefs.GetInt("SaveScore");

        HigtScore.GetComponent<Text>().text = "Higt Score: \n " + Hscore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
