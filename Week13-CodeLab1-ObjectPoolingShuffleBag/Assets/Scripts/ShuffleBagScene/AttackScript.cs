using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    ShuffleBag<string> bag; //the shufflebag

    public int numHits = 3; //num of hits
    public int numMisses = 3; //num of misses

    public Text buttonText; //button text
    public Text attackText; //attack display

    public string prevResult = ""; //previous result

    public int streak = 0; //how happened in a row

    public bool useBag = true; //use the bag or not?

    float successChance; //% chance of success

    // Start is called before the first frame update
    void Start()
    {
        //calc successChance
        successChance = (numHits / (float)(numHits + numMisses));

        //Update button text
        buttonText.text = "Attack! (" +
            successChance * 100 + 
            "% chance of success)";

        bag = new ShuffleBag<string>(); //create the shuffle bag

        for (int i = 0; i < numHits; i++) //put the hits in the bag
        {
            bag.Add("Hit!");
        }

        for (int i = 0; i < numMisses; i++) //put the misses in the bag
        {
            bag.Add("Miss!");
        }

        print(bag.Count); //print how many things are the bag
    }


    public void Attack()
    {
        string result = ""; //var for result

        if (useBag) //if we're using the bag
        {
            result = bag.Next(); //get the next result from the bag
        }
        else //otherwise
        {
            result = "Miss!"; //make the result a miss

            float rando = Random.Range(0f, 1f); //get random float between 0-1

            print("random num: " + rando); //print random num

            if (rando <= successChance) //if the random num is lower than success %
            {
                result = "Hit!"; //change to a hit
            }
        }

        if (prevResult == result) //if the result is the same as the last one
        {
            streak++; //increase streak
        }
        else //otherwise
        {
            streak = 1; //reset streak
        }

        prevResult = result; //set prevResult to the new result

        attackText.text = "Attack Result :" + result + "\nStreak: " + streak; //update display
    }
}
