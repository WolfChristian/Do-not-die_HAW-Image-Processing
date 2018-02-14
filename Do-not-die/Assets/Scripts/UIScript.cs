using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour {

    public Image heart1, heart2, heart3;
    public GameObject Main;
    private int health;

    // Use this for initialization
    void Start () {
        Main = GameObject.Find("MainController");
        health = Main.GetComponent<MainController>().life;
        
    }
	
	
	void fixUpdate () {
        
		
	}
    public void updateLife()
    {
        health = Main.GetComponent<MainController>().life;
        Debug.Log(health);
        switch (health)
        {
            case 3:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                break;
            case 2:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
                break;
            case 1:
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
            case 0:
                break;

        }
    }

}
