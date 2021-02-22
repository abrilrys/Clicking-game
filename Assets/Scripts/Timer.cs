using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class Timer : MonoBehaviour
{
    public Text textClock;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    void Update()
    {
        secondsCount += Time.deltaTime;
        textClock.text = hourCount.ToString("00") + ":" + minuteCount.ToString("00") + ":" + secondsCount.ToString("00");
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount %= 60;
            if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount %= 60;
            }
        }
    }
}
