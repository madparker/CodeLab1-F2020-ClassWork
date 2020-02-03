using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 5; //public var for force amount

    Rigidbody2D rb; //var for the Rigidbody2D

    // Start is called before the first frame update
    void Start() //setup
    {
        Debug.Log("Hello, World!"); //print "Hello, World!" to console

        rb = GetComponent<Rigidbody2D>(); //get the Rigidbody2D  off of this gameObject

        //rb.AddForce(Vector2.right * force);
    }

    // Update is called once per frame
    void Update() //draw
    {
        Debug.Log("Goodbye, World!"); //print "Goodbye, World!" to console

        if (Input.GetKey(KeyCode.W))//if W is pressed
        {
            rb.AddForce(Vector2.up * force); //apply to the up mult by the "force" var
        }

        if(Input.GetKey(KeyCode.S))//if S is pressed
        {
            rb.AddForce(Vector2.down * force); //apply to the down mult by the "force" var
        }

        if(Input.GetKey(KeyCode.A))//if A is pressed
        { 
            rb.AddForce(Vector2.left * force); //apply to the left mult by the "force" var
        }

        if (Input.GetKey(KeyCode.D)) //if D is pressed
        {
            rb.AddForce(Vector2.right * force); //apply to the right mult by the "force" var
        }
    }
}
