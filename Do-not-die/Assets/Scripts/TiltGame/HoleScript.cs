using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {
    public GameObject Main;
    private void Start()
    {
        Main = GameObject.Find("MainController");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        loseGame();
    }
    //Loses Game
    public void loseGame()
    {

        Main.GetComponent<MainController>().loselife();

    }
}
