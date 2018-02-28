using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOverController : MonoBehaviour {
    private GameObject Main;
    [SerializeField] private Text score;
    private int diff = 0;
    // Resets the Game by deleting the MainController and GameUI
    void Start () {
        Main = GameObject.Find("MainController");
        diff = Main.GetComponent<MainController>().difficulty;
        score.text="Your Score: "+diff;
        Main.GetComponent<MainController>().difficulty = 0;
        Destroy(Main);
        Destroy(GameObject.Find("GameUI"));
    }
	//Loads the MainMenu scene
    public void returnToMainMenu() {
        
        SceneManager.LoadScene(0);
        
    }
}
