using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public bool gameOver;
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreAmount = 0f;
        pointIncreasedPerSecond = 10f;
    }

    
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            scoreText.text = "Score:" + (int)scoreAmount;
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
        }
    }
    void ScoreController()
    {
       
        
    }
}
