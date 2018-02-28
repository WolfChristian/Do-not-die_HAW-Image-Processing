using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinningController : MonoBehaviour
{
    private GameObject Main;
    private float Timerstart = 0f;
    private float Timer = 100;
    private GameObject Slider;

    private int diff;

    void Start()
    {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().difficulty;
        //changes the max timer depending on the difficulty
        if (diff < 5)
        {
            Timerstart = 5f;
        }
        else if (diff > 10)
        {
            Timerstart = 3f;
        }
        else
        {
            Timerstart = 4f;
        }

        Timer = Timerstart;
        Slider.GetComponent<Slider>().maxValue = Timerstart;
    }
    public void winTheGame() //is called by SpinnerRotate after 5 revolutions 
    {
        Main.GetComponent<MainController>().LoadScene();
    }
    void FixedUpdate() //takes care of the timer and the lose condition
    {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;

        if (Timer < 0) //lose condition
        {
            Main.GetComponent<MainController>().Loselife();
        }
    }
}

