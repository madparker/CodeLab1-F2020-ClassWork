using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHalfDamage : PowerUpBase
{
    //override base powerup, add half damage shield
    public override void Upgrade(GameObject ship)
    {
        print("Upgrade: Half Damage");

        ShipControl sc = ship.GetComponent<ShipControl>();
        Destroy(sc.shield);
        sc.shield = ship.AddComponent<HalfDamageShield>();
    }
}
