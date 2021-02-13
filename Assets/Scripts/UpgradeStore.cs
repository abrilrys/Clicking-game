using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class Upgrade : Message
{
    public int upgrade;
    public Upgrade(int upgrade)
    {
        this.upgrade = upgrade;
    }
}
public class UpgradeStore : MonoBehaviour
{
    public int count = 0;
    int amount;
    void Awake()
    {
        Message.AddListener<Upgrade>(OnUpgrade);
    }
    void OnDestroy()
    {
        Message.RemoveListener<Upgrade>(OnUpgrade);
    }


    public void OnUpgrade(Upgrade msg)
    {
        amount = msg.upgrade;
        count += amount;
        print("upgrade count! " + count);
    }
}
