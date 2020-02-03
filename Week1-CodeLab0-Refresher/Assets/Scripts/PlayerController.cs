using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 5;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() //setup
    {
        Debug.Log("Hello, World!");

        rb = GetComponent<Rigidbody2D>();

        //rb.AddForce(Vector2.right * force);
    }

    // Update is called once per frame
    void Update() //draw
    {
        Debug.Log("Goodbye, World!");

        if(Input.GetKey(KeyCode.W)){
            rb.AddForce(Vector2.up * force);
        }

        if(Input.GetKey(KeyCode.S)){
            rb.AddForce(Vector2.down * force);
        }

        if(Input.GetKey(KeyCode.A)){
            rb.AddForce(Vector2.left * force);
        }

        if (Input.GetKey(KeyCode.D)) //if D is pressed
        {
            rb.AddForce(Vector2.right * force); //apply a force using the "force" var
        }
    }
}
