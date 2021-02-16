using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class RegisterUpgrade : Message
{
  
    public int id;
    public double price;
    public RegisterUpgrade(int id, double price)
    {
       
        this.id = id;
        this.price = price;
    }
}
