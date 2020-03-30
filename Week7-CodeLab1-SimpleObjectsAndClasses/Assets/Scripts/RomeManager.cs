using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RomeManager : MonoBehaviour
{
    public Text title;
    public Text description;

    public Button nButton;
    public Button sButton;
    public Button eButton;
    public Button wButton;

    int i = 0; //Keep track of even and odd moves

    public Location currentLocation;

    // Start is called before the first frame update
    void Start()
    {
        //Create a new "Location" object with the constructor
        currentLocation = new Location("ROME", "Welcome to Rome!\nAll roads lead to ROME.\nDon't believe me? Try any direction.");

        UpdateLocation();
    }

    public void LeadToRome()
    {
        print("Back to Rome!");
        UpdateLocation();
    }

    public void UpdateLocation(){
        title.text = currentLocation.title; //set the title to the current locations title
        description.text = currentLocation.description; //set the description to the current locations description

        if (i != 0) //if it's not the first time we are calling this function
        {
            if (i % 2 == 0) //if i is even
            {
                description.text = "See, still here!\n" + description.text;
            }
            else //if i is odd
            {
                description.text = "Told you so!\n" + description.text;
            }
        }

        i++; //increase i by 1
    }
}
