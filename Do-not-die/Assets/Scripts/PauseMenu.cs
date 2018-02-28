using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    //Contains all function for the PauseMenu
    private bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    public bool GameIsPaused
    {
        get
        {
            return gameIsPaused;
        }

        set
        {
            gameIsPaused = value;
        }
    }



    //Resumes the game if it was paused
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    //Pauses game 
    public void Pause() {
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    //Quits the game and sends you to the GameOverScreen
    public void Quit() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);          
    }
    
}
