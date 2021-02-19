using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleCoinsUpgrade : MonoBehaviour
{    
    double upgrades = 0;
    double amount;
    int count;
    public int baseCost;
    public float multiplier;
    public double price;
    
   public int id;


    void Awake()
    {
        
        print("my id is " + id + " \n " + gameObject.name);
        Message.AddListener<Upgrade>(OnUpgrade);
        Message.AddListener<Upgrade>(coinspersec);        
        

    }
    void Start() {
        price = (double)baseCost;
        Message.Send(new RegisterUpgrade(id, price));
        Message.Send(new PriceUpdate(price, id));

    }
    void OnUpgrade(Upgrade msg)
    {
       
        if (msg.id == id)
        {
            amount = msg.upgrade;
            count += (int)amount;
            price = baseCost * System.Math.Pow(multiplier, count);
            price = (int)price;            
            Message.Send(new PriceUpdate(price, id));
        }
    }

    void coinspersec(Upgrade msg)
    {
        if (msg.id == 15 && msg.id== id)
            {
                amount = 0.1;
                if (upgrades == 0)
                {
                    InvokeRepeating("coins", 1f, 1f);
                }
                upgrades += amount;

            }
        else if (msg.id == 100 && msg.id==id)
        {
            amount = 0.5;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 500 && msg.id == id)
        {
            amount = 4;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 3000 && msg.id == id)
        {
            amount = 10;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 10000 && msg.id == id)
        {
            amount = 40;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 40000 && msg.id == id)
        {
            amount = 100;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 200000 && msg.id == id)
        {
            amount = 400;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 4000 && msg.id == id)
        {
            amount = 6666;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 5000 && msg.id == id)
        {
            amount = 98765;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 6000 && msg.id == id)
        {
            amount = 999999;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 7000 && msg.id == id)
        {
            amount = 10000000;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
    }
      

    void coins()
    {
        Message.Send(new CoinsUp(upgrades));
    }
}
