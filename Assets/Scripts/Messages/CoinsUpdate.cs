using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;

public class CoinsUpdate : Message
{
    public float count;
    public CoinsUpdate(float count)
    {
        this.count = count;
    }
}
