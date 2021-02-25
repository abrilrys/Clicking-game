using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;


public class CoinsStore : MonoBehaviour
{
  
   
    float coinCoint;
    float count;
    void Awake()
    {
        if (PlayerPrefs.HasKey("score"))
            coinCoint = PlayerPrefs.GetFloat("score");
        
        Message.AddListener<CoinsUp>(OnCoinsUp);
        Message.AddListener<CoinsDown>(OnCoinsDown);
    }

    void Start()
    {
        Message.Send(new CoinsUpdate(coinCoint));
    }
    void TestCoins()
    {
        Message.Send(new CoinsUp(1));
    }


    void OnCoinsUp(CoinsUp msg)
    {
        
        coinCoint += msg.amount;
        PlayerPrefs.SetFloat("score", coinCoint);
        PlayerPrefs.Save();
        Message.Send(new CoinsUpdate(coinCoint));

    }

    void OnCoinsDown(CoinsDown msg)
    {
        count = msg.count;
        coinCoint = coinCoint - count;
        Message.Send(new CoinsUpdate(coinCoint));
    } 
}
