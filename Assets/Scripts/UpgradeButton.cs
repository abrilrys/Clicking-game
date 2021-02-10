using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text message1;
    public float add;
  
    public float pointsincreasedpersec1;




    

    public void Coinspersec()
    {
        add=GameObject.Find("Canvas").GetComponent<Coins>().add;
        add -=50;
        InvokeRepeating("coins", 1f, 1f);
        message1.text = (int)add + "  coins";
        GameObject.Find("Canvas").GetComponent<Coins>().add= add;

        
    }
    void coins()
    {
        add+= 1;
    }
}
