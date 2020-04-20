using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUStudent : NYUPerson
{
    public float gpa; //add a new variable for this subclass on top of the base variables

    //NYUStudent construtor uses the base constructor, then does more
    public NYUStudent(string name, string netId, string nNumber, float gpa) : 
    base(name, netId, nNumber)
    {
        type = "NYU Student";
        this.gpa = gpa;
    }

    //uses the base version of showRecord, then adds more!
    public override string showRecord()
    {
        return base.showRecord() + "\n" +
                   "GPA: " + gpa;
    }
}
