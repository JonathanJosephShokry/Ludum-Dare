using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text timerText;
    private bool running = true;
    private float startTime;
    private string min;
    private string sec;


    void Start()
    {
        timerText = GetComponent<Text>();
        StartTimer();
    }


    void StartTimer()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if(!running)
        {
            return;
        }
        float t = Time.time - startTime;

         min = ((int)t / 60).ToString();
         sec = (t % 60).ToString("f2");


        timerText.text = min + ":" + sec;
    }

    public string Stopp()
    {
        running = false;
        return timerText.text;
    }

    public string Min()
    {
        return min;
    }

    public string Sec()
    {
        return sec;
    }
}
