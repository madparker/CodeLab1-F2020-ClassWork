using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DirectionManager : MonoBehaviour
{
    public Text title; //holds ui title
    public Text description;  //holds ui description

    public Button nButton;  //north 
    public Button sButton;  //south
    public Button eButton;  //east
    public Button wButton;  //west

    public int numLocations; 

    public Location currentLocation; //the current location

    public Location[] locations; //array of all the locations

    string filePath = "/Files/Location<num>.json"; //default path to location files

    //once at the start
    void Start()
    {
        filePath = Application.dataPath + filePath; //full path to files

        locations = new Location[numLocations]; //init array to have numLocation slots

        for (int i = 0; i < locations.Length; i++){ //0 to locations.Length
            string locPath = filePath.Replace("<num>", "" + i); //creating a path to file num "i"

            string fileContent = File.ReadAllText(locPath); //fileContent will hold all the text from the file at locPath

            Location l = JsonUtility.FromJson<Location>(fileContent);

            locations[i] = l;
        }

        UpdateLocation(0);
    }

    public void GoNorth()
    {
        UpdateLocation(currentLocation.nLocation);
    }

    public void GoSouth()
    {
        UpdateLocation(currentLocation.sLocation);
    }

    public void GoEast()
    {
        UpdateLocation(currentLocation.eLocation);
    }

    public void GoWest()
    {
        UpdateLocation(currentLocation.wLocation);
    }

    public void UpdateLocation(int locNum){
        currentLocation = locations[locNum];

        title.text = currentLocation.title;
        description.text = currentLocation.description;

        if(currentLocation.nLocation < 0){
            nButton.gameObject.SetActive(false);
        } else {
            nButton.gameObject.SetActive(true);
        }

        if (currentLocation.sLocation < 0)
        {
            sButton.gameObject.SetActive(false);
        }
        else
        {
            sButton.gameObject.SetActive(true);
        }

        if (currentLocation.eLocation > 0)
        {
            eButton.gameObject.SetActive(false);
        }
        else
        {
            eButton.gameObject.SetActive(true);
        }

        if (currentLocation.wLocation < 0)
        {
            wButton.gameObject.SetActive(false);
        }
        else
        {
            wButton.gameObject.SetActive(true);
        }
    }
}
