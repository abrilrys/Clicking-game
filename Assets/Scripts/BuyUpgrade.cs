using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class BuyUpgrade : MonoBehaviour
{
    public Button UpgradeButtonButton;
    int count;
    void Start()
    {
        Message.AddListener<CoinsUpdate>(CanHasUpgrade);
    }

    public void trybuyUpdate(int count)
    {
        //try to buy coints
        //reduce coins count by cost
        Message.Send(new CoinsDown(count));

        //increase upgrade count
        Message.Send(new Upgrade(1));
    }

    void CanHasUpgrade(CoinsUpdate msg)
    {
        count = msg.count;
        if (count < 10)
        {
            UpgradeButtonButton.interactable = false;
        }
        else
        {
            UpgradeButtonButton.interactable = true;
        }
    }
}
