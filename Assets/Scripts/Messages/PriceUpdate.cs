using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class PriceUpdate : Message
{
    public double price;
    public PriceUpdate(double price)
    {
        this.price = price;
    }
}
