using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListExample : MonoBehaviour
{
    public InputField input;
    public TextAsset textFileWithNames;
    public Text display;

    private List<string> names;

    private void Start()
    {
        // Instantiate the list
        names = new List<string>();
        
        // The below code reads the text file and splits it into lines.
        var namesFromFile = textFileWithNames.text.Split('\n');

        // This code loops though every single line in the text file
        for (var i = 0; i < namesFromFile.Length; i++)
        {
            // Add each line to the list of names.
            names.Add(namesFromFile[i].ToUpper());
        }
        
        
        // Extra methods tests:
        
        Debug.Log("Count: " + names.Count);
        Debug.Log("Names contains \"JACK\":" + names.Contains("JACK"));
        Debug.Log("Names contains \"LANNI\":" + names.Contains("LANNI"));

        names.Insert(4520, "LANNI");

        var indexOfLastLanni = 0;

        for (int i = 0; i < names.Count; i++)
        {
            if (names[i] == "LANNI")
                indexOfLastLanni = i;
        }
       
        Debug.Log(names[4520]);
        names.RemoveAt(indexOfLastLanni);
        Debug.Log(names[4520]);



        // Debug.Log("Successfully removed \"LANNI\": " + names.Remove("LANNI"));
        // Debug.Log("Names contains\"LANNI\": " + names.Contains("LANNI"));
    }

    private void Update()
    {
        // If there's nothing in the text box, show instructions.
        if (input.text == "")
        {
            display.text = "Type a name to see if it's in the list!";
        }
        // Otherwise, check to see if the name is in the list.
        else
        {
            // Start by setting the display to say "not in list".
            display.text = "Not in the list.";
            
            // Loop through the entire list
            for (int i = 0; i < names.Count; i++)
            {
                // If any of the names in the list match what in the input field,
                // say it's in the list.
                if (input.text.ToUpper() == names[i])
                {
                    display.text = "In the list!";
                }
            }

        }
    }
}
