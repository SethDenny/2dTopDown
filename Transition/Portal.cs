using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collidable
{
    public int level;
    public LevelChanger levelchanger;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {

            levelchanger.level = level;
            levelchanger.nextScene = true;
        }
    }
}
