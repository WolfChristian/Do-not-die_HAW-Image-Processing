using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TiltController : MonoBehaviour {
    public GameObject Main;
    public GameObject Slider;
    public GameObject level1, level2, level3;
    float Timer = 100;
    int diff;
    // Use this for initialization
    void Start () {
        Main = GameObject.Find("MainController");
        Slider = GameObject.Find("TimeBar");
        diff = Main.GetComponent<MainController>().difficulty;
        
        if (diff < 5) {
            Timer = 8f;
            Instantiate(level1, new Vector3(2.166283f, 0.5105593f,0), Quaternion.identity);
        }
        else if (diff > 5 && diff < 10) {
            Timer = 7f;
            if (Random.value > 0.5)
            {
                Instantiate(level2, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
            else {
                Instantiate(level1, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
        }
        else {
            Timer =6f;
            if (Random.value > 0.3)
            {
                Instantiate(level3, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
            else if (Random.value > 0.3)
            {
                Instantiate(level2, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
            else {
                Instantiate(level1, new Vector3(2.166283f, 0.5105593f, 0), Quaternion.identity);
            }
        }


    }

   
    void FixedUpdate () {
        Timer = Timer - Time.deltaTime;
        Slider.GetComponent<Slider>().value = Timer;
        
       if (Timer < 0)
        {

            loseGame();
        }
    }

  
    public void loseGame() {
       
        Main.GetComponent<MainController>().loselife();

    }
}
