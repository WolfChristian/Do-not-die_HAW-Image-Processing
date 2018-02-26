using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    //Contains all function for the PauseMenu
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    
    
   
    //Resumes the game if it was paused
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
    //Pauses game 
    public void Pause() {
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }
    //Quits the game and sends you to the GameOverScreen
    public void Quit() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);          
    }
    
}
