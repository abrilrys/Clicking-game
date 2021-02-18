using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class UpgradeStore : MonoBehaviour
{ 
    Dictionary<int, double> upgrades = new Dictionary<int, double>();
    
    void Awake() {
        //Message.AddListener<Upgrade>(OnUpgrade);
        Message.AddListener<RegisterUpgrade>(OnRegisterUpgrade);
    }
    void Start()
    {

    }
    ////register upgrade event
    //add upgrade to dictionary "upgrades"
    public void OnRegisterUpgrade(RegisterUpgrade msg)
    {
        upgrades.Add(msg.id, msg.price);
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
    
}
