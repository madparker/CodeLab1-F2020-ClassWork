using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        string displayText = highScoreTemplate.Replace("<score>", GameManager.instance.Score + "");

        string highScoreString = "";

        List<string> hsNames = GameManager.instance.highScoreNames;
        List<int> hsNums     = GameManager.instance.highScoreNums;

        for (int i = 0; i < hsNames.Count; i++){
            highScoreString += hsNames[i] + " " + hsNums[i] + "\n";
        }

        displayText = displayText.Replace("<highScores>", highScoreString);

        Debug.Log("displayText: " + displayText);

        highScoreText.text = displayText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
