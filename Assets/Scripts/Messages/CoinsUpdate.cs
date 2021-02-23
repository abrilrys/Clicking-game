using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;

public class CoinsUpdate : Message
{
    public double count;
    public CoinsUpdate(double count)
    {
        this.count = count;
    }
}
