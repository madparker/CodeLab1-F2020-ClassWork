using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectShield : BaseShield
{
    int reflectNum = 5;

    public override float AdjustDamage(float damage)
    {
        if(reflectNum > 0){
            reflectNum--;

            GameObject newBullet = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Bullet"));
            Vector2 newPos = transform.position;
            newPos.y += 1;
            newBullet.transform.position = newPos;
            newBullet.GetComponent<Rigidbody2D>().gravityScale *= -1;

            return 0;
        } else {
            return damage;
        }
    }
}
