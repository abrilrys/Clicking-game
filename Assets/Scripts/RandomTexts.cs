using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;


public class RandomTexts : MonoBehaviour
{
    public int id;
    public Text Text1;
    public GameObject upgrade;

    public GameObject Canvas;
    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;
    TextMesh textObject;

    int chance = 40;
    int chancegained;
  
    void Awake()
    {
        Message.AddListener<TextAppear>(EnableText);
       
        
    }
    void Start()
    {
        textObject = upgrade.GetComponent<TextMesh>();
    }

    public void EnableText(TextAppear msg)
    {

        int x2 = (int)Random.Range(BorderLeft.position.x, BorderRight.position.x);
        int y2 = (int)Random.Range(BorderBottom.position.y, BorderTop.position.y); 

        chancegained = Random.Range(0, 100);
  
       
       
        if (msg.id == id && msg.id == 1)
        {
            if (chancegained >= 0 && chancegained <= 5)
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

            if (chancegained >= 0 && chancegained <= chance)
            {
                Text clone = Instantiate(Text1, new Vector2(x2, y2), Quaternion.identity) as Text;
                clone.transform.SetParent(Canvas.transform, false);
                Destroy(clone, 1.0f);
            }

        }
        else if (msg.id == id)
        {
    
            if (chancegained > chance)
            {
                switch (id)
                {
                    case 15:
                        textObject.text =  "Click!";
                        break;
                    case 100:
                        textObject.text = "Let's goo!"; 
                        break;

                    case 500:
                        textObject.text = "To the moon";
                        break;
                    case 3000:
                        textObject.text = "Keep mining"; 
                        break;
                    case 10000:
                        textObject.text = "go go go";
                        break;
                    case 40000:
                        textObject.text = "GOOO";
                        break;
                    case 200000:
                        textObject.text = "RICH";
                        break;
                    case 4000:
                        textObject.text = "10/10";
                        break;
                    case 5000:
                        textObject.text = "GOD";
                        break;
                    case 6000:
                        textObject.text = "WOOW";
                        break;
                    case 7000:
                         textObject.text = "Very very rich";
                        break;
                }
                GameObject clone = Instantiate(upgrade, new Vector2(msg.x, msg.y), Quaternion.identity) as GameObject;
                Destroy(clone, 1.0f);
            }
        }
       
    }
}
