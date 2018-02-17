using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour {

    public GameObject main;
    float timerstart = 0f;
    float timer = 100;
    public GameObject slider;
    public GameObject cube;
    public GameObject swipeSpawn;
    
    int diff;
    
    // Use this for initialization
	void Start () {
        main = GameObject.Find("MainController");
        slider = GameObject.Find("TimeBar");
        
       
        diff = main.GetComponent<MainController>().difficulty;
        if(diff < 5)
        {
            timerstart = 5f;
            
        }
        else
        {
            timerstart = 3f;
            
        }

        timer = timerstart;
        slider.GetComponent<Slider>().maxValue = timerstart;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(cube.GetComponent<CubeCollision>().Trigger.Equals(true))
        {
            main.GetComponent<MainController>().loselife();
        }
        timer = timer - Time.deltaTime;
        slider.GetComponent<Slider>().value = timer;

        if(timer < 0)
        {
            main.GetComponent<MainController>().LoadScene();
        }

	}
}
