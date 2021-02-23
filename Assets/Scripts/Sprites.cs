using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class Sprites : MonoBehaviour
{
    public GameObject sprite1;
    public int id;
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


        if (msg.id == id)
        {
           
            Instantiate(sprite1, new Vector2(x, y), Quaternion.identity);
            Message.Send(new TextAppear(id, x, y));
        }
       
    }
}
