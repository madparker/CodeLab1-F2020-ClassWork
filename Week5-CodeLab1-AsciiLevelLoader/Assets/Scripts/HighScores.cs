using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    public Text highScoreText;

    string highScoreTemplate = 
        "Your Score: \n" + 
        "<score>\n\n" +
        "High Score:\n" +
        "<highScores>";

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.UpdateHighScores(); //update high scores when you get to this screen

        string displayText = highScoreTemplate.Replace("<score>", GameManager.instance.timer + ""); //replace <score? with the players time

        string highScoreString = ""; //make a string for holding the high score text

        List<string> hsNames = GameManager.instance.highScoreNames; //short name for singleton vals
        List<float>  hsNums  = GameManager.instance.highScoreNums;

        for (int i = 0; i < hsNames.Count; i++){ //loop through all the names
            highScoreString += hsNames[i] + " " + hsNums[i] + "\n"; //turn the values in the list into a string
        }

        displayText = displayText.Replace("<highScores>", highScoreString); //replace "<highScores>" with the high score string

        Debug.Log("displayText: " + displayText);

        highScoreText.text = displayText; //put the new text in the highScoreText to display
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){ //if you press space
            GameManager.instance.Reset(); //reset the vars
            SceneManager.LoadScene("Level1"); //restart the game
        }
    }
}
