using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpController : MonoBehaviour {
    
    private float scrollSpeed = -10;
    private GameObject Main;
    private float Timerstart = 0f;
    private float Timer = 100;
    private GameObject Slider;

    private int scoreCheck = 0;
    private int diff;

    public float ScrollSpeed // used in ScrollingObject 
    {
        get
        {
            return scrollSpeed;
        }

        set
        {
            scrollSpeed = value;
        }
    }

    void Start()
    {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().Difficulty;
        //changes the gamespeed depending on the difficulty
        Timerstart = 5.35f;
        if (diff < 5)
        {
            
        }else if (diff > 10)
        {
            ScrollSpeed = -20f;
        }
        else
        {
            ScrollSpeed = -15f;
        }

        Timer = Timerstart;
        Slider.GetComponent<Slider>().maxValue = Timerstart;
    }
    public void ScoreChange() //called by Obstacle / changes the score
    {
        scoreCheck++;
        if (scoreCheck > 3) {
            Debug.Log(Timer);
            Main.GetComponent<MainController>().LoadScene(); // win condition
        }
    }
    public void loseTheGame() // called by JumpMan
    {
        Main.GetComponent<MainController>().Loselife(); // lose condition
    }

    void FixedUpdate()
    {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;
        if (Timer < 0)
        {
            Main.GetComponent<MainController>().LoadScene(); // backup lose condition
        }
    }
}

