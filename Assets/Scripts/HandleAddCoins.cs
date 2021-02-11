using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleAddCoins : MonoBehaviour
{
    public Text message;

    void Start()
    {
        CoinsStore.OnCoinsUpdate += UpdateCoinCount;
    }

    void UpdateCoinCount(int count)
    {
        print(count);
        message.text = count + " coins";
    }

    public void RequestCoinsUp()
    {
        CoinsStore.invokeCoinsUp();
    }
}
