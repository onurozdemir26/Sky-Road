
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // private Score ScoreScript;
    int maxPlatform = 0;
    public GameOverScreen GameOverScreen;
    //public GameOver GameOver;
    public ParticleSystem explosionParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    public float speed = 10f;
    public float jumpforce = 10f;
    public float forwardspeed = 10f;
    public float sidewaysspeed = 10f;
    private float horizontalInput;
    public float xRange = 15f;
    public float xRangerz = 10f;
    public bool isOnGround = true;
    public float gravityModifier;
    public bool gameOver;
    public bool something;
    private Animator playerAnim;
    float z�plama = 2f;
    private double screenWidht;
    Vector3 firstTouch;
    Vector3 lastTouch;
    

    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;


    }
    // Update is called once per frame
    void Update()
    {
        /*if (gameOver == false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && isOnGround)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                screenWidht = Screen.width / 2;

                if (touchPosition.x < screenWidht)
                {
                    RunCharacter(1);
                    Debug.Log("Left");
                }
                else if (touchPosition.x > screenWidht)
                {
                    RunCharacter(-1);
                    Debug.Log("Right");
                }
            }
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    firstTouch = touch.position;
                    lastTouch = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    lastTouch = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    lastTouch = touch.position;
                    if (lastTouch.y > firstTouch.y && isOnGround)
                    {

                        playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                        isOnGround = false;
                        playerAnim.SetBool("Jump", true); ;
                        playerAudio.PlayOneShot(jumpSound, 1.0f);
                        lastTouch = Vector3.zero;



                    }
                }
            }
        }
        else
        {

        }*/

        
        //////////////////////////////////////////////////////////////////////////////
        //transform.Translate(1*Time.deltaTime*horizontalInput*sidewaysspeed, 0, 0);
        transform.Translate(Vector3.right * Time.deltaTime * sidewaysspeed * horizontalInput);
        if (transform.position.x < -xRangerz)
        {
            transform.position = new Vector3(-xRangerz, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (gameOver == false)
        {
            transform.position += transform.forward * forwardspeed * Time.deltaTime;
            horizontalInput = SimpleInput.GetAxis("Horizontal");
            transform.Translate(1*Time.deltaTime*horizontalInput*sidewaysspeed, 0, 0);
        }
        else{

        }


    }
    /*public void RunCharacter(float hor�zontalInput)
    {
        playerRb.AddForce(new Vector3(hor�zontalInput * sidewaysspeed , 0));
    }*/
    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.SetBool("Jump", false);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetTrigger("Death");
            playerAnim.SetInteger("DeathType", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            //SceneManager.LoadScene("Game Over");
            GameOverScreen.Setup(maxPlatform);
        }
    }
    public void Jump()
    {
        if (gameOver == false)
        {
            if (isOnGround)
            {

                playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump");
                playerAudio.PlayOneShot(jumpSound, 1.0f);



            }
        }
        else
        {

        }
    }
    public void Horizontal()
    {
        if (gameOver == false)
        {
            horizontalInput = SimpleInput.GetAxis("Horizontal");
            transform.Translate(1*Time.deltaTime*horizontalInput*sidewaysspeed, 0, 0);
        }
        else
        {

        }
    }
}
