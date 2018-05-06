using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

    public Animator anim;
    public Rigidbody rb;
    public float jumpForce;
    private float inputH;
    private float inputV;
    private bool isGrounded;
    public float speed;
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    public int score;
    public Text scoreText;
    

	void Start () {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jumpForce = 1f;
        speed = 1f;
        isGrounded = true;
        spawnPos = transform.position;
        spawnRot = transform.rotation;
        score = 0;
        setScoreText();
    }
	
	void Update () {

        
        //handling movement 
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");


        float moveY = inputH * 150f * Time.deltaTime * speed;
        float moveZ = inputV * 5f * Time.deltaTime * speed;

        transform.Translate(0, 0, moveZ);
        transform.Rotate(0, moveY, 0);
        
        //only able to jump when grounded
        if (isGrounded == true)
        {
            anim.SetFloat("inputH", inputH);    //running animations working only when grounded
            anim.SetFloat("inputV", inputV);

            //jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                anim.SetBool("jump", true); //telling animator that a jump has been initiated
                rb.AddForce(new Vector3(0, 500 * jumpForce, 0), ForceMode.Impulse); //actual jump
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);  //go back to main menu
        }
    }

    //progressing levels
    void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnCollisionEnter(Collision col)
    {
        //checking if on ground
        if (col.gameObject.tag == "Ground")
        { 
            isGrounded = true;
            anim.SetBool("isGrounded", isGrounded);
            anim.SetBool("jump", false);    //jump will always be reset to false once grounded
        }

        //dying & respawning
        else if (col.gameObject.tag == "Death")
        {
            transform.position = spawnPos;
            transform.rotation = spawnRot;
            rb.velocity = new Vector3(0f, 0f, 0f); //resetting velocity
            anim.Play("Lose", -1, 0f);  //play lose animation
        }   
    }

    //checking if left ground
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
            anim.SetBool("isGrounded", isGrounded);
        }
    }

    void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "Score")
        {
            Destroy(trig.gameObject);
            score++;
            setScoreText();
        }

        else if (trig.gameObject.tag == "JumpPowerup")
        {
            Destroy(trig.gameObject);
            jumpForce = 1.5f;
        }

        else if (trig.gameObject.tag == "Checkpoint")
        {
            spawnPos = trig.transform.position;  //set new spawn points
            spawnRot = trig.transform.rotation;
            Destroy(trig.gameObject);    //get rid of checkpoint
        }

        else if (trig.gameObject.tag == "Goal" && score >= 5)    //requires all score pickups
        {
            Destroy(trig.gameObject);
            anim.Play("Win", -1, 0f);
            Invoke("nextLevel", 3f);
        }
    }

    void setScoreText()
    {
        if (score < 5)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            scoreText.text = "Go to the goal!";
        }
    }
}