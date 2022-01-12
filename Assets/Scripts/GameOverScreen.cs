using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    private PlayerController playerControllerScript;
    Rigidbody rigid;

    public void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";
        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Physics.gravity = new Vector3(0, -9.8f, 0);




    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
    
}
