using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    public TMP_Text scoreplayer1;
    public TMP_Text scoreplayer2;

    public TMP_Text endingtext;

    public GameObject respawnBall;
    public GameObject endingscreen;

    public GameObject Cat;
    public AudioSource catfart;
    public AudioSource glassbreak;

    public Ball Ballscript;


    public int P1Score = 0;
    public int P2Score = 0;

    private bool isGameEnding = false;
    private bool canEndGame = false;
    public void playerScoring(int player)
    {
            if (player == 1)
            {
                Debug.Log("Player 1 scored!");
                P1Score++;
                scoreplayer1.text = P1Score.ToString();

                if (P1Score == 3)
                {
                    Destroy(respawnBall);
                    endingtext.text = "Blue Team Wins!".ToString();
                    endingscreen.SetActive(true);
                    isGameEnding = true;
                return;
                }
                
                respawnBall.transform.position = new Vector2(0f, 0f);
                Ballscript.starttimer();
            }
            else if (player == 2)
            {
                Debug.Log("Player 2 scored!");
                P2Score++;
                scoreplayer2.text = P2Score.ToString();

                if (P2Score == 3)
                {
                    Destroy(respawnBall);
                    endingtext.text = "Red Team Wins!".ToString();
                    endingscreen.SetActive(true);
                    isGameEnding = true;
                return;
                }
               
                respawnBall.transform.position = new Vector2(0f, 0f);
                Ballscript.starttimer();
            }
    }

    public void Update()
    {
        if (isGameEnding == true )
        {
            StartCoroutine(countdownending());
            bool anyKey = Input.anyKey;

            if (canEndGame)
            {
                if (anyKey)
                {
                    SceneManager.LoadScene(0);
                }
            }
            
        }
    }

    public void Start()
    {
        StartCoroutine(showCat());
    }
    IEnumerator countdownending()
    {
        int i = 3;

        while (i != 0)
        {
            i--;

            yield return new WaitForSeconds(1);
        }
        canEndGame = true;
    }

    IEnumerator showCat()
    {
        int i = 0;

        while (i != 40)
        {
            i++;
            if (i == 30 || i == 40)
            {
                glassbreak.Play();
            }
            yield return new WaitForSeconds(1);
        }
        Cat.SetActive(true);
        catfart.Play();
    }

}
