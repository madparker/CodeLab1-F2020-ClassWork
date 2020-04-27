using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directory : MonoBehaviour
{
    public Text text; //variable for component that displays the text

    //NOTE: notice that this is a list of NYUPerson, but can still hold all subclasses. THAT'S POLYMORPHISM, BABY!
    public List<NYUPerson> nyuPeopleList; //list of people at nyu

    int recordNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        nyuPeopleList = new List<NYUPerson>();

        //make a new NYUStudent
        NYUStudent joanDoe = new NYUStudent("Joan Doe",
                                           "jd123",
                                           "N8765652",
                                           3.2f);
        nyuPeopleList.Add(joanDoe); //add joanDoe to the nyuPeopleList

        //make a new NYUGuest
        NYUGuest randoJones = new NYUGuest("Rando Jones"); 
        nyuPeopleList.Add(randoJones); //add randoJones to the nyuPeopleList

        //make a new NYUFaculty 
        NYUFaculty mattParker = new NYUFaculty("Matt Parker",
                                              "mp612",
                                              "N12345",
                                              "NYU Game Center",
                                               10000000f,
                                               new string[] { "Code Lab 0", "Code Lab 1"});
        nyuPeopleList.Add(mattParker); //add mattParker to the nyuPeopleList

        //make a new NYUStaff
        NYUStaff kevinSpain = new NYUStaff("Kevin Spain",
                                          "ks234",
                                          "N32673467",
                                          "NYU Game Center",
                                           237129823783.01f,
                                           1);
        nyuPeopleList.Add(kevinSpain); //add kevinSpain to the nyuPeopleList

        UpdateRecord(); //update the text display to show the the info from the first person in the list
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ //if space is pressed
            UpdateRecord(); //change the record to display the next person in the list
        }
    }

    void UpdateRecord(){
        NYUPerson person = nyuPeopleList[recordNum % nyuPeopleList.Count]; //grab the object a person in the list (use % to wrap around)

        text.text = person.showRecord(); //display the info for this object

        recordNum++; //increase the recordNum so we show the next person next time through
    }
}
