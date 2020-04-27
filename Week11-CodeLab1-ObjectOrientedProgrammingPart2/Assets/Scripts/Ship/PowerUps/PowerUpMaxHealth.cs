using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMaxHealth : PowerUpBase
{
    public override void Upgrade(GameObject ship)
    {
        print("Upgrade: Max Health");
        ship.GetComponent<ShipControl>().health = 1000;
    }
}
