using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjectExample : MonoBehaviour
{
    public GameObject itemPrefab;

    public List<string> foundObjects = new List<string>();
    public Dictionary<string, bool> foundObjectDict = new Dictionary<string, bool>();
    private string[] keysInGame = {"Monkey", "Barrel", "Torch"};

    public bool FoundObject(string key)
    {
        if (foundObjects.Contains(key)) return false;

        foundObjects.Add(key);

        IsGameOverList();
        return true;
    }

    bool IsGameOverList()
    {
        return foundObjects.Count == keysInGame.Length;
    }
    
    bool IsGameOverDict()
    {
        var toReturn = true;
        
        foreach (var key in foundObjectDict.Keys)
            if (!foundObjectDict[key])
                toReturn = false;

        return toReturn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

