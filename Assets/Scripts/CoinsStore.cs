using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsStore : MonoBehaviour
{
    public delegate void CoinsUpdate(int count);

    public static event CoinsUpdate OnCoinsUpdate;


    public delegate void CoinsUp();

    public static event CoinsUp OnCoinsUp;


    public delegate void CoinsDown(int count);

    public static event CoinsDown OnCoinsDown;

    public int coinCoint = 0;

    public static void invokeCoinsUp()
    {
        OnCoinsUp();
    }
    public static void invokeCoinsDown(int count)
    {
        OnCoinsDown(count);
    }

    void OnEnable()
    {
        CoinsStore.OnCoinsUp += SelfCoinsUp;
        CoinsStore.OnCoinsDown += SelfCoinsDown;
        
    }

    void SelfCoinsUp()
    {
        coinCoint++;
        if (OnCoinsUpdate == null)
        {
            print("event not assigned");
            return;
        }
        OnCoinsUpdate(coinCoint);
    }

    void SelfCoinsDown(int count)
    {
        coinCoint = coinCoint - count;
        OnCoinsUpdate(coinCoint);
    }

}
