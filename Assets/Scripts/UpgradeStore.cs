using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class UpgradeStore : MonoBehaviour
{ 
    int id;
    double price;
    Dictionary<int, double> upgrades = new Dictionary<int, double>();
    
    void Start()
    {
        Message.AddListener<Upgrade>(OnUpgrade);
        Message.AddListener<RegisterUpgrade>(OnRegisterUpgrade);
    }
    ////register upgrade event
    //add upgrade to dictionary "upgrades"
    public void OnRegisterUpgrade(RegisterUpgrade msg)
    {
        id = msg.id;
        price = msg.price;
        upgrades.Add(id, price);
    }
    public void OnUpgrade(Upgrade msg)
    {
        //if (upgrades.ContainsKey(id))
        //{//check to see if upgrade is in dictionary
        //    amount = msg.upgrade;
        //    count += amount;
        //    msg.id = id;
        //}
        
    }

    //save
    //save current upgrade dictionary status

    //load
    //load current upgrade dictionary status

    //multiplayer 
    //sync dictionary status for new clients
    
}
