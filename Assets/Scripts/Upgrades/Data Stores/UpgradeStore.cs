using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
using System;
using System.Linq;

public class UpgradeStore : MonoBehaviour
{
    Dictionary<int, double> upgrades = new Dictionary<int, double>();

    float amount;

    void Awake() {
        Message.AddListener<RegisterUpgrade>(OnRegisterUpgrade);
        InvokeRepeating("HandleCalculateCoinsUp", 1f, 1f);
    }

    public void OnRegisterUpgrade(RegisterUpgrade msg)
    {
        if (!upgrades.ContainsKey(msg.id))
        {
            upgrades.Add(msg.id, msg.price);
        }
        if (upgrades.ContainsKey(msg.id))
        {
            upgrades[msg.id] = msg.price;
        }

        print("\nAll the keys..\n");
        foreach (KeyValuePair<int, double> kvp in upgrades)
        {
            print("Key = {" + kvp.Key + "} Value = {" + kvp.Value + "}");
           
            
        }
        amount = (float)upgrades.Sum(x => x.Value);
        print("Total amount is: " + amount);
    }

    void HandleCalculateCoinsUp()
    {
        print("Coins going up are: " + amount);
        Message.Send(new CoinsUp(amount));
    }
    
}
    

