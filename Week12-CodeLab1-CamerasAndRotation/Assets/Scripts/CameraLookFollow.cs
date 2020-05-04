using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a thing that looks at stuff (ideally, a camera)
// PURPOSE: this will make the thing look at a thing, forever

//More info on Quaternions:
//Unity Quaternions: https://unity3d.com/learn/tutorials/modules/intermediate/scripting/quaternions
//General Quaternions: http://quaternions.online/index.html

public class CameraLookFollow : MonoBehaviour
{
    public Transform lookTarget; // what I should look at; assign in Inspector!
    public float timeMod = 0.1f;

    void Update()
    {
        // bug fix after we worked on RaycastButton.cs: if "lookTarget" does not exist, then don't do anything
        if ( lookTarget == null ) { // "null" means like "empty"
            return; // "return" means skip the rest of this function and stop
        }

        //// technique 1: use "LookAt"... very simple, but very basic
        //transform.LookAt( lookTarget );

        // technique 2: use Quaternions to make the thing look at the thing
        Vector3 forward = lookTarget.position - transform.position; // line from A to B = B-A
        // calculate quaternion based on the forward vector desired
        Quaternion targetRotation = Quaternion.LookRotation( forward );
        // change the rotation based on quaternions...

        // FOR A MORE MECHANICAL FEEL, LIKE A SECURITY CAMERA
        // rotate towards the object at a rate of 30 degrees per second
        //transform.rotation = Quaternion.RotateTowards( transform.rotation, targetRotation, 30 * Time.deltaTime * timeMod);

        // FOR A MORE ORGANIC FEEL, eases out / dampens / accelerates
        transform.rotation = Quaternion.Slerp( transform.rotation, targetRotation, Time.deltaTime * timeMod);

        // Visualize the line from this gameObject to lookTarget in debug Scene view
        Debug.DrawLine(transform.position, lookTarget.position, Color.red);
    }
}
