using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    ShuffleBag<string> bag;

    public int numHits = 3;
    public int numMisses = 3;

    public Text buttonText;
    public Text attackText;

    public string prevResult = "";

    public int streak = 0;

    public bool useBag = true;

    float successChance;

    // Start is called before the first frame update
    void Start()
    {
        successChance = (numHits / (float)(numHits + numMisses));

        buttonText.text = "Attack! (" +
            successChance * 100 + 
            "% chance of success)";

        bag = new ShuffleBag<string>();

        for (int i = 0; i < numHits; i++)
        {
            bag.Add("Hit!");
        }

        for (int i = 0; i < numMisses; i++)
        {
            bag.Add("Miss!");
        }

        print(bag.Count);
    }

    public void Attack()
    {

        print("Attack! " + successChance);
        string result = "";

        if (useBag)
        {
            print("Here!");
            result = bag.Next();
        }
        else
        {
            result = "Miss!";

            float rando = Random.Range(0f, 1f);

            print("random num: " + rando);

            if (rando <= successChance)
            {
                result = "Hit!";
            }
        }

        if (prevResult == result)
        {
            streak++;
        }
        else
        {
            streak = 1;
        }

        prevResult = result;

        attackText.text = "Attack Result :" + result + "\nStreak: " + streak;
    }
}
