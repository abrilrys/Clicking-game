using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class BuyUpgrade : MonoBehaviour
{
    public Button UpgradeButtonButton;
    int count, amount;
    double price;
    void Start()
    {
        Message.AddListener<CoinsUpdate>(OnCoinsUpdate);
        Message.AddListener<PriceUpdate>(OnPriceUpdate);
        Message.AddListener<Upgrade>(OnUpgrade);
    }

    public void trybuyUpdate(int count)
    {
        //try to buy coints
        //reduce coins count by cost
        Message.Send(new CoinsDown(count));

        //increase upgrade count
        Message.Send(new Upgrade(1));
    }
    void OnUpgrade(Upgrade msg)
    {
        amount = msg.upgrade;
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
        if (amount == 0)
        {
            if (count < 10)
            {
                UpgradeButtonButton.interactable = false;
            }
            else
            {
                UpgradeButtonButton.interactable = true;
            }
        }
        else
        {
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
}
