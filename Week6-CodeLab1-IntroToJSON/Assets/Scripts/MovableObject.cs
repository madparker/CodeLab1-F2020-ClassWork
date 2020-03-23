using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovableObject : MonoBehaviour {

    float mouseZPos; //holds the mouse position of the object
    Rigidbody rb; //holds the Rigidbody
    Collider col; //holds the Collider
    string filePath; //holds path to this objects save file

    void Start(){
        filePath = Application.dataPath + "/" + name + ".json";

        rb = GetComponent<Rigidbody>(); //get the rigidbody component
        col = GetComponent<Collider>(); //get the collider component

        if (File.Exists(filePath)) //if the save file exists
        {
            string jsonStr = File.ReadAllText(filePath); //load it as a string

            Vector3 savePos = JsonUtility.FromJson<Vector3>(jsonStr); //turn the Json into an object

            rb.MovePosition(savePos); //move the savePos
        }
    }

    void OnMouseDrag(){ //if you drag the mouse over the gameObject
        mouseZPos = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //get the Z position of the object at the screen
       
        rb.isKinematic = true; //make it uneffected by physics
        rb.MovePosition(GetMouseAsWorldPoint()); //move it to the new mouse position

        col.enabled = false; //turn off the collider
    }

    private void OnMouseUp() //if you release the mouse over the object
    {
        col.enabled = true; //trun on collisions
    }

    Vector3 GetMouseAsWorldPoint(){
        Vector3 mousePoint = Input.mousePosition; //Pixel coordinates of mouse (x,y)

        mousePoint.z = mouseZPos; //z coordinate of gameObject on screen

        return Camera.main.ScreenToWorldPoint(mousePoint);  //Convert it to world points
    }

    private void OnApplicationQuit()
    {
        string pos = JsonUtility.ToJson(transform.position, true);
        File.WriteAllText(filePath, pos);
    }
}