using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class HandleUpgradesUpgrade : MonoBehaviour
{
    float upgrades;
    int upgrade;
    public float amount;
    int count;
    public int baseCost;
    public float multiplier;
    public float price;
    public int id;


    void Awake()
    {

        print("my id is " + id + " \n " + gameObject.name);
        Message.AddListener<Upgrade>(OnUpgrade);
        Message.AddListener<Upgrade>(coinspersec);


        if (PlayerPrefs.HasKey("upgrades" + (id-1).ToString()))
        {
            upgrades = PlayerPrefs.GetFloat("upgrades" + (id-1).ToString());

        }
        if (PlayerPrefs.HasKey("amount" + id.ToString()))
        {
            amount = PlayerPrefs.GetFloat("upgrades" + id.ToString());

        }
        if (PlayerPrefs.HasKey("count" + id.ToString()))
            count = PlayerPrefs.GetInt("count" + id.ToString());

    }
    void Start()
    {
        price = (float)baseCost;
        if (PlayerPrefs.HasKey("price" + id.ToString()))
            price = PlayerPrefs.GetFloat("price" + id.ToString());
        if (upgrades > 0)
            InvokeRepeating("coins", 1f, 1f);

        Message.Send(new RegisterUpgrade(id, price));
        Message.Send(new PriceUpdate(price, id));

    }
    void OnUpgrade(Upgrade msg)
    {

        if (msg.id == id)
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
    }

    void coinspersec(Upgrade msg)
    {
        if (msg.id == id)
        {
            upgrades+=(amount*upgrades/ 100);
            PlayerPrefs.SetFloat("upgrades" + (id-1).ToString(), upgrades);
            PlayerPrefs.Save();
            amount += 5;
            PlayerPrefs.SetFloat("amount" + id.ToString(), upgrades);
            PlayerPrefs.Save();
        }

    }

}
