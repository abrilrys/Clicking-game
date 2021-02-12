using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;

public class CoinsUp : Message
{
    public int amount;
    public CoinsUp(int amount)
    {
        this.amount = amount;
    }
}

public class CoinsStore : MonoBehaviour
{
    public delegate void CoinsDown(int count);

    public static event CoinsDown OnCoinsDown;

    public int coinCoint = 0;

    void Awake()
    {
        Message.AddListener<CoinsUp>(OnCoinsUp);
        //Message.AddListener<CoinsUpdate>(OnCoinsUpdate);

    }
   void OnDestroy()
   {
       Message.RemoveListener<CoinsUp>(OnCoinsUp);
       //Message.RemoveListener<CoinsUpdate>(OnCoinsUpdate);

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

    public static void invokeCoinsDown(int count)
    {
        OnCoinsDown (count);
    }

    void OnEnable()
    {
        
        CoinsStore.OnCoinsDown += SelfCoinsDown;
    }

  

    void SelfCoinsDown(int count)
    {
        coinCoint = coinCoint - count;
        Message.Send(new CoinsUpdate(coinCoint));
    }
}
