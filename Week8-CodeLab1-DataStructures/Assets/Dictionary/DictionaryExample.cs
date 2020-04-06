using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryExample : MonoBehaviour
{
    // This enum contains the various resource types in the game.
    public enum ResourceType
    {
        Gold,
        Sparkles,
        Gems,
        Drongles
    }

    public Text display;

    public void Update()
    {
        // Each update, display the resources available to the player
        DisplayResources();
        // And what items the player already has.
        DisplayItems();
    }

    // A dictionary to represent what resources they have.
    private Dictionary<ResourceType, int> resourcesOwned = new Dictionary<ResourceType, int>();
    // A dictionary to represent what items they have.
    private Dictionary<string, int> itemsOwned = new Dictionary<string, int>();

    // This function adds a resource.
    public void AddResource(ResourceType resourceType, int amountToAdd)
    {
        if (resourcesOwned.ContainsKey(resourceType))
        {
            resourcesOwned[resourceType] = resourcesOwned[resourceType] + amountToAdd;
        }
        else
        {
            resourcesOwned.Add(resourceType, amountToAdd);
        }
    }

    // This function removes a resource
    public bool RemoveResource(ResourceType resourceType, int cost)
    {
        if (!HasEnoughResources(resourceType, cost))
        {
            return false;
        }

        resourcesOwned[resourceType] = resourcesOwned[resourceType] - cost;

        if (resourcesOwned[resourceType] == 0)
            resourcesOwned.Remove(resourceType);
        
        return true;
    }

    // This function determines whether you have at least "amount" of a resource type
    public bool HasEnoughResources(ResourceType resourceType, int amount)
    {
        if (!resourcesOwned.ContainsKey(resourceType) || resourcesOwned[resourceType] < amount)
            return false;

        return true;
    }

    // This function is a helper to turn strings into enums
    public ResourceType StringToResourceType(string resourceName)
    {
        switch (resourceName.ToUpper())
        {
            case "DRONGLES" :
                return ResourceType.Drongles;
            case "GEMS" :
                return ResourceType.Gems;
            case "SPARKLES" :
                return ResourceType.Sparkles;
            case "GOLD" :
            default:
                return ResourceType.Gold;
        }
    }

    // This function adds 10 of a resource - used in the buttons.
    public void AddResources(string resourceString)
    {
        var resourceType = StringToResourceType(resourceString);

        AddResource(resourceType, 10);
    }

    // Displays the owned resources
    public void DisplayResources()
    {
        display.text = "Owned Resources:\n";

        foreach (var keyValuePair in resourcesOwned)
        {
            display.text += "\n" + keyValuePair.Key + " (" + resourcesOwned[keyValuePair.Key] + ")";
        }
    }

    // Displays the items
    public void DisplayItems()
    {
        display.text += "\n\nItems:\n";
        
        foreach (var keyValuePair in itemsOwned)
        {
            display.text += "\n" + keyValuePair.Key + " (" + itemsOwned[keyValuePair.Key] + ")";
        }
    }

    // Used by the buttons to buy an item
    public void BuyItem(string item)
    {
        var successfulPurchase = false;

        switch (item.ToUpper())
        {
            case "APRICOT" :
                successfulPurchase = RemoveResource(StringToResourceType("GOLD"), 20);
                break;
            case "ORANGE" :
                successfulPurchase = RemoveResource(StringToResourceType("GEMS"), 5);
                break;
            case "GRUMPY FAIRY" :
                successfulPurchase = RemoveResource(StringToResourceType("SPARKLES"), 20);
                break;
            case "PRONGLE" :
                successfulPurchase = RemoveResource(StringToResourceType("DRONGLES"), 1);
                break;
        }

        if (successfulPurchase)
        {
            if (itemsOwned.ContainsKey(item.ToUpper()))
            {
                itemsOwned[item.ToUpper()] = itemsOwned[item.ToUpper()] + 1;
            }
            else
            {
                itemsOwned.Add(item.ToUpper(), 1);
            }
        }
    }
}
