using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class BuyUpgrade : MonoBehaviour
{
    public Button UpgradeButtonButton;
    int count;
    int amount;
    public int upgradeCost = 10;
    double price = 10f;
    public float multiplier = 1.07f;
    public int coinsPerSec = 1;
    public int id = -1;
    double countdown;
    public Text message;
    

    void Start()
    {
        if (id == -1) {
            Debug.LogError("Yoooo this upgrade needs an id!!!");
        }
        price = (float)upgradeCost;
        Message.AddListener<CoinsUpdate>(OnCoinsUpdate);
        Message.AddListener<PriceUpdate>(OnPriceUpdate);
        Message.AddListener<Upgrade>(OnUpgrade);
    }

    public void trybuyUpdate()
    {
        Message.Send(new CoinsDown(price));
        Message.Send(new Upgrade(1, id));
    }
    void OnUpgrade(Upgrade msg)
    {
        if (msg.id != id) {
            return;
        }
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
