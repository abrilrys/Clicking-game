using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleAddCoins : MonoBehaviour
{
    public Text message;

    void Start()
    {
        Message.AddListener<CoinsUpdate>(UpdateCoinCount);
    }

    void UpdateCoinCount(int count)
    {
        print(count);
        message.text = count + " coins";
    }

    public void RequestCoinsUp()
    {
        Message.Send(new CoinsUp(1));
    }
}
