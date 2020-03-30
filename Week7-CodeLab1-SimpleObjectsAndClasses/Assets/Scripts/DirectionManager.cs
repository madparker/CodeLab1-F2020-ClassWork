using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DirectionManager : MonoBehaviour
{
    public Text title;
    public Text description;

    public Button nButton;
    public Button sButton;
    public Button eButton;
    public Button wButton;

    public int numLocations;

    public Location currentLocation;

    public Location[] locations;

    string filePath = "/Files/Location<num>.json";

    void Start()
    {
        filePath = Application.dataPath + filePath;

        locations = new Location[numLocations];

        for (int i = 0; i < locations.Length; i++){
            string locPath = filePath.Replace("<num>", "" + i);

            string fileContent = File.ReadAllText(locPath);

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
