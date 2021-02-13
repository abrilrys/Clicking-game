using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class Upgrade : Message
{
    public int upgrade;
    public Upgrade(int upgrade)
    {
        this.upgrade = upgrade;
    }
}

public class Price: Message
{
    public double price;
    public Price(double price)
    {
        this.price = price;
    }
}
public class UpgradeStore : MonoBehaviour
{
    public int count = 0;
    int amount;
    int upgradeCost = 10;
    double price = 0f;
    int upgrades = 0;
    float multiplier = 1.07f;
    
    void Awake()
    {
        Message.AddListener<Upgrade>(OnUpgrade);
    }
    void OnDestroy()
    {
        Message.RemoveListener<Upgrade>(OnUpgrade);
    }


    public void OnUpgrade(Upgrade msg, Price msg2)
    {
        amount = msg.upgrade;
        count += amount;
        price = upgradeCost * System.Math.Pow(multiplier, amount);
        msg2.price = price;
    }
    
}
