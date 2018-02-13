using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    
	void Start () {
		
	}
	
	void Update () {
		
	}

   public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }
    public void Quit() {
        SceneManager.LoadScene(0);
    }
    
}
