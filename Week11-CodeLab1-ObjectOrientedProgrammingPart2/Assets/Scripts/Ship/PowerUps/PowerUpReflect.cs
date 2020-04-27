using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpReflect : PowerUpBase
{
    public override void Upgrade(GameObject ship)
    {
        Destroy(ship.GetComponent<BaseShield>());

        ShipControl sc = ship.GetComponent<ShipControl>();

        sc.shield = ship.AddComponent<ReflectShield>();
    }
}
