using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

    public GameObject Main;
    
    float Timer = 100;
    int diff;
    
    // Use this for initialization
	void Start () {
        Main = GameObject.Find("MainController");
       
        diff = Main.GetComponent<MainController>().difficulty;
        if(diff < 5)
        {
            Timer = 5f;
        }
        else
        {
            Timer = 3f;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Timer = Timer - Time.deltaTime;

        if(Timer < 0)
        {
            Main.GetComponent<MainController>().LoadScene();
        }

	}
}
