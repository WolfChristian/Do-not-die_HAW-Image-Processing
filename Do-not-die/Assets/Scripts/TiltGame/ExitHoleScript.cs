using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHoleScript : MonoBehaviour {
    public GameObject Main;

    void Start () {
        Main = GameObject.Find("MainController");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        winGame();
    }

    public void winGame()
    {
        Main.GetComponent<MainController>().LoadScene();
    }
}
