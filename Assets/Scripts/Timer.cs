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
    void Awake()
    {
        if (PlayerPrefs.HasKey("hour"))
            hourCount = PlayerPrefs.GetInt("hour");
        if (PlayerPrefs.HasKey("second"))
            secondsCount = PlayerPrefs.GetFloat("second");
        if (PlayerPrefs.HasKey("minute"))
            minuteCount = PlayerPrefs.GetInt("minute");
    }
    void Update()
    {
        
        textClock.text = hourCount.ToString("00") + ":" + minuteCount.ToString("00") + ":" + secondsCount.ToString("00");
        secondsCount += Time.deltaTime;
        PlayerPrefs.SetFloat("second", secondsCount);
        PlayerPrefs.Save();
        if (secondsCount >= 60)
        {
            minuteCount++;
            PlayerPrefs.SetInt("minute", minuteCount);
            PlayerPrefs.Save();
            secondsCount %= 60;
            PlayerPrefs.SetFloat("second", secondsCount);
            PlayerPrefs.Save();

            if (minuteCount >= 60)
            {
                hourCount++;
                PlayerPrefs.SetInt("hour", hourCount);
                PlayerPrefs.Save();
                minuteCount %= 60;
                PlayerPrefs.SetInt("minute", minuteCount);
                PlayerPrefs.Save();
            }
        }
    }
}
