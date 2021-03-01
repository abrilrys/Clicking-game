using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleCoinsUpgrade : MonoBehaviour
{    
    float upgrades;
    int upgrade;
    public int percentage;
    public float amount;
    int count;
    int count2;
    public int baseCost;
    public float multiplier;
    float price;
    float price2;
   
    int x = 1;
    public int id;
   
    public enum Upgrades {CoinsPerSec, Percentage};
    public Upgrades upgradetype;

    void Awake()
    {
        
        //print("my id is " + id + " \n " + gameObject.name);
        Message.AddListener<Upgrade>(OnUpgrade);
        Message.AddListener<Upgrade>(coinspersec);

        

        if (PlayerPrefs.HasKey("upgrades" + id.ToString()))
            upgrades = PlayerPrefs.GetFloat("upgrades" + id.ToString());
        //This line of if(upgrades>0) is still broken 
            if (upgrades > 0)
                InvokeRepeating("coins", 1f, 1f);
        
        if (PlayerPrefs.HasKey("amount" + id.ToString()))
            amount = PlayerPrefs.GetInt("amount" + id.ToString());

        if (PlayerPrefs.HasKey("count" + id.ToString()))
            count = PlayerPrefs.GetInt("count" + id.ToString());

        if (PlayerPrefs.HasKey("count2" + (id+1).ToString()))
            count2 = PlayerPrefs.GetInt("count2" + (id+1).ToString());

        if (PlayerPrefs.HasKey("percentage" + id.ToString()))
            percentage = PlayerPrefs.GetInt("percentage" + id.ToString());

       
    }
    void Start() {
        if (upgradetype == Upgrades.CoinsPerSec)
            price = (float)baseCost;


        else if (upgradetype == Upgrades.Percentage)
        {
            price2 = (float)baseCost;
        }
        print("id: " + id);
        if (PlayerPrefs.HasKey("price2" + (id+1).ToString()))
        price2 = PlayerPrefs.GetFloat("price2" + (id+1).ToString());

        print("id: " + id);
        if (PlayerPrefs.HasKey("price" + id.ToString()))
            price = PlayerPrefs.GetFloat("price" + id.ToString());

        Message.Send(new RegisterUpgrade(id, price));
        if (upgradetype == Upgrades.CoinsPerSec)
        {
            Message.Send(new PriceUpdate(price, id));
        }

        else if (upgradetype == Upgrades.Percentage)
        {
            Message.Send(new PriceUpdate(price2, (id+1)));
        }


    }
    void OnUpgrade(Upgrade msg)
    {
        if (upgradetype == Upgrades.Percentage)
            if (x == 1)
            {
                id++;
                x = 0;
            }

        if (msg.id == id && upgradetype == Upgrades.CoinsPerSec)
        {
          
                upgrade = msg.upgrade;
                count += upgrade;
                PlayerPrefs.SetInt("count" + id.ToString(), count);
                PlayerPrefs.Save();
                price = (float)(baseCost * System.Math.Pow(multiplier, count));
                price = (int)price;
                PlayerPrefs.SetFloat("price" + id.ToString(), price);
                PlayerPrefs.Save();
                Message.Send(new PriceUpdate(price, id));
                Message.Send(new RegisterUpgrade(id, price));
        }
        else if(msg.id == id && upgradetype == Upgrades.Percentage)
         {
            
          
            upgrade = msg.upgrade;
                count2 += upgrade;
                PlayerPrefs.SetInt("count2" + id.ToString(), count2);
                PlayerPrefs.Save();
            price2 = (float)(baseCost * System.Math.Pow(multiplier, count2));
            price2 = (int)price2;
            print("price 2 change: " + price2);
                PlayerPrefs.SetFloat("price2" + id.ToString(), price2);
                PlayerPrefs.Save();
                Message.Send(new PriceUpdate(price2, id));
                Message.Send(new RegisterUpgrade(id, price2));
         }
        
    }

    void coinspersec(Upgrade msg)
    {
        
       
     
        if (msg.id == id && upgradetype == Upgrades.CoinsPerSec)
        {
          
            if (upgrades == 0)
                {
                    InvokeRepeating("coins", 1f, 1f);
                }
                upgrades += amount;
                PlayerPrefs.SetFloat("upgrades" + id.ToString(), upgrades);
                PlayerPrefs.Save();

         }
        else if (msg.id == id && upgradetype == Upgrades.Percentage && msg.id==2)
         {
           
            upgrades += amount;
                PlayerPrefs.SetFloat("upgrades" + id.ToString(), upgrades);
                PlayerPrefs.Save();
                Message.Send(new HandleCoinsUp(upgrades));
                amount += (percentage * amount / 100);
                PlayerPrefs.SetFloat("amount" + id.ToString(), amount);
                PlayerPrefs.Save();
                percentage += 5;
                PlayerPrefs.SetFloat("percentage" + id.ToString(), percentage);
                PlayerPrefs.Save();
         }
        else if(msg.id == id && upgradetype == Upgrades.Percentage && msg.id!=2)
         {
            
            upgrades += (percentage * upgrades / 100);
                PlayerPrefs.SetFloat("upgrades" + (id-1).ToString(), upgrades);
                PlayerPrefs.Save();
                percentage += 5;
                PlayerPrefs.SetFloat("percentage" + (id-1).ToString(), percentage);
                PlayerPrefs.Save();
         }
            
     }
        
       
    
      

    void coins()
    {
        
        Message.Send(new CoinsUp(upgrades));
    }
}
