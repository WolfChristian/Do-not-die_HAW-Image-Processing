using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour {
    public GameObject Main;
    float Timer = 100;
    int diff;
    // Use this for initialization
    void Start () {
        Main = GameObject.Find("MainController");

        //diff = Main.GetComponent<MainController>().difficulty;
        diff = 1;
        if (diff < 5) {
            Timer = 5f;
        }
        else if (diff > 5 && diff < 10) {
            Timer = 4f;
        }
        else {
            Timer = 3f;
        }


    }

    // Update is called once per frame
    void fixUpdate () {
		
	}
     //Wins game 
  
    public void loseGame() {
       
        Main.GetComponent<MainController>().loselife();

    }
}
