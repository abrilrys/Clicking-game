using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeControl;

public class SpriteSpawn : Message
{
    public int id;
    public SpriteSpawn(int id)
    {
        this.id = id;
    }
}
