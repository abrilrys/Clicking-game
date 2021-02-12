using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class Substractcoins : MonoBehaviour
{
   
    public void RequestCoinsDown(int count)
    {
        CoinsStore.invokeCoinsDown(count);
    }
}
