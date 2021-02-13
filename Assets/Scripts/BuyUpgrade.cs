using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class BuyUpgrade : MonoBehaviour
{
    public Button UpgradeButtonButton;
    int count;
    double price;
    void Start()
    {
        Message.AddListener<CoinsUpdate>(CanHasUpgrade);
        Message.AddListener<Price>(CanHasUpgrade);
    }

    public void trybuyUpdate(int count)
    {
        //try to buy coints
        //reduce coins count by cost
        Message.Send(new CoinsDown(count));

        //increase upgrade count
        Message.Send(new Upgrade(1));
    }

    void CanHasUpgrade(CoinsUpdate msg, Price msg2)
    {
        price = msg2.price;
        count = msg.count;
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
