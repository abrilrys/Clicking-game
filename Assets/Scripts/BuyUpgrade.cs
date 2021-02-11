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
