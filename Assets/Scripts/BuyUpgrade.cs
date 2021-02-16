using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class BuyUpgrade : MonoBehaviour
{
    public Button UpgradeButtonButton;
    int count;
    public float multiplier = 1.07f;
    public int upgradeCost = 10;
    double price;
    public int id = -1;
    

    void Start()
    {
        if (id == -1) {
            Debug.LogError("Yoooo this upgrade needs an id!!!");
        }
        price = (float)upgradeCost;
        Message.AddListener<CoinsUpdate>(OnCoinsUpdate);
        Message.AddListener<PriceUpdate>(OnPriceUpdate);
   
    }

    public void trybuyUpdate()
    {
        Message.Send(new CoinsDown(price));
        Message.Send(new Upgrade(1, id));
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
