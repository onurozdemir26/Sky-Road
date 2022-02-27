
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    int maxPlatform = 0;
    public GameOverScreen GameOverScreen;
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
    float zýplama = 2f;
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
            transform.Translate(1 * Time.deltaTime * horizontalInput * sidewaysspeed, 0, 0);
        }

    }

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
        
    }
    public void Horizontal()
    {
        if (gameOver == false)
        {
            horizontalInput = SimpleInput.GetAxis("Horizontal");
            transform.Translate(1 * Time.deltaTime * horizontalInput * sidewaysspeed, 0, 0);
        }
        
    }
}
