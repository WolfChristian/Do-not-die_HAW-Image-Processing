using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public GameObject Main;
    public GameObject Slider;
    float Timer = 100;
    int diff;
    public int food, recycle=0;
    // Use this for initialization
    void Start()
    {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().difficulty;
        if (diff < 5) {
            Timer = 8f;
        }
        else
        {
            Timer = 7f;
        }

        Slider.GetComponent<Slider>().maxValue = Timer;
    }

    void FixedUpdate()
    {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;

        if (Timer < 0)
        {

            Main.GetComponent<MainController>().loselife();
        }
        else if (food==2&&recycle==2) {
            Main.GetComponent<MainController>().LoadScene();
        }
    }
    public void loseGame()
    {

        Main.GetComponent<MainController>().loselife();

    }
}
