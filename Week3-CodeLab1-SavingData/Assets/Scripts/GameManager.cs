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

    private int score = 0;

    private const string PLAY_PREF_KEY_HS = "High Score";
    private const string PLAY_PREF_KEY_P1_HS = "P1 HIGH SCORE";

    private const string FILE_HS = "/CodeLab1-S2020-highscore.txt";
    private const string FILE_ALL_SCORES = "/All_scores.txt";

    //Property
    public int Score{
        get{
            return score;
        }
        set{
            score = value;
            if(score > highScore){
                HighScore = score;
            }
        }
    }

    private int highScore = 0;

    private int HighScore{
        get{
            return highScore;
        }
        set{
            highScore = value;
            //Save it somewhere
            //PlayerPrefs.SetInt(PLAY_PREF_KEY_HS, highScore);
            File.WriteAllText(Application.dataPath + FILE_HS, highScore + "");
        

            allScores.Add(highScore);

            string allScoreString = "";
            for (int i = 0; i < allScores.Count; i++){
                allScoreString = allScoreString + allScores[i] + ",";
            }
            File.WriteAllText(Application.dataPath + FILE_ALL_SCORES, allScoreString);
        }
    }

    private List<int> allScores = new List<int>();

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
        //highScore = PlayerPrefs.GetInt(PLAY_PREF_KEY_HS, 5);
        if (File.Exists(Application.dataPath + FILE_HS))
        {
            string hsString = File.ReadAllText(Application.dataPath + FILE_HS);

            print(hsString);
            string[] splitString = hsString.Split(',');
            highScore = int.Parse(splitString[0]);

            for (int i = 0; i < splitString.Length; i++){
                print(splitString[i]);
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
