using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

    private int difficulty = 0;
    private int life = 3;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject timeBar;
    private int lastLevel=0;
    private int lastLevel2 = 0;
    public int rand;
    private bool loadedLevel = false;
    [SerializeField] private GameObject flashScreen;

    public int Difficulty
    {
        get
        {
            return difficulty;
        }

        set
        {
            difficulty = value;
        }
    }

    public int Life
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
    }

    //Prevents the MainController and the UI to be destroyed on change of levels
    private void Awake() {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(gameUI);
    }
   
    //Loads new random level but not the same as before.
    //Increases the difficulty by one.
    public void LoadScene(){       
        rand = UnityEngine.Random.Range(3, 11);

        while (rand == lastLevel||rand ==lastLevel2) {
            rand = UnityEngine.Random.Range(3, 11);
        }
            lastLevel2 = lastLevel;
            lastLevel = rand;            
            SceneManager.LoadScene(2);
            Difficulty++;
            StartCoroutine(LevelChange());
            gameUI.SetActive(false);
            timeBar.transform.localScale = new Vector3(0, 0, 0);
            

    }
    //Subroutine for the crossingscene inbetween levels.
    private IEnumerator LevelChange(){
        flashScreen.SetActive(false);
        yield return new WaitForSeconds(3f);
        gameUI.SetActive(true);
        SceneManager.LoadScene(rand);
        yield return new WaitForSeconds(0.15f);
        timeBar.transform.localScale = new Vector3(1, 1, 1);
    }

    //Lose 1 life updates UI and calls checklife().
    public void Loselife() {
        if(loadedLevel == false)
        {
            loadedLevel = true;
            StartCoroutine(LostLife());
        }
             
    }

    private IEnumerator LostLife()
    {
       
        Life--;
        flashScreen.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        gameUI.GetComponent<UIScript>().updateLife();
        CheckLife();
    }

    //Checks your lifetotal and sends you to Gameover Scene if lifetotal is 0.
    private void CheckLife() {
        if (Life <= 0)
        {   
            //Resets the lifetotal
            SceneManager.LoadScene(1);          
            Life = 3;
        }
        else {
            LoadScene();
            
            loadedLevel = false;
        }
    }
    
    

}

