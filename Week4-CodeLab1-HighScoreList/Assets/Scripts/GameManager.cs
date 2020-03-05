using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    public Text infoText; //Text Component to tell you the time and the score

    private const string FILE_HS_LIST = "/high_score.txt";

    public float timer = 0; //keep track of time

    public bool playing = true;

    private int score = 0;
    //Property for score
    //A property wraps a variable and allows you to call a function
    //whenever the value of the variable is used or set
    public int Score{
        get{
            return score;
        }
        set{
            score = value; //set "score" to whatever value was passed
        }
    }

    public List<string> highScoreNames; //list of high score names
    public List<float>  highScoreNums;  //list of high score values

    private void Awake()
    {
        if(instance == null){ //instance hasn't been set yet
            instance = this; //set instance to this object
            DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene
        } else { //if the instance is already set to an object
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScoreNames = new List<string>(); //init highScoreNames
        highScoreNums  = new List<float>();  //init highScoreNums

        if (File.Exists(Application.dataPath + FILE_HS_LIST)) //if the high score file exists
        {
            string fileContents = File.ReadAllText(Application.dataPath + FILE_HS_LIST); //get the contents of the file

            string[] scorePairs = fileContents.Split('\n'); //split it on the newline, making each space in the array a line in the file

            for (int i = 0; i < 10; i++){ //loop through the 10 scores
                string[] nameScores = scorePairs[i].Split(' '); //split each line on the space
                highScoreNames.Add(nameScores[0]); //the first part of the split is the name
                highScoreNums.Add(float.Parse(nameScores[1])); //the second part is the value
            }
        }
        else //if the high score file doesn't exist
        {
            for (int i = 0; i < 10; i++) //create a new default high score list
            {
                highScoreNames.Add("DAM");
                highScoreNums.Add(100 + i * 10);
            }
        }

        Debug.Log(Application.dataPath);

        infoText = GetComponentInChildren<Text>(); //get the text component from the children of this gameObject
    }   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //increase the timer by deltaTime every frame
        infoText.text = "Score: " + score + " Time: " + (int)timer; //update the text component with the score and time
    }

    //function that updates the high score list
    public void UpdateHighScores(){

        bool newScore = false; //by default, we don't have new high score

        for (int i = 0; i < highScoreNums.Count; i++){ //go through all the high scores
            if(highScoreNums[i] > timer){ //if we have a time that is lower than one of the high scores
                highScoreNums.Insert(i, timer); //insert this new score into the value list
                highScoreNames.Insert(i, "NEW"); //give it the name "NEW"
                newScore = true; //we have a new high score
                break; //leave the for loop
            }
        }

        if(newScore){ //if we have a new high score
            highScoreNums.RemoveAt(highScoreNums.Count - 1); //remove the final high score value so we are back down to 10
            highScoreNames.RemoveAt(10);
        }

        string fileContents = ""; //create a new string to insert into the file

        for (int i = 0; i < highScoreNames.Count; i++){ //loop through all the high scores
            fileContents += highScoreNames[i] + " " + highScoreNums[i] + "\n"; //build a string for all the high scores in the lists
        }

        File.WriteAllText(Application.dataPath + FILE_HS_LIST, fileContents); //save the list to the file
    }

    //reset the important values when the game restarts
    public void Reset()
    {
        timer = 0;
        score = 0;
        PrizeScript.currentLevel = 0;
    }
}
