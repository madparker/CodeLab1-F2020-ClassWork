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

    public List<string> highScoreNames;
    public List<float>  highScoreNums;

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
        highScoreNames = new List<string>();
        highScoreNums  = new List<float>();

        if (File.Exists(Application.dataPath + FILE_HS_LIST))
        {
            string fileContents = File.ReadAllText(Application.dataPath + FILE_HS_LIST);

            string[] scorePairs = fileContents.Split('\n');

            for (int i = 0; i < 10; i++){
                string[] nameScores = scorePairs[i].Split(' ');
                highScoreNames.Add(nameScores[0]);
                highScoreNums.Add(float.Parse(nameScores[1]));
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
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

    public void UpdateHighScores(){

        bool newScore = false; //by default, we don't have new high score

        for (int i = 0; i < highScoreNums.Count; i++){
            if(highScoreNums[i] > timer){
                highScoreNums.Insert(i, timer);
                highScoreNames.Insert(i, "NEW");
                newScore = true; //we have a new high score
                break;
            }
        }

        if(newScore){ //if we have a new high score
            highScoreNums.RemoveAt(highScoreNums.Count - 1);
            highScoreNames.RemoveAt(10);
        }

        string fileContents = "";

        for (int i = 0; i < highScoreNames.Count; i++){
            fileContents += highScoreNames[i] + " " + highScoreNums[i] + "\n";
        }

        File.WriteAllText(Application.dataPath + FILE_HS_LIST, fileContents);
    }

    public void Reset()
    {
        timer = 0;
        score = 0;
        PrizeScript.currentLevel = 0;
    }
}
