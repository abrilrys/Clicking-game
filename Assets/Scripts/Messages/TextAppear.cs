using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class TextAppear : Message
{
    public int id;
    public int x;
    public int y;
    public TextAppear(int id,int x, int y)
    {
        this.id = id;
        this.x = x;
        this.y = y;
        
    }
}
