﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
 * Interacts with MainController
 * Spawns level depending on difficulty
 */
public class ButtonController : MonoBehaviour {

    private GameObject Main;
    private GameObject Slider;
    [SerializeField] private Text textfield;   
    [SerializeField] private GameObject buttonV1;//Spawnable button 1
    [SerializeField] private GameObject buttonV2;//Spawnable button 2
    private GameObject button;
    private float Timer = 100;
    private int diff;
    private bool isAlternative = false;//Indicator for alternative task
    /*Level generation
     *Sets Timer depending on difficulty
     *Spawns one of two possible buttons
     *Sets text in the Textfield
     */
    void Start () {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().Difficulty;
        
        if (diff <= 5)
        {
            Timer = 5f;
            button =Instantiate(buttonV1, new Vector3(0, 0, 0), Quaternion.identity);
            
            textfield.text = "Don't push";
        }
        else if(diff<10&&diff>5)
        {
            Timer = 4f;
            //%30 percent chance to spawn a alternative task
            if (Random.value > 0.3)
            {
                button = Instantiate(buttonV2, new Vector3(0, 0, 0), Quaternion.identity);
                
                textfield.text = "Do push";
                isAlternative = true;
            }
            else
            {
                button = Instantiate(buttonV1, new Vector3(0, 0, 0), Quaternion.identity);
               
                textfield.text = "Don't push";
            }
        }
        else
        {
            Timer = 3f;
            //20 percent chance to spawn a alternative task
            if (Random.value > 0.2)
            {
                button = Instantiate(buttonV2, new Vector3(0, 0, 0), Quaternion.identity);
               
                textfield.text = "Do what you want cause a pirate is free!!";
                
            }
            else
            {
                button = Instantiate(buttonV1, new Vector3(0, 0, 0), Quaternion.identity);
                
                textfield.text = "Don't push";
            }

        }
        
        Slider.GetComponent<Slider>().maxValue = Timer;

    }
	 /*
      *Counts down the time and sets the value of the slider.
      *Calls LoadScene() or LoseLife() after the time is over.
      */
	void FixedUpdate () {

        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;
        if (Timer < 0 && isAlternative == false)
        {
            Main.GetComponent<MainController>().LoadScene();
        }
        else if(Timer<0) {

            Main.GetComponent<MainController>().Loselife();
        }

    }
   
}
