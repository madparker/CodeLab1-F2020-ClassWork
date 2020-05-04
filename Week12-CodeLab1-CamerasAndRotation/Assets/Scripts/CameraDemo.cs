using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put on your Main Camera
// PURPOSE: demo some camera control techniques, 
// like simple mouse look / following a target
public class CameraDemo : MonoBehaviour
{

    bool look = true;

    public float mouseMod = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //is space is pressed
        {
            look = !look; //toggle look
            print("Look: " + look);
        }

        // simple mouse look
        if (look)
        {
            // 1. get mouse input?
            float horizontalMousePos = Input.GetAxis("Mouse X");
            float verticalMousePos = Input.GetAxis("Mouse Y");
            //Debug.Log(horizontalMousePos); // print horizontal mouse, make sure it works

            // 2. use mouse input to rotate camera
            Camera.main.transform.Rotate(-verticalMousePos * mouseMod, horizontalMousePos * mouseMod, 0f);

            // 3. unroll the camera, we need to set it's Z angle to 0f, always
            // transform.eulerAngles.z = 0f; // Unity won't let you do it like this
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                                 transform.eulerAngles.y,
                                                 0f);
        }
    }
}
