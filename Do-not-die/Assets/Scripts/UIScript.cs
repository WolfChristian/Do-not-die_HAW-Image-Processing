using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour {

    [SerializeField] private Image heart1, heart2, heart3;
    private GameObject Main;
    private int health;

    // Finds the MainController and gets the initial lifecount
    void Start () {
        Main = GameObject.Find("MainController");
        health = Main.GetComponent<MainController>().Life;       
    }
	
	//Checks the lifecounter of the MainController and shows depending on the value a certain number of hearts.
    public void updateLife(){
        health = Main.GetComponent<MainController>().Life;
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
