using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;


public class CoinsDown : Message
{
    public double count;
    public CoinsDown(double count)
    {
        this.count = count;
    }
}
