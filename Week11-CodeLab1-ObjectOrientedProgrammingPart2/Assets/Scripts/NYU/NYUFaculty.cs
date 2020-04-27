using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUFaculty : NYUEmployee
{
    //adds a variable on top of NYU Employee
    public string[] classesTaught;

    //uses the constructor for NYUEmployee (which uses the constructor for NYUPerson), then sets more vars
    public NYUFaculty(string name, string netId, string nNumber, string deptName, float salary, string[] classesTaught) : 
    base(name, netId, nNumber, deptName, salary)
    {
        type = "NYU Faculty";
        this.classesTaught = classesTaught;
    }
}
