using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a special case for an NYU person
public class NYUGuest : NYUPerson
{
    //constructor for the NYU Guest, provides default info to the base constuctor
    public NYUGuest(string name) :
    base(name, "N/A", "N/A")
    {
        type = "NYU Guest";
    }

    //completely overrides the virtual showRecord to do it's own version of showRecord
    public override string showRecord()
    {
        return
            "Name: " + name + "\n" +
            "Type: " + type;
    }
}
