using System.Collections;
using System.Collections.Generic;

public class Location // a Location Class (not a component)
{
    public string title;        //var for a title
    public string description;  //var for a description

    public int nLocation = -1; //var for a location num for N
    public int sLocation = -1; //var for a location num for S
    public int eLocation = -1; //var for a location num for E
    public int wLocation = -1; //var for a location num for W


    //Constructor that takes only a title and a description
    public Location(string title, string description)
    {
        this.title = title; //"this.title" means "this objects title". just "title" means the parameter passed to this function
        this.description = description;  //"this.description" means "this objects description". just "description" means the parameter passed to this function
    }

    //Constructor that takes only a title, description, and ints for n, s, e, w 
    public Location(string title, string description,
                    int n, int s, int e, int w)
    {
        this.title = title;  //"this.title" means "this objects title". just "title" means the parameter passed to this function
        this.description = description; //"this.description" means "this objects description". just "description" means the parameter passed to this function

        nLocation = n;
        sLocation = s;
        eLocation = e;
        wLocation = w;
    }
}
