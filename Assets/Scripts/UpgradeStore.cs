using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class UpgradeStore : MonoBehaviour
{
    public int count = 0;
    int amount=0;
    Dictionary<int, int> upgrades = new Dictionary<int, int>();
    
    void Start()
    {
        Message.AddListener<Upgrade>(OnUpgrade);
       
    }
    //register upgrade event
    //add upgrade to dictionary "upgrades"
    
    public void OnUpgrade(Upgrade msg)
    {
        //check to see if upgrade is in dictionary
        amount = msg.upgrade;
        count += amount;
    }

    //save
    //save current upgrade dictionary status

    //load
    //load current upgrade dictionary status

    //multiplayer 
    //sync dictionary status for new clients
    
}
