using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float xRange = 8;
    public float speed = 5;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Reset();
    }

    public void Reset()
    {
        transform.position = new Vector2(
            Random.Range(-xRange, xRange),
            10f);

        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
