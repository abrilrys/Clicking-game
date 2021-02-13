using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class UpgradeStore : MonoBehaviour
{
    public int count = 0;
    int amount=0;
    int upgradeCost = 10;
    double price = 0f;
    int upgrades = 0;
    float multiplier = 1.07f;
    
    void Start()
    {
        Message.AddListener<Upgrade>(OnUpgrade);
       
    }
    public void OnUpgrade(Upgrade msg)
    {
        amount = msg.upgrade;
        count += amount;
        price = upgradeCost * System.Math.Pow(multiplier, count);
        Message.Send(new PriceUpdate(price));
    }
    
}
