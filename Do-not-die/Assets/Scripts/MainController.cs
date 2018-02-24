using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

    public int difficulty = 0;
    public int life = 3;
    public GameObject gameUI;
    public GameObject timeBar;
    private int lastLevel=0;
    private int lastLevel2 = 0;
    private int rand;
    //Prevents the MainController and the UI to be destroyed on change of levels
    private void Awake() {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(gameUI);
    }
   
    //Loads new random level but not the same as before.
    //Increases the difficulty by one.
    public void LoadScene(){       
        rand = UnityEngine.Random.Range(3, 10);

        while (rand == lastLevel||rand ==lastLevel2) {
            rand = UnityEngine.Random.Range(3, 10);
        }
            lastLevel2 = lastLevel;
            lastLevel = rand;            
            SceneManager.LoadScene(2);
            difficulty++;
            StartCoroutine(LevelChange());
            gameUI.SetActive(false);
            timeBar.transform.localScale = new Vector3(0, 0, 0);
           
    }
    //Subroutine for the crossingscene inbetween levels.
    private IEnumerator LevelChange(){
        yield return new WaitForSeconds(3f);
        gameUI.SetActive(true);
        SceneManager.LoadScene(rand);
        yield return new WaitForSeconds(0.15f);
        timeBar.transform.localScale = new Vector3(1, 1, 1);
    }

    //Lose 1 life updates UI and calls checklife().
    public void loselife() {
        life--;
        gameUI.GetComponent<UIScript>().updateLife();
        checkLife();      
    }

    //Checks your lifetotal and sends you to Gameover Scene if lifetotal is 0.
    private void checkLife() {
        if (life <= 0)
        {   
            //Resets the lifetotal
            SceneManager.LoadScene(1);          
            life = 3;
        }
        else {
            LoadScene();
        }
    }
    
    

}

