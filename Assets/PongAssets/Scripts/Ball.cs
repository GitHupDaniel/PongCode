using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public BallControl controlScript;
    public Rigidbody2D rb;
    public float startingSpeed;

    public GameObject[] players;

    public Collider2D ballCollider;
    public Collider2D player1;
    public Collider2D player2;

    public Collider2D player1wall;
    public Collider2D player2wall;

    public AudioSource boing;
    public AudioSource explosion;

    public TMP_Text countdownText;


    void Start()
    {
        starttimer();
        
    }

    public void launchBall()
    {
        startingSpeed = 6f;
        bool isRight = UnityEngine.Random.value >= 0.5;
        float xVelocity = -1f;

        if (isRight == true)
        {
            xVelocity = 1f;
        }

        float yVelocity = UnityEngine.Random.Range(-1f, 1f);

        rb.velocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    public void starttimer()
    {
        StartCoroutine(countdown());
    }

    IEnumerator countdown()
    {
        int i = 3;
        startingSpeed = 0f;

        while (i != 0)
        {
            countdownText.text = i.ToString();
            Debug.Log(i);
            i--;
                
            yield return new WaitForSeconds(1);
        }
        countdownText.text = "".ToString();
        launchBall();
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * startingSpeed;

        if (ballCollider.IsTouching(player1) || ballCollider.IsTouching(player2))
        {
            string collidedWith = ballCollider.IsTouching(player1) ? "Player 1" : "Player 2";
            
            Debug.Log("Collision with " + collidedWith);
            
            if (!boing.isPlaying)
            {
                boing.Play();
            }
        }


        if (ballCollider.IsTouching(player1wall))
        {
            if (!explosion.isPlaying)
            {
                explosion.Play();
                controlScript.playerScoring(2);
                //Destroy(gameObject);
            }
        }
        else if (ballCollider.IsTouching(player2wall))
        {
            if (!explosion.isPlaying)
            {
                explosion.Play();
                controlScript.playerScoring(1);
                //Destroy(gameObject);
            }
        }

        
    }

    

}
