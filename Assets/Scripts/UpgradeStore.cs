using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;
public class UpgradeStore : MonoBehaviour
{
    public int count = 0;

    public delegate void Upgrade(int upgrade);

    public static event Upgrade OnUpgrade;

    public void Start()
    {
        OnUpgrade += UpgradeUp;
    }

    public void UpgradeUp(int amount)
    {
        count += amount;
        print("upgrade count! " + count);
    }

    public static void invokeUpgrade(int upgrade)
    {
        if (OnUpgrade != null) OnUpgrade(upgrade);
    }
}
