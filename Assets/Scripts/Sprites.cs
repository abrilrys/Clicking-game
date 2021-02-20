using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class Sprites : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;
    public GameObject sprite4;
    public GameObject sprite5;
    public GameObject sprite6;
    public GameObject sprite7;
    public GameObject sprite8;
    public GameObject sprite9;
    public GameObject sprite10;
    public GameObject sprite11;

    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;
    int y;
    int x;
    void Awake()
    {
        Message.AddListener<SpriteSpawn>(spawnsprite);
    }

    void spawnsprite(SpriteSpawn msg)
    {
        x=(int)Random.Range(BorderLeft.position.x, BorderRight.position.x);
        y=(int)Random.Range(BorderBottom.position.y, BorderTop.position.y);
       
        if (msg.id == 15)
        {
           
            Instantiate(sprite1, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id == 100)
        {
          
            Instantiate(sprite2, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id == 500)
        {
           
            Instantiate(sprite3, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id == 3000)
        {
           
            Instantiate(sprite4, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id == 10000)
        {
            Instantiate(sprite5, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id ==40000)
        {
            Instantiate(sprite6, new Vector2(x, y), Quaternion.identity);
        }
         else if (msg.id == 200000)
        {
            Instantiate(sprite7, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id ==4000)
        {
            Instantiate(sprite8, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id == 5000)
        {
            Instantiate(sprite9, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id ==6000)
        {
            Instantiate(sprite10, new Vector2(x, y), Quaternion.identity);
        }
        else if (msg.id == 7000)
        {
            Instantiate(sprite11, new Vector2(x, y), Quaternion.identity);
        }


    }
}
