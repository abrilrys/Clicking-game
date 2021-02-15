using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class BuyUpgrade : MonoBehaviour
{
    public Button UpgradeButtonButton;
    int count, amount;
    int upgradeCost = 10;
    double price = 10f;
    float multiplier = 1.07f;
    double countdown;
    public Text message;
    

    void Start()
    {
        Message.AddListener<CoinsUpdate>(OnCoinsUpdate);
        Message.AddListener<PriceUpdate>(OnPriceUpdate);
        Message.AddListener<Upgrade>(OnUpgrade);
    }

    public void trybuyUpdate()
    {
        Message.Send(new CoinsDown(price));
        Message.Send(new Upgrade(1));
    }
    void OnUpgrade(Upgrade msg)
    {
        amount = msg.upgrade;
        count += amount;
        price = upgradeCost * System.Math.Pow(multiplier, count);
        price = (int)price;
        message.text = "Cost " + price.ToString() + " coins";
        Message.Send(new PriceUpdate(price));
    }
    void OnCoinsUpdate(CoinsUpdate msg)
    {
      count = msg.count;
        CanHasUpgrade();
    }
    void OnPriceUpdate(PriceUpdate msg)
    {
        price = msg.price;
        CanHasUpgrade();
    }

    void CanHasUpgrade()
    {
        print(count+ "," + price);
            if (count < price)
            {
                UpgradeButtonButton.interactable = false;
            }
            else
            {
                UpgradeButtonButton.interactable = true;
            }
        }
    
}
