using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class HandleCoinsUp : Message
{
    public float amount;
    public HandleCoinsUp(float amount)
    {
        this.amount = amount;
    }
}
