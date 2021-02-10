using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text message1;

    public float add;

    public Button UpgradeButtonButton;

    public float pointsincreasedpersec1;

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

    public void Coinspersec()
    {
        add = GameObject.Find("Canvas").GetComponent<Coins>().add;
        add -= 10;
        InvokeRepeating("coins", 1f, 1f);

        //message1.text = (int) add + "  coins";
        GameObject.Find("Canvas").GetComponent<Coins>().add = add;
    }

    void coins()
    {
        CoinsStore.invokeCoinsUp();
    }
}
