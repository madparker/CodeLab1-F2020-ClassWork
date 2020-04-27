using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when the ship hits a powerup, it gets a random power up and the power
//up moves back to the start position
public class PowerUpScript : MonoBehaviour
{
    Vector2 startPos; //start pos for Powerup
    PowerUpBase[] powers; //array for all powerups

    // Start is called before the first frame update
    void Start()
    {
        //set the powers array to the array of all PowerUpBase's attached to this gameObject
        powers = GetComponents<PowerUpBase>(); 
        startPos = transform.position; //set start position to init position
    }

    private void Update()
    {
        //if the powerUp is more than 20 units from startPos (ie, off the screen)
        if (Vector3.Distance(startPos, transform.position) > 20){
            transform.position = startPos; //reset to startPos
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; //remove velocity
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObj = collision.gameObject;
        if (hitObj.name.Equals("Ship")){ //if the powerUp hit the ship
            int randomPower = Random.Range(0, powers.Length); 
            powers[randomPower].Upgrade(hitObj); //give the ship a random powerUp
        }

        transform.position = startPos; //reset to startPos
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; //remove velocity
    }
}
