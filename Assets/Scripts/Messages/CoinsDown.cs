using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;


public class CoinsDown : Message
{
    public int count;
    public CoinsDown(int count)
    {
        this.count = count;
    }
}
