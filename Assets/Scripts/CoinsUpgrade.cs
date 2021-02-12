using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUpgrade : MonoBehaviour
{
    void start()
    {
        UpgradeStore.OnUpgrade += coinspersec;
    }
    public void coinspersec(int upgrade)
    {
        InvokeRepeating("coins", 1f, 1f);
    }
    void coins()
    {
        CoinsStore.invokeCoinsUp();
    }
}
