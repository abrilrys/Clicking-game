using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text message;

    public float add;

    void Start()
    {
        CoinsStore.OnCoinsUpdate += UpdateCoinCount;
    }

    void UpdateCoinCount(int count)
    {
        print (count);
        message.text = count + " coins";
    }

    public void RequestCoinsUp()
    {
        CoinsStore.invokeCoinsUp();
    }

    //void TaskOnClick()
    //{
    //    print("pressed");
    //    add -= 50;
    //    add += pointsincreasedpersec * Time.deltaTime;
    //    message.text = (int)add + " coins";
    //}
}
