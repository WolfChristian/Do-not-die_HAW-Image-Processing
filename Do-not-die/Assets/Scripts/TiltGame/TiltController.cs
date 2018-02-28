using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TiltController : MonoBehaviour {
    private GameObject Main;
    private GameObject Slider;
    [SerializeField] private GameObject level1, level2, level3;
    private float Timer = 100;
    private int diff;

      /*Level generation
      *Sets Timer depending on difficulty
      *Spawns one of three possible levels
      */
    void Start () {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().Difficulty;
        
        if (diff < 5) {
            Timer = 10f;
            Instantiate(level1, new Vector3(2.166283f, 0.5105593f,0), Quaternion.identity);
        }
        else if (diff > 5 && diff < 10) {
            Timer = 9f;
            //50% Chance of spawning level2
            if (Random.value > 0.5)
            {
                Instantiate(level2, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
            else {
                Instantiate(level1, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
        }
        else {
            Timer =7f;
            //30% Chance of spawning level3
            if (Random.value > 0.3)
            {
                Instantiate(level3, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
            //30% Chance of spawning level2
            else if (Random.value > 0.3)
            {
                Instantiate(level2, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
            else {
                Instantiate(level1, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
        }
        Slider.GetComponent<Slider>().maxValue = Timer;

    }

      /*
       *Counts down the time and sets the value of the slider.
       *Calls loseGame() after the time is over.
       */
    void FixedUpdate () {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;
        
       if (Timer < 0)
        {
            loseGame();
        }
    }

    //Loses game by calling loselife of the MainController
    private void loseGame() {
       
        Main.GetComponent<MainController>().Loselife();

    }
}
