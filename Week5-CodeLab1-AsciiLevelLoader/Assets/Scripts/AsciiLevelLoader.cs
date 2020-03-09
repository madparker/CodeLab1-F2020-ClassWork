using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;
    public GameObject prize;

    public float xOffset = -5;
    public float yOffset = 5;

    public string fileLevel = "Level.txt"; 

    // Start is called before the first frame update
    void Start()
    {
        string fullFilePath = Application.dataPath + "/" + fileLevel;

        print("Full file path: " + fullFilePath);

        print(File.ReadAllText(fullFilePath));

        //lines will be an array of strings, with each line in a different slot
        string[] lines = File.ReadAllLines(fullFilePath);

        //Make a GameObject to hold all the walls to make the inspector cleaner
        GameObject wallHolder = new GameObject("Wall Holder");

        //go through all the lines
        for (int y = 0; y < lines.Length; y++){
            string line = lines[y]; //get each line

            char[] characters = line.ToCharArray();

            //go through each character on the current line
            for (int x = 0; x < characters.Length; x++){
                GameObject newObject;

                switch(characters[x])
                {
                    case 'x':
                        newObject = Instantiate<GameObject>(wall);
                        newObject.transform.SetParent(wallHolder.transform); //make the parent of th new wall, Wall Holder
                        newObject.transform.position =
                                new Vector2(x + xOffset, -y + yOffset);
                        break;
                    case 'P':
                        newObject = Instantiate<GameObject>(player);
                        newObject.transform.position =
                                new Vector2(x + xOffset, -y + yOffset);
                        break;
                    case '*':
                        newObject = Instantiate<GameObject>(prize);
                        newObject.transform.position =
                                     new Vector2(x + xOffset, -y + yOffset);
                        break;
                    default:
                        print("empty");
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
