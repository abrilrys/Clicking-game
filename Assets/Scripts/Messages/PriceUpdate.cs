using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class PriceUpdate : Message
{
    public float price;
    public int id;
    public int option;
    public PriceUpdate(float price, int id)
    {
        this.price = price;
        this.id = id;
       
    }
}
