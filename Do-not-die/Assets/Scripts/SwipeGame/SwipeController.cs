using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The SwipeController sets the difficulty of the game and the win/lose conditions.
public class SwipeController : MonoBehaviour {

    private GameObject main;
    private float timerstart = 0f;
    private float timer = 100;
    private GameObject slider;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject swipeSpawn;
    
    private int diff;

    public int Diff
    {
        get
        {
            return diff;
        }

        set
        {
            diff = value;
        }
    }

    // Use this for initialization
    void Start () {
        main = GameObject.Find("MainController");
        slider = GameObject.Find("TimeBar");
        
       // set game difficulty
        Diff = main.GetComponent<MainController>().Difficulty;
        if(Diff < 5)
        {
            timerstart = 5f;
            
        }
        else if(Diff < 10)
        {
            timerstart = 8f;
            
        }
        else
        {
            timerstart = 12f;
        }


        timer = timerstart;
        slider.GetComponent<Slider>().maxValue = timerstart;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        // lose the game if the player character collides with a meteorite
        if (cube.GetComponent<CubeCollision>().Trigger == true)
        {
            main.GetComponent<MainController>().Loselife();
        }
        timer = timer - Time.deltaTime;
        slider.GetComponent<Slider>().value = timer;

        // win the game when the time is over
        if(timer < 0)
        {
            main.GetComponent<MainController>().LoadScene();
        }

	}
}
