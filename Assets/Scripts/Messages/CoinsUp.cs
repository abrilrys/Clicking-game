using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;

public class CoinsUp : Message
{
    public double amount;
    public CoinsUp(double amount)
    {
        this.amount = amount;
    }
}
