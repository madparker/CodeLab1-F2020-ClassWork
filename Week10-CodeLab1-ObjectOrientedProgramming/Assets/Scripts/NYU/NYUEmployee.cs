using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUEmployee : NYUPerson
{
    //adds more variables on top of NYUPerson for this class
    public string deptName; 
    public float salary;

    //uses the base constructor, then adds more
    public NYUEmployee(string name, string netId, string nNumber, string deptName, float salary) : 
    base(name, netId, nNumber)
    {
        this.deptName = deptName;
        this.salary = salary;
    }
}
