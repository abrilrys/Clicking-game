﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class CoinsUpgrade : MonoBehaviour
{
    int upgrades = 0;
    int amount;
    void Start()
    {
        Message.AddListener<Upgrade>(coinspersec);
    }

    public void coinspersec(Upgrade msg )
    {
        amount = msg.upgrade;
        if (upgrades == 0)
        {
            InvokeRepeating("coins", 1f, 1f);
        }
        upgrades += amount;
    }

    void coins()
    {
        Message.Send(new CoinsUp(upgrades));
    }
}
