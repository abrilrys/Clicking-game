using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleCoinsUpgrade : MonoBehaviour
{    
    float upgrades;
    int upgrade;
    public int option;
    public int percentage;
    public float amount;
    int count;
    int count2;
    public int baseCost;
    public float multiplier;
    float price;
    float price2;

    public int id;


    void Awake()
    {
        
        print("my id is " + id + " \n " + gameObject.name);
        Message.AddListener<Upgrade>(OnUpgrade);
        Message.AddListener<Upgrade>(coinspersec);
        

        if (PlayerPrefs.HasKey("upgrades" + id.ToString()))
            upgrades = PlayerPrefs.GetFloat("upgrades" + id.ToString());
        

        if (PlayerPrefs.HasKey("count" + id.ToString()))
            count = PlayerPrefs.GetInt("count" + id.ToString());

        if (PlayerPrefs.HasKey("count" + (id+1).ToString()))
            count2 = PlayerPrefs.GetInt("count" + (id+1).ToString());

        if (PlayerPrefs.HasKey("percentage" + id.ToString()))
            percentage = PlayerPrefs.GetInt("percentage" + id.ToString());
    }
    void Start() {
        if (option == 1)
            price = (float)baseCost;
        else if (option == 2)
            price2 = (float)baseCost;
        if (PlayerPrefs.HasKey("price" + id.ToString()))
            price = PlayerPrefs.GetFloat("price" + id.ToString());
        if (PlayerPrefs.HasKey("price" + (id+1).ToString()))
            price2 = PlayerPrefs.GetFloat("price" + (id+1).ToString());
        if (upgrades > 0)
            InvokeRepeating("coins", 1f, 1f);

        Message.Send(new RegisterUpgrade(id, price));
        Message.Send(new PriceUpdate(price, id));

    }
    void OnUpgrade(Upgrade msg)
    {
       
        if (msg.id == id)
        {
            if (msg.option == option && option == 1)
            {
                Message.Send(new SpriteSpawn(id));
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
            else if(msg.option == option && option == 2)
            {
                upgrade = msg.upgrade;
                count2 += upgrade;
                PlayerPrefs.SetInt("count" + (id+1).ToString(), count2);
                PlayerPrefs.Save();
                price2 = (float)(baseCost * System.Math.Pow(multiplier, count2));
                price2 = (int)price;
                PlayerPrefs.SetFloat("price" + (id+1).ToString(), price2);
                PlayerPrefs.Save();
                Message.Send(new PriceUpdate(price2, (id+1)));
                Message.Send(new RegisterUpgrade((id+1), price2));
            }
        }
    }

    void coinspersec(Upgrade msg)
    {
        if (msg.id == id)
        {
            if (msg.option == option && option==1)
            {
                if (upgrades == 0)
                {
                    InvokeRepeating("coins", 1f, 1f);
                }
                upgrades += amount;
                PlayerPrefs.SetFloat("upgrades" + id.ToString(), upgrades);
                PlayerPrefs.Save();

            }else if (msg.option == option && option == 2)
            {
                upgrades += (percentage * upgrades / 100);
                PlayerPrefs.SetFloat("upgrades" + id.ToString(), upgrades);
                PlayerPrefs.Save();
                percentage += 5;
                PlayerPrefs.SetFloat("percentage" + id.ToString(), percentage);
                PlayerPrefs.Save();
            }
        }
        
       
    }
      

    void coins()
    {
        
        Message.Send(new CoinsUp(upgrades));
    }
}
