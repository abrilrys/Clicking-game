using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUpgrade : MonoBehaviour
{
    public void Coinspersec(int count)
    {
       
        InvokeRepeating("coins", 1f, 1f);
       
    }
    void coins()
    {
        CoinsStore.invokeCoinsUp();
    }


}
