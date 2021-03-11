using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleCoinsUpgrade : MonoBehaviour
{

    protected float upgrades;
    public float amount;
    int upgrade;
    public int percentage;
    int count;
    int count2;
    public int baseCost;
    public float multiplier;
    float price;
    float price2;

    int x = 1;
    public int id;

    public enum Upgrades { CoinsPerSec, Percentage };
    public Upgrades upgradetype;

    void Awake()
    {
        Message.AddListener<Upgrade>(OnUpgrade);
        Message.AddListener<Upgrade>(chooseupgrade);


        if (PlayerPrefs.HasKey("upgrades" + id.ToString()))
            upgrades = PlayerPrefs.GetFloat("upgrades" + id.ToString());

        if ( upgradetype == Upgrades.CoinsPerSec)
            Message.Send(new RegisterUpgrade(id, upgrades));
        

        if (PlayerPrefs.HasKey("amount" + id.ToString()))
            amount = PlayerPrefs.GetInt("amount" + id.ToString());

        if (PlayerPrefs.HasKey("count" + id.ToString()))
            count = PlayerPrefs.GetInt("count" + id.ToString());

        if (PlayerPrefs.HasKey("count2" + (id + 1).ToString()))
            count2 = PlayerPrefs.GetInt("count2" + (id + 1).ToString());

        if (PlayerPrefs.HasKey("percentage" + id.ToString()))
            percentage = PlayerPrefs.GetInt("percentage" + id.ToString());


    }
    void Start()
    {
        if (upgradetype == Upgrades.CoinsPerSec)
            price = (float)baseCost;


        else if (upgradetype == Upgrades.Percentage)
        {
            price2 = (float)baseCost;
        }
        
        if (PlayerPrefs.HasKey("price2" + (id + 1).ToString()))
            price2 = PlayerPrefs.GetFloat("price2" + (id + 1).ToString());

        
        if (PlayerPrefs.HasKey("price" + id.ToString()))
            price = PlayerPrefs.GetFloat("price" + id.ToString());


        if (upgradetype == Upgrades.CoinsPerSec)
        {
            Message.Send(new PriceUpdate(price, id));
        }

        else if (upgradetype == Upgrades.Percentage)
        {
            Message.Send(new PriceUpdate(price2, (id + 1)));
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
            
        }

        else if (msg.id == id && upgradetype == Upgrades.Percentage)
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
            
        }

    }

    void chooseupgrade(Upgrade msg)
    {
        if (msg.id == id && upgradetype == Upgrades.CoinsPerSec)
        {
            coinspersecs upgraders = new coinspersecs();
            upgraders.amount = amount;
            upgraders.upgrades = upgrades;
            upgraders.procedure(id);
            upgraders.startaddingCoins(id);
        }
        else if (msg.id == id && upgradetype == Upgrades.Percentage && msg.id == 2)
        {
            id1 upgraders = new id1();
            upgraders.amount = amount;
            upgraders.upgrades = upgrades;
            upgraders.percentage = percentage;
            upgraders.procedure(id);

        }
        else if (msg.id == id && upgradetype == Upgrades.Percentage && msg.id != 2)
        {
            percentages upgraders = new percentages();
            upgraders.upgrades = upgrades;
            upgraders.percentage = percentage;
            upgraders.procedure(id);
            upgraders.startaddingCoins(id - 1);
        }

    }

    class upgrader
    {
        public float upgrades;
        public void startaddingCoins(int id)
        {
            Message.Send(new RegisterUpgrade(id, upgrades));
        }
    }

    class coinspersecs : upgrader
    {
        public float amount;
        public void procedure(int id)
        {
            upgrades = upgrades + amount;
            Message.Send(new RegisterUpgrade(id, upgrades));
            PlayerPrefs.SetFloat("upgrades" + id.ToString(), upgrades);
            PlayerPrefs.Save();
        }
    }
    class percentages : upgrader
    {
        public int percentage;
        public void procedure(int id)
        {
            
            upgrades += (percentage * upgrades / 100);
            
            PlayerPrefs.SetFloat("upgrades" + (id-1).ToString(), upgrades);
            PlayerPrefs.Save();

            percentage += 5;
            PlayerPrefs.SetFloat("percentage" + (id - 1).ToString(), percentage);
            PlayerPrefs.Save();
        }
    }
    class id1 : upgrader
    {
        public float amount;
        public int percentage;
        public void procedure(int id)
        {
            upgrades = upgrades + amount;
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
    }



   

   
}


