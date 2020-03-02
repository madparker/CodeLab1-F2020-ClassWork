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
    public List<int>    highScoreNums;

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
        highScoreNums  = new List<int>();

        for (int i = 0; i < 10; i++){
            highScoreNames.Add("DAM");
            highScoreNums.Add(100 + i * 10);
        }

        Debug.Log(Application.dataPath);

        infoText = GetComponentInChildren<Text>(); //get the text component from the children of this gameObject
    }   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //increase the timer by deltaTime every frame
        infoText.text = "Score: " + GameManager.instance.score + " Time: " + (int)timer; //update the text component with the score and time
    }
}
