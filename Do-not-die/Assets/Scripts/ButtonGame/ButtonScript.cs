using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    private GameObject Main;
    //Searches for the MainController
    void Start () {
        Main = GameObject.Find("MainController");
    }

    //Wins game if you push the button 
    public void winGame()
    {
        Main.GetComponent<MainController>().LoadScene();
    }
    //Loses game if you push the button
    public void loseGame()
    {
        Main.GetComponent<MainController>().Loselife();
    }
}
