using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYUStaff : NYUEmployee
{
    //Adds a variable on top of NYUEmployee AND NYUPerson
    public int adminCode;

    //uses the constructor for NYUEmployee (which uses the constructor for NYUPerson), then sets more vars
    public NYUStaff(string name, string netId, string nNumber, string deptName, float salary, int adminCode) : 
    base(name, netId, nNumber, deptName, salary)
    {
        type = "NYU Staff";
        this.adminCode = adminCode;
    }

    public override string showRecord()
    {
        return base.showRecord() + "\n" +
                   "Code: " + adminCode;
    }
}
