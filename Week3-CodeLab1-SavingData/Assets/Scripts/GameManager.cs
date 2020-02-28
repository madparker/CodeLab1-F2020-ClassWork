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

    private float timer = 0; //keep track of time

    private const string PLAY_PREF_KEY_HS = "High Score"; //Player preferences key for high score. It is a "const" which means the value is only set once and can never be changed
  
    private const string FILE_HS = "/CodeLab1-S2020-highscore.txt"; //Const for name of the highscore file
    private const string FILE_ALL_SCORES = "/All_scores.txt"; //Const for the name of the All Scores file

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
            if(score > highScore){ //if the score is greater than the highScore
                HighScore = score; //set the HighScore property to score
            }
        }
    }

    private List<int> allScores = new List<int>(); //list to hold all high scores

    private int highScore = 0;

    //Property for HighScore
    private int HighScore{
        get{
            return highScore;
        }
        set{
            highScore = value;
            //Save it somewhere
            //PlayerPrefs.SetInt(PLAY_PREF_KEY_HS, highScore); //save HighScore to PlayerPrefs

            //Save High Score to a file
            File.WriteAllText(Application.dataPath + FILE_HS, highScore + "");
        
            //Add the high Score to the allScores list
            allScores.Add(highScore);

            string allScoreString = ""; //make an empty string
            for (int i = 0; i < allScores.Count; i++){ //loop through from 0 to the number of items in allScores
                allScoreString = allScoreString + allScores[i] + ","; //add the high score in the ith place to the string followed by a ","
            }
            File.WriteAllText(Application.dataPath + FILE_ALL_SCORES, allScoreString); //write the string to the all scores file
        }
    }

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
        Debug.Log(Application.dataPath);

        infoText = GetComponentInChildren<Text>(); //get the text component from the children of this gameObject

        //highScore = PlayerPrefs.GetInt(PLAY_PREF_KEY_HS, 5); //get the high score out of PlayerPrefs

        if (File.Exists(Application.dataPath + FILE_HS)) //if the file exists
        {
            string hsString = File.ReadAllText(Application.dataPath + FILE_HS); //read the text from the file into a string

            print(hsString); //print the contents of the file
            string[] splitString = hsString.Split(','); //split the string on ','
            highScore = int.Parse(splitString[0]); //parse the string in the first place

            for (int i = 0; i < splitString.Length; i++){ //go through the split string array
                print(splitString[i]); //print out each value
            }
        }
    }   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //increase the timer by deltaTime every frame
        infoText.text = "Score: " + GameManager.instance.score + " Time: " + (int)timer + " High Score: " + highScore; //update the text component with the score and time
    }
}
