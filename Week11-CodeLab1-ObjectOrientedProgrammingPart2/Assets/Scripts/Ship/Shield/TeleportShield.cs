using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShield : BaseShield
{
    int numHits = 5;

    public override float AdjustDamage(float damage)
    {
        if(numHits > 0){
            numHits--;
            Vector2 newPos = transform.position;
            newPos.x = Random.Range(-7, 7);
            transform.position = newPos;
            return 0;
        }

        return damage;
    }
}
