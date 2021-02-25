using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;

public class CoinsUp : Message
{
    public float amount;
    public CoinsUp(float amount)
    {
        this.amount = amount;
    }
}
