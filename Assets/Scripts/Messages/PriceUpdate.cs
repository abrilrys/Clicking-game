using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class PriceUpdate : Message
{
    public double price;
    public int id;
    public PriceUpdate(double price, int id)
    {
        this.price = price;
        this.id = id;
    }
}
