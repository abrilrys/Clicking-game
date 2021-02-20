using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class CoinsStore : MonoBehaviour
{
  
    public Text textClock;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    double coinCoint = 0;
    double count;
    void Awake()
    {
        Message.AddListener<CoinsUp>(OnCoinsUp);
        Message.AddListener<CoinsDown>(OnCoinsDown);
    }
   
    void TestCoins()
    {
        Message.Send(new CoinsUp(1));
    }


    void OnCoinsUp(CoinsUp msg)
    {
        coinCoint += msg.amount;
        Message.Send(new CoinsUpdate(coinCoint));
    }

    void OnCoinsDown(CoinsDown msg)
    {
        count = msg.count;
        coinCoint = coinCoint - count;
        Message.Send(new CoinsUpdate(coinCoint));
    }
  
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
