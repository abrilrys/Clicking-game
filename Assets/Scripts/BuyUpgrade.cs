using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    public Button UpgradeButtonButton;

    void Start()
    {
        CoinsStore.OnCoinsUpdate += CanHasUpgrade;
    }

    public void trybuyUpdate(int count)
    {
        //try to buy coints
        //reduce coins count by cost
        CoinsStore.invokeCoinsDown (count);

        //increase upgrade count
        UpgradeStore.invokeUpgrade(1);
    }

    void CanHasUpgrade(int count)
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
}
