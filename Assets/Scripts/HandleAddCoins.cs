using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleAddCoins : MonoBehaviour
{
    public Text TotalCounter;
    int totalcounter;
    public Text message;
    float count;
    
    void Start()
    {

        if (PlayerPrefs.HasKey("totalcounter"))
            totalcounter = PlayerPrefs.GetInt("totalcounter");
        TotalCounter.text = totalcounter.ToString();
        Message.AddListener<CoinsUpdate>(UpdateCoinCount);
    }

    void UpdateCoinCount(CoinsUpdate msg)
    {
        count = msg.count;
        print(count);
        message.text = count.ToString("0.0") + " coins";
    }

    public void RequestCoinsUp()
    {
        Message.Send(new CoinsUp(1));
        
        totalcounter++;
        PlayerPrefs.SetInt("totalcounter", totalcounter);
        PlayerPrefs.Save();
        TotalCounter.text = totalcounter.ToString();
        Message.Send(new TextAppear(1,1,1));
        
    }


   
        
}
