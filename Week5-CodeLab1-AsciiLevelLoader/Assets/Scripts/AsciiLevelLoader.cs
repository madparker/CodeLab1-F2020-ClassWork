using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;

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

        //go through all the lines
        for (int y = 0; y < lines.Length; y++){
            string line = lines[y]; //get each line

            char[] characters = line.ToCharArray();

            //go through each character on the current line
            for (int x = 0; x < characters.Length; x++){
                if(characters[x] == 'x'){
                    GameObject newWall = Instantiate<GameObject>(wall);
                    newWall.transform.position = 
                        new Vector2(x + xOffset, -y + yOffset);
                }

                if(characters[x] == 'P'){
                    GameObject newPlayer = Instantiate<GameObject>(player);
                    newPlayer.transform.position =
                        new Vector2(x + xOffset, -y + yOffset);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
