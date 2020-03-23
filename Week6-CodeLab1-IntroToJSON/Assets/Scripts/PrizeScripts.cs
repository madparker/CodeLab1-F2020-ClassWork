using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeScripts : MonoBehaviour
{
    AudioSource audio; //Sound to play

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //if something enters this trigger
    {
        audio.Play(); //play the sound
        GetComponent<Renderer>().enabled = false; //stop drawing it
        Invoke("DelayDestroy", 2.7f); //in 2.7 seconds, call DelayDestroy
    }

    void DelayDestroy(){
        Destroy(gameObject); //Destroy this objects
    }
}
