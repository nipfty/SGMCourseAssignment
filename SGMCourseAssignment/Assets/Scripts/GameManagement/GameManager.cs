﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // public delegate void Scored();
    // public static event Scored OnScore;
    
    public static GameManager instance = null;
    private Vector2 initPosP1;
    private Vector2 initPosP2;
    private Vector2 initPosBall;
    public GameObject p1;
    public GameObject p2;
    public GameObject ball;
    //public GameObject text;
    float restartDelay = 0.5f;                   

    private int player1Score;
    private int player2Score;
    void Awake()
    {

        if (instance == null)


            instance = this;


        else if (instance != this)


            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);


        InitGame();
    }


    void InitGame()
    {

        //  boardScript.SetupScene(level);
        player1Score = 0;
        player2Score = 0;
        initPosP1 =  p1.transform.position;
        initPosP2 =  p2.transform.position;
        initPosBall = ball.transform.position;
        
           }



    

    void OnEnable()
    {
        ScoreManager.OnScoreL += ScoreL;
        ScoreManager.OnScoreR += ScoreR;
        EndGame.onNewGame += Reset;
    } 

    void OnDisable()
    {
        ScoreManager.OnScoreL -= ScoreL;
        ScoreManager.OnScoreR -= ScoreR;
        EndGame.onNewGame -= Reset;
    }

    public void ScoreL()
    {
        player1Score++;
        Debug.Log("Player 1 Score " + player1Score);
        //OnScore();
        Invoke("Restart", restartDelay);
    }

    public void ScoreR()
    {
        player2Score++;

        Debug.Log("Player 2 Score " + player2Score);
        
        Invoke("Restart", restartDelay);
    }

    void Restart(){
        p1.transform.position = initPosP1;
        p2.transform.position = initPosP2;
        ball.transform.position = initPosBall;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        p1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        p2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
   
    }

    void Reset()
    {
        Restart();
        player1Score = 0;
        player2Score = 0;
    }

    

}
