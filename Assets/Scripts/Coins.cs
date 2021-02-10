using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text message;
    public float add;
    public Button UpgradeButton;



    void start()
    {
        UpgradeButton.interactable = !UpgradeButton.interactable;
        
    }

    public void coinsup()
    {
       
        add++;
        message.text = (int)add + " coins";
        

    }

    void Update()
    {
        if (add < 50)
        {
            UpgradeButton.interactable = false;
        }
        else
        {
            UpgradeButton.interactable = true;
        }
    }
    //void TaskOnClick()
    //{
    //    print("pressed");
    //    add -= 50;
    //    add += pointsincreasedpersec * Time.deltaTime;
    //    message.text = (int)add + " coins";
    //}


}
