using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedShield : BaseShield {

    //override base AdjustDamage, does double damage instead
    public override float AdjustDamage(float damage){
	    return damage * 2;
    }
}
