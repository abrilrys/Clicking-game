using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class Upgrade : Message
{
    public int upgrade;
    public int id;
    public Upgrade(int upgrade, int id)
    {
        this.upgrade = upgrade;
        this.id = id;
    }
}
