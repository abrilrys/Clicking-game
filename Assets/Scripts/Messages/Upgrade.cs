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
