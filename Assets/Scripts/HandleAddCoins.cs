using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleAddCoins : MonoBehaviour
{
    public Text TotalCounter;
    int totalcounter=0;
    public Text message;
    double count;
    void Start()
    {
        Message.AddListener<CoinsUpdate>(UpdateCoinCount);
    }

    void UpdateCoinCount(CoinsUpdate msg)
    {
        count = msg.count;
        print(count);
        message.text = count + " coins";
    }

    public void RequestCoinsUp()
    {
        Message.Send(new CoinsUp(1));
        totalcounter++;
        TotalCounter.text = totalcounter.ToString();
    }


   
        
}
