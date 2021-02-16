using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class CoinsUpgrade : MonoBehaviour
{
    public Text message;
    int upgrades = 0;
    int amount;
    int count;
    public int upgradeCost;
    public float multiplier;
    double price;
    
    int id;

    void Start()
    {
        Message.AddListener<Upgrade>(coinspersec);
        Message.AddListener<Upgrade>(coinspersec2);
        Message.AddListener<Upgrade>(OnUpgrade1);
        Message.AddListener<Upgrade>(OnUpgrade2);
        Message.Send(new RegisterUpgrade(gameObject.GetInstanceID(), price));
    
    BuyUpgrade variable = GetComponent<BuyUpgrade>();
        upgradeCost = variable.upgradeCost;
        multiplier= variable.multiplier;
    }
    void OnUpgrade1(Upgrade msg)
    {
        id = msg.id;
        if (id == 1)
        {
            amount = msg.upgrade;
            count += amount;
            price = upgradeCost * System.Math.Pow(multiplier, count);
            price = (int)price;
            message.text = "Cost " + price.ToString() + " coins";
            Message.Send(new PriceUpdate(price));


        }
    }
    void OnUpgrade2(Upgrade msg)
        {
            id = msg.id;
            if (id == 2)
            {
                amount = msg.upgrade;
                count += amount;
                price = upgradeCost * System.Math.Pow(multiplier, count);
                price = (int)price;
                message.text = "Cost " + price.ToString() + " coins";
                Message.Send(new PriceUpdate(price));


            }
        }

 void coinspersec(Upgrade msg)
    {
        id = msg.id;
        if (id == 1)
        {
            amount = msg.upgrade;
            if (upgrades == 0)
            {
                InvokeRepeating("coins", 1f, 1f);
            }
            upgrades += amount;
        }
    }

    
            
  void coinspersec2(Upgrade msg)
    {
        id = msg.id;
        if (id == 2)
        {
            amount = msg.upgrade;
        if (upgrades == 0)
        {
            InvokeRepeating("coins", 1000f, 1f);
        }
        upgrades += amount;
        }
    }
      

    void coins()
    {
        Message.Send(new CoinsUp(upgrades));
    }
}
