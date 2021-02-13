using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;

public class CoinsUp : Message
{
    public int amount;
    public CoinsUp(int amount)
    {
        this.amount = amount;
    }
}
