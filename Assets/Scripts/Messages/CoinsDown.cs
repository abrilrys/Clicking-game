using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;


public class CoinsDown : Message
{
    public float count;
    public CoinsDown(float count)
    {
        this.count = count;
    }
}
