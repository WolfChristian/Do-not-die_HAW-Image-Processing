using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpController : MonoBehaviour {
    
    public float scrollSpeed = -10f;
    public GameObject Main;
    float Timerstart = 0f;
    float Timer = 100;
    public GameObject Slider;

    public int scoreCheck = 0;
    int diff;

    // Use this for initialization
    void Start()
    {
        
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        

        diff = Main.GetComponent<MainController>().difficulty;
        //diff = 2;
        if (diff < 5)
        {
            Timerstart = 5f;
        }else if (diff > 10)
        {
            scrollSpeed = -20f;
        }
        else
        {
            scrollSpeed = -15f;
        }

        Timer = Timerstart;
        Slider.GetComponent<Slider>().maxValue = Timerstart;
    }
    public void ScoreChange()
    {
        scoreCheck++;
        if (scoreCheck > 3) {
            Main.GetComponent<MainController>().LoadScene();
        }
    }
    public void loseTheGame()
    {
        Main.GetComponent<MainController>().loselife();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;

        if (Timer < 0)
        {
            //Main.GetComponent<MainController>().LoadScene();
        }
    }
}

