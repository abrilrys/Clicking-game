using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;


public class CoinsStore : MonoBehaviour
{

    public int coinCoint = 0;
    int count;
    void Awake()
    {
        Message.AddListener<CoinsUp>(OnCoinsUp);
        Message.AddListener<CoinsDown>(OnCoinsDown);
    }
   void OnDestroy()
   {
       Message.RemoveListener<CoinsUp>(OnCoinsUp);
        Message.RemoveListener<CoinsDown>(OnCoinsDown);
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
}
