using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public float xRange;

    const float MIN_SPEED = 0.01f;
    const float MAX_SPEED = 0.05f;
    const float MAX_Y = 10;
    const float MIN_Y = -10;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        speed = -Random.Range(MIN_SPEED, MAX_SPEED);

        transform.position = new Vector2(
            Random.Range(-xRange, xRange),
            MAX_Y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y + speed);

        if(transform.position.y < MIN_Y){
            StarPool.instance.Push(gameObject);
        }
    }
}
