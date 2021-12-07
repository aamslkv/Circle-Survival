using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{00:00}:{1:00}", minutes, seconds);
        timerText.text = textTime;

    }
}
