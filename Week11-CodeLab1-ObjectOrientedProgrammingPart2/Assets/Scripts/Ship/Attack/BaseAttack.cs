using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    GameObject bullet;

    void Start()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet"); //get the bullet prefab from the resources dir
    }

    //virtual fire function that will be overridden by subclasses
    public virtual void Fire(Vector2 position){
        GameObject newBullet = Instantiate<GameObject>(bullet); //create a new bullet prefab
        position.y += 1;
        newBullet.transform.position = position; //put the bullet just above the position passed
        newBullet.GetComponent<Rigidbody2D>().gravityScale *= -1; //make the bullet go up
    }
}
