using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
using System;

public class UpgradeStore : MonoBehaviour
{ 
    Dictionary<int, double> upgrades = new Dictionary<int, double>();
    
    void Awake() {
        Message.AddListener<RegisterUpgrade>(OnRegisterUpgrade);
    }
  
    public void OnRegisterUpgrade(RegisterUpgrade msg)
    {
        if (!upgrades.ContainsKey(msg.id)) {
            upgrades.Add(msg.id, msg.price);
        }
        else if (upgrades.ContainsKey(msg.id)) {
            upgrades[msg.id] = msg.price;
        }

        print("\nAll the keys..\n");
        foreach (KeyValuePair<int, double> kvp in upgrades)
        {
            print("Key = {"+ kvp.Key + "} Value = {" +kvp.Value+ "}");
        }


    }
    
}
