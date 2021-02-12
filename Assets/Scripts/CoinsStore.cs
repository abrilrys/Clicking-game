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

    void Awake()
    {
        Message.AddListener<CoinsUp>(OnCoinsUp);

    }
   void OnDestroy()
   {
       Message.RemoveListener<CoinsUp>(OnCoinsUp);
   }
    void TestCoins()
    {
        Message.Send(new CoinsUp(1));
    }

    void OnCoinsUp(CoinsUp msg)
    {
        coinCoint += msg.amount;
        if (OnCoinsUpdate == null)
        {
            print("event not assigned");
            return;
        }
        OnCoinsUpdate(coinCoint);
    }

    public delegate void CoinsUpdate(int count);

    public static event CoinsUpdate OnCoinsUpdate;

    


    public delegate void CoinsDown(int count);

    public static event CoinsDown OnCoinsDown;

    public int coinCoint = 0;



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
        OnCoinsUpdate (coinCoint);
    }
}
