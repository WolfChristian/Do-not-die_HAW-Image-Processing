using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHoleScript : MonoBehaviour {
    private GameObject Main;
    //Searches for the MainController
    void Start () {
        Main = GameObject.Find("MainController");
    }
    //If somethings enters the collider call the winGame() function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        winGame();
    }
    //Wins game by callin the LoadScene() function of the MainController
    private void winGame()
    {
        Main.GetComponent<MainController>().LoadScene();
    }
}
