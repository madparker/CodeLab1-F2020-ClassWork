using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an object (with a collider) to make it clickable
// FUNCTION: shoot raycast based on mouse cursor to detect any colliders
public class RaycastButton : MonoBehaviour
{
    Ray myRay = new Ray();

    void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) ) {
            // STEP 1: generate a "Ray" variable
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // STEP 2: initialize a RaycastHit variable
            // "RaycastHit" is a type of variable that has more info about what it hit
            RaycastHit myRayHitInfo = new RaycastHit();

            // STEP 3: actually shoot raycast now!
            if ( Physics.Raycast( myRay, out myRayHitInfo, 1000f ) ) {
                // STEP 5: do something with the raycast!
                // actually, the way we've coded this, we can now click on ANYTHING with a collider
                // Destroy( myRayHitInfo.collider.gameObject );

                // "Translate" means "move position"
                myRayHitInfo.transform.Translate( 0f, 3f, 0f);

                // change color when I click on it
                myRayHitInfo.transform.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 1f);
            }
        }
    }

}
