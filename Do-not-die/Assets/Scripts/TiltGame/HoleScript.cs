using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {
    private GameObject Main;
    //Searches for the MainController
    private void Start()
    {
        Main = GameObject.Find("MainController");
    }
    //If somethings enters the collider call the loseGame() function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        loseGame();
    }
    //Loses game by callin the loselife() function of the MainController
    private void loseGame()
    {
        Main.GetComponent<MainController>().Loselife();
    }
}
