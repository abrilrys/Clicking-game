using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class UpdateUpgradePrice : MonoBehaviour
{
    Text UpgradePrice;
        public int id = -1;
    void Awake() {
        
        UpgradePrice = gameObject.GetComponent<Text>();
        Message.AddListener<PriceUpdate>(OnPriceUpdate);
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
        print("price came from: " + msg.id + "for id: " + id);
        if (msg.id != id) {
            return;
        }
        
        UpgradePrice.text = "Cost " + msg.price.ToString() + " coins";

    }
}
