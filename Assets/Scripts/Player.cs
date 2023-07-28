using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject loseScreen;
    public Text healthDisplay;

    public int health;
    public float speed;
    float input;

    Animator anim;
    Rigidbody2D rb;
    AudioSource source;

    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
    }

    void Update()
    {
        //Set running animation when player presses keys
        if(input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //Set player facing correct direction when running
        if(input > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(input < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false)
        {
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        if (dashTime <= 0 && isDashing == true)
        {
            isDashing = false;
            speed -= extraSpeed;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        //Storing player's key input
        input = Input.GetAxisRaw("Horizontal");

        //Speed of the character movement
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        source.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            //Destroy player if die and display lose screen
            loseScreen.SetActive(true);
            Destroy(gameObject);
        }
    }

}
