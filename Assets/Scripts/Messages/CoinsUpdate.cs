using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeControl;

public class CoinsUpdate : Message
{
    public int count;
    public CoinsUpdate(int count)
    {
        this.count = count;
    }
}
