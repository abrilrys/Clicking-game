using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUpgrade : MonoBehaviour
{
    int upgrades = 0;

    void Start()
    {
        UpgradeStore.OnUpgrade += coinspersec;
    }

    public void coinspersec(int amount)
    {
        if (upgrades == 0)
        {
            InvokeRepeating("coins", 1f, 1f);
        }
        upgrades = amount;
    }

    void coins()
    {
        CoinsStore.invokeCoinsUp (upgrades);
    }
}
