using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbShield : BaseShield
{
    public override float AdjustDamage(float damage)
    {
        if(shieldStrength > damage){
            shieldStrength -= damage;
            return -damage/2;
        } else {
            return damage;
        }
    }
}
