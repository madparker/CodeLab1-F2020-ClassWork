using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeScript : MonoBehaviour
{
    public static int currentLevel = 0;
    public int targetScore;

    // Start is called before the first frame update
    void Start()
    {
        targetScore = PlayerController.instance.score * 2 + 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //If another GameObject with a 2D Collider on it hits this GameObject's collider
    {
        PlayerController.instance.score++;
        Debug.Log("Score: " + PlayerController.instance.score);
        transform.position = new Vector2(Random.Range(-6, 6), Random.Range(-4, 4)); //teleport to a random location

        if(PlayerController.instance.score > targetScore)
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
        }
    }
}
