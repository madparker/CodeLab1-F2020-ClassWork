using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text infoText;

    private float timer = 0;

    private void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        infoText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        infoText.text = "Score: " + PlayerController.instance.score + " Time: " + (int)timer;
    }
}
