using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStore : MonoBehaviour
{
    public delegate void Upgrade(int upgrade);

    public static event Upgrade OnUpgrade;
    
    public static void invokeOnUpgrade(int upgrade)
    {
        OnUpgrade(upgrade);
    }

    public void checkupgrade(int upgrade)
    {
        if (upgrade == 0)
        {
            invokeOnUpgrade(upgrade);
        }
        upgrade++;
    }
   
}
