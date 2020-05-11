using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    public float intervalMin = 0.1f;
    public float intervalMax = 0.5f;
    public float numStars = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnStar", intervalMin);
    }

    void SpawnStar()
    {
        for (int i = 0; i < numStars; i++){
            GameObject star = StarPool.instance.GetStar();
        }

        Invoke("SpawnStar", Random.Range(intervalMin, intervalMax));
    }
}
