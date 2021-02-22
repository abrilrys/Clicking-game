using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class RandomTexts : MonoBehaviour
{
    public Text Text1;
    public Text upgrade;
    public GameObject Canvas;
    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;

    int chance = 40;
    int chancegained;
  
    void Awake()
    {
        Message.AddListener<TextAppear>(EnableText);
    }
   
    public void EnableText(TextAppear msg)
    {
        chancegained = Random.Range(0, 100);
        int x = msg.x;
        int y = msg.y;
        int x2= (int)Random.Range(BorderLeft.position.x, BorderRight.position.x);
        int y2 = (int)Random.Range(BorderBottom.position.y, BorderTop.position.y);
        if (msg.id== 1)
        {
            if (chancegained >= 0 && chancegained<=5)
            {
                Text1.text = "YAAY!";
            }
            else if (chancegained > 5 && chancegained <= 10)
            {
                Text1.text = "WOOJOO!";           
            }
            else if (chancegained > 10 && chancegained <= 15)
            {
                Text1.text = "COINSSS!";         
            }
            else if (chancegained > 15 && chancegained <= 20)
            {
                Text1.text = "YEEES!";         
            }

            if (chancegained >= 0 && chancegained <= 40)
            {
                Text clone = Instantiate(Text1, new Vector2(x2, y2), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }

        }
        if (msg.id == 15)
        {

            if (chancegained > chance)
            {
                upgrade.text = "Click!";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 100)
        {

            if (chancegained > chance)
            {
                upgrade.text = "Let's goo!";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 500)
        {

            if (chancegained > chance)
            {
                upgrade.text = "To the moon";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 3000)
        {

            if (chancegained > chance)
            {
                upgrade.text = "Keep mining";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 10000)
        {
            if (chancegained > chance)
            {
                upgrade.text = "go go go";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 40000)
        {
            if (chancegained > chance)
            {
                upgrade.text = "GOOO";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 200000)
        {
            if (chancegained > chance)
            {
                upgrade.text = "RICH";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 4000)
        {
            if (chancegained > chance)
            {
                upgrade.text = "10/10";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 5000)
        {
            if (chancegained > chance)
            {
                upgrade.text = "GOD";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 6000)
        {
            if (chancegained > chance)
            {
                upgrade.text = "WOOW";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
        else if (msg.id == 7000)
        {
            if (chancegained > chance)
            {
                upgrade.text = "Very very rich";
                Text clone = Instantiate(upgrade, new Vector2(x, y), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }
        }
    }
}
