using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class UpgradeStore : MonoBehaviour
{
    public int count = 0;
    int amount=0;
    
    void Start()
    {
        Message.AddListener<Upgrade>(OnUpgrade);
       
    }
    public void OnUpgrade(Upgrade msg)
    {
        amount = msg.upgrade;
        count += amount;
    }
    
}
