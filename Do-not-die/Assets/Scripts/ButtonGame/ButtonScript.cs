using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public GameObject Main;
    // Use this for initialization
    void Start () {
        Main = GameObject.Find("MainController");
    }

    //Wins game 
    public void winGame()
    {
        Main.GetComponent<MainController>().LoadScene();
    }
    //Loses Game
    public void loseGame()
    {

        Main.GetComponent<MainController>().loselife();

    }
}
