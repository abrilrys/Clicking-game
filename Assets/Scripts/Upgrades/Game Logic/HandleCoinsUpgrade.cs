using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleCoinsUpgrade : MonoBehaviour
{    
    double upgrades = 0;
    int upgrade;
    public double amount;
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
            upgrade = msg.upgrade;
            count += upgrade;
            price = baseCost * System.Math.Pow(multiplier, count);
            price = (int)price;            
            Message.Send(new PriceUpdate(price, id));
            Message.Send(new SpriteSpawn(id));
            Message.Send(new RegisterUpgrade(id, price));
        }
    }

    void coinspersec(Upgrade msg)
    {
        if (msg.id == 15 && msg.id== id)
        {
                if (upgrades == 0)
                {
                    InvokeRepeating("coins", 1f, 1f);
                }
                upgrades += amount;
            
        }
        else if (msg.id == 100 && msg.id==id)
        {
            
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 500 && msg.id == id)
        {
        
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 3000 && msg.id == id)
        { 
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 10000 && msg.id == id)
        {
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 40000 && msg.id == id)
        {
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 200000 && msg.id == id)
        {
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 4000 && msg.id == id)
        {
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 5000 && msg.id == id)
        {
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 6000 && msg.id == id)
        { 
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
        else if (msg.id == 7000 && msg.id == id)
        {
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
