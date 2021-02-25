using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class Sprites : MonoBehaviour
{
    public GameObject sprite1;
    public int id;
    int counter;
    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;
    int y;
    int x;
    void Awake()
    {
        

        Message.AddListener<SpriteSpawn>(spawnsprite);
        if (PlayerPrefs.HasKey("spritescounter" + id.ToString()))
        {
            counter = PlayerPrefs.GetInt("spritescounter" + id.ToString());
        }
        for(int i=0; i < counter; i++)
        {
            x = (int)Random.Range(BorderLeft.position.x, BorderRight.position.x);
            y = (int)Random.Range(BorderBottom.position.y, BorderTop.position.y);
            Instantiate(sprite1, new Vector2(x, y), Quaternion.identity);
        }
    }

    void spawnsprite(SpriteSpawn msg)
    {
        x=(int)Random.Range(BorderLeft.position.x, BorderRight.position.x);
        y=(int)Random.Range(BorderBottom.position.y, BorderTop.position.y);


        if (msg.id == id)
        {

            Instantiate(sprite1, new Vector2(x, y), Quaternion.identity);
            counter++;
            PlayerPrefs.SetInt("spritescounter" + id.ToString(), counter) ;
            PlayerPrefs.Save();
            Message.Send(new TextAppear(id, x, y));
        }
       
    }
}
