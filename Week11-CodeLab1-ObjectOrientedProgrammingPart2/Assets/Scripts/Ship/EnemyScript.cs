using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bullet; //prefab for a bullet

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 1, 1); //call "Fire" every second
    }

    void Fire(){
        GameObject newBullet = Instantiate<GameObject>(bullet); //create a new bullet prefab
        Vector2 newPos = transform.position; 
        newPos.y -= 1f;
        newBullet.transform.position = newPos; //put the bullet below the enemy
    }
}
