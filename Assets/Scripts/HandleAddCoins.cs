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
    float amount;
    
    void Start()
    {
        amount = 1;
        if (PlayerPrefs.HasKey("amountcoinsup"))
            amount = PlayerPrefs.GetFloat("amountcoinsup");
        if (PlayerPrefs.HasKey("totalcounter"))
            totalcounter = PlayerPrefs.GetInt("totalcounter");
        TotalCounter.text = totalcounter.ToString();
        Message.AddListener<CoinsUpdate>(UpdateCoinCount);
        Message.AddListener<HandleCoinsUp>(ChangeAmount);
    }

    void UpdateCoinCount(CoinsUpdate msg)
    {
        count = msg.count;
       
        string shortScaleNum = PolyLabs.ShortScale.ParseFloat(count);
        message.text = shortScaleNum;
    }
    public void ChangeAmount(HandleCoinsUp msg)
    {
        amount = msg.amount;
        PlayerPrefs.SetFloat("amountcoinsup", amount);
        PlayerPrefs.Save();
    }
    public void RequestCoinsUp()
    {
        Message.Send(new CoinsUp(amount));
        
        totalcounter++;
        PlayerPrefs.SetInt("totalcounter", totalcounter);
        PlayerPrefs.Save();
        TotalCounter.text = totalcounter.ToString();
        Message.Send(new TextAppear(1,1,1));
        
    }


   
        
}
