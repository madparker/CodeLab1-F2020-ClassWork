using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    public Material[] materials;
    public int gridX, gridY;

    void Start()
    {
        GetComponent<MeshRenderer>().material = 
            materials[Random.Range(0, materials.Length)];
    }

    // Start is called before the first frame update
    public void SetPos(int x, int y)
    {
        gridX = x;
        gridY = y;

        name = "X: " + x + " Y: " + y;
    }

    void OnMouseDown()
    {
        if(GridManager.instance.selected == null){
            GridManager.instance.selected = this;
            transform.localScale = new Vector3(1, 1, 1);
        } else {
            GridManager.instance.Swap(this);
        }

        print(name);
    }
}
