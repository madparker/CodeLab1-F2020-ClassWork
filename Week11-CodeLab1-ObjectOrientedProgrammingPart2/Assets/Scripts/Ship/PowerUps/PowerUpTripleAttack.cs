using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTripleAttack : PowerUpBase
{
    //override base upgrade, replace base shot w/ Triple shot
    public override void Upgrade(GameObject ship)
    {
        print("Upgrade: Triple Attack");

        ShipControl sc = ship.GetComponent<ShipControl>(); //get ship controllers
        Destroy(sc.attack); //remove base attack
        sc.attack = ship.AddComponent<TripleShot>(); //add triple shot
    }
}
