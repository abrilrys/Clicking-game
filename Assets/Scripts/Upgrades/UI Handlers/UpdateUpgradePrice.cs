using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class UpdateUpgradePrice : MonoBehaviour
{
    Text UpgradePrice;
    double price;
    public int id = -1;
    void Awake() {
        Message.AddListener<PriceUpdate>(OnPriceUpdate);
        UpgradePrice = gameObject.GetComponent<Text>();
    }
    void Start()
    {
        
        if (UpgradePrice == null)
        {
            Debug.LogError("Yooooo this needs to be attached to a gameObject with a text component");
        }
        if (id == -1)
        {
            Debug.LogError("This UpdateUpgradePrice doesn't have a designated text field that it should Update");
        }
        
    }
    void OnPriceUpdate(PriceUpdate msg)
    {
        if (msg.id != id) {
            return;
        }
        price = msg.price;
        UpgradePrice.text = "Cost " + price.ToString() + " coins";

    }
}
