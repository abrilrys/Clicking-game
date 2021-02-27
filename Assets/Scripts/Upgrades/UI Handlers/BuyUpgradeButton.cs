using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class BuyUpgradeButton : MonoBehaviour
{
    Button UpgradeButtonButton;
    float coins;
    public int option;
    public float price;
    public int id = -1;

    void Awake() {
        Message.AddListener<CoinsUpdate>(OnCoinsUpdate);
        Message.AddListener<PriceUpdate>(OnPriceUpdate);
        UpgradeButtonButton = gameObject.GetComponent<Button>();
    }
    void Start()
    {
        print("Buy Upgrade " + name + " Checkin in");
        if (UpgradeButtonButton == null) {
            Debug.LogError("Yooooo this needs to be attached to a button");
        }
        if (id == -1)
        {
            Debug.LogError("This Buy Upgrade doesn't have a designated upgrade that it should buy");
        }        
      
        //default this to disabled. 
        UpgradeButtonButton.interactable = false;
   
    }

    public void trybuyUpdate()
    {
        Message.Send(new CoinsDown(price));
        Message.Send(new Upgrade(1, id,option));

    }

    void OnCoinsUpdate(CoinsUpdate msg)
    {
        coins = msg.count;
        CanHasUpgrade();
    }
    void OnPriceUpdate(PriceUpdate msg)
    {
        if (msg.id != id) { return; }
        print("Price for id:" + msg.id + " set!");
        price = msg.price;
        CanHasUpgrade();
    }

    void CanHasUpgrade()
    {        
            if (coins < price)
            {
                UpgradeButtonButton.interactable = false;
            }
            else
            {
                UpgradeButtonButton.interactable = true;
            }
        }
    
}
