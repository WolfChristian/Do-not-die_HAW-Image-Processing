using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
    }
    void Quit() {
        SceneManager.LoadScene(0);
    }
}
