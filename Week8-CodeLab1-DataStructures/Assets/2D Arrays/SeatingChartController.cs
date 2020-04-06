using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatingChartController : MonoBehaviour
{
    private int numRows = 6;
    private int numCols = 6;

    private string[,] seatingChart;

    public Text display;
    
    void Start()
    {
        seatingChart = new string[numCols, numRows];

        for (int x = 0; x < seatingChart.GetLength(0); x++)
        {
            for (int y = 0; y < seatingChart.GetLength(1); y++)
            {
                seatingChart[x, y] = "";
            }
        }

        seatingChart[0, 0] = "Chung, Brian S";
        seatingChart[0, 2] = "Fouron, Christine O";
        seatingChart[1, 4] = "Gonzalez, Stephen A";
        seatingChart[1, 0] = "Harper, Charlie";
        seatingChart[1, 2] = "Hill, Clareese G";
        seatingChart[1, 1] = "Li, Yongkun";
        seatingChart[2, 0] = "Liu, Yamiao";
        seatingChart[2, 2] = "Saxena, Varun Alok";
        seatingChart[2, 4] = "Scudder, Sasha";
        seatingChart[3, 0] = "Sords, Samuel S";
        seatingChart[3, 2] = "Wang, Julia";
        seatingChart[3, 4] = "Wu, Rosaita";

        PrintWhereSeated();
    }

    public void PrintWhereSeated()
    {
        string toPrint = "~~~~ FRONT ~~~~\n";
        for (int x = 0; x < seatingChart.GetLength(0); x++)
        {
            for (int y = 0; y < seatingChart.GetLength(1); y++)
            {
                if (seatingChart[x, y] != "")
                {
                    toPrint += " [X] ";
                }
                else
                {
                    toPrint += " [ ] ";
                }
            }

            toPrint += "\n";
        }

        toPrint += "~~~~ BACK ~~~~";

        display.text = toPrint;
    }

}
