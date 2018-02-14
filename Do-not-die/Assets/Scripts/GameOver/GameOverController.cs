using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOverController : MonoBehaviour {
    public GameObject Main;
    public Text score;
    private int diff = 0;
    // Use this for initialization
    void Start () {
        Main = GameObject.Find("MainController");
        diff = Main.GetComponent<MainController>().difficulty;
        score.text="Your Score: "+diff;
        Destroy(Main);
        Destroy(GameObject.Find("GameUI"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void returnToMainMenu() {
        
            SceneManager.LoadScene(0);
        
    }
}
