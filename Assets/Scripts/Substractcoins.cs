﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Substractcoins : MonoBehaviour
{
    public Text message1;

    public int add;

    public Button UpgradeButtonButton;

    public float pointsincreasedpersec1;

    public void Coinspersec(int count)
    {
        add = count;
        add -= 10;
       
        count = add;
    }
   
    
   
}
