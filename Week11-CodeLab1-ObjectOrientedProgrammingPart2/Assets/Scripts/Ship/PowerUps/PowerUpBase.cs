using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    //base PowerUp, increases health by 100
    public virtual void Upgrade(GameObject ship){
        print("Upgrade: Health + 100");
        ship.GetComponent<ShipControl>().health += 100;
    }
}
