using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDamageShield : BaseShield
{

    //override base AdjustDamage, does half damage instead
    public override float AdjustDamage(float damage)
    {
        return damage/2f;
    }
}
