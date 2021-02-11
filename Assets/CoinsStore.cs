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

    public int coinCoint = 0;

    public static void invokeCoinsUp()
    {
        OnCoinsUp();
    }
    void OnEnable()
    {
        CoinsStore.OnCoinsUp += SelfCoinsUp;
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

}
