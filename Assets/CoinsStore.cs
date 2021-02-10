using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsStore : MonoBehaviour
{
    public int coinCoint = 0;

    public delegate void CoinsUp();

    public static event CoinsUp OnCoinsUp;

    public delegate void CoinsUpdate(int count);

    public static event CoinsUpdate OnCoinsUpdate;

    // public class CoinUpdateArgs : EventArgs
    // {
    //     public int count;
    //     CoinUpdateArgs(int count)
    //     {
    //         this.count = count;
    //     }
    // }
    public static void invokeCoinsUp()
    {
        OnCoinsUp();
    }

    void OnEnable()
    {
        OnCoinsUp += SelfCoinsUp;
    }

    void SelfCoinsUp()
    {
        coinCoint++;
        if (OnCoinsUpdate == null)
        {
            print("event not assigned");
            return;
        }
        OnCoinsUpdate (coinCoint);
    }
}
