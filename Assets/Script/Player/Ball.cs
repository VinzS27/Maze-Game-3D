using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float movespeed = 9.0f;
    public float gravityModifier;
    public float jumpForce = 5.0f;
    public bool hasPowerup;
    public GameObject powerupIndicator;
    public ParticleSystem explosion;
    public AudioClip jumpsound;
    public AudioClip crashsound;
    private AudioSource playerAudio;
    private float xInp;
    private float zInp;
    bool isGrounded;
    private float powerupStrength = 15.0f;
    public TextMeshProUGUI gameOver;
    public Button restartButton;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInputs();
        
        powerupIndicator.transform.position = transform.position
            + new Vector3(0,1.0f,0);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerAudio.PlayOneShot(jumpsound, 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("CrushBall"))
        {
            //Destroy(gameObject);
            gameOver.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //explosion.Play();
            
            //Applica un impulso al nemico che lo direzione via dal player
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position
                - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name +
                " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength,
                ForceMode.Impulse);

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(crashsound, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        //Movement
        Move();
    }

    private void ProcessInputs()
    {
        xInp = Input.GetAxis("Horizontal");
        zInp = Input.GetAxis("Vertical");
        if (isGrounded)
            if (Input.GetButtonDown("jump"))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInp, 0f, zInp) * movespeed);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
