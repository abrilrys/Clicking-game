using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class CoinsUpgrade : MonoBehaviour
{
    int upgrades = 0;
    int amount;
    int count;
    public int upgradeCost = 10;
    double price = 10f;
    public float multiplier = 1.07f;
    public int coinsPerSec = 1;
    public int id = -1;

    void Start()
    {
        Message.AddListener<Upgrade>(coinspersec);
        // Message.Send(new RegisterUpgrade(gameObject.GetInstanceID(), price));
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
