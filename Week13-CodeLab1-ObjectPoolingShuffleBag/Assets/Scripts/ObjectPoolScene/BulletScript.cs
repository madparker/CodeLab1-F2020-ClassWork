using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speedMod = 10;

    const float MAX_Y = 10;

    Rigidbody2D rb;

    private void Update()
    {
        if(transform.position.y > MAX_Y){
            BulletPool.instance.Push(gameObject);
        }
    }

    public void Reset()
    {
        if(rb == null){
            rb = GetComponent<Rigidbody2D>();
        }

        rb.velocity = Vector2.up * speedMod;

        transform.position = new Vector2(
            ShipScript.instance.transform.position.x,
            ShipScript.instance.transform.position.y + 0.5f);
    }
}
