using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class Upgrade : Message
{
    public int upgrade;
    public int id;
    public int option;
    public Upgrade(int upgrade, int id, int option)
    {
        this.upgrade = upgrade;
        this.id = id;
        this.option = option;
    }
}
