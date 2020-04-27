using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : BaseAttack
{
    //overridden fire function for triple shot
    public override void Fire(Vector2 position)
    {
        //middle shot
        base.Fire(position);

        //left shot
        Vector2 pos = position;
        pos.x -= 0.5f;
        base.Fire(pos);

        //right shot
        pos = position;
        pos.x += 0.5f;
        base.Fire(pos);
    }
}
