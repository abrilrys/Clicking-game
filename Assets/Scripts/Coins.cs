using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coins : MonoBehaviour
{
    public Text message;
    private int add;

    public void coinsup()
    {
        add++;
        message.text = add.ToString();
    }
}
