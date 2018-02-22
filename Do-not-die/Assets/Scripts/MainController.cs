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
    public int rand;
    //When loading
    private void Awake() {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(gameUI);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	
	void FixedUpdate () {
		
	}

    public void LoadScene()
    {
        
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

    private IEnumerator LevelChange()
    {
        yield return new WaitForSeconds(3f);
        gameUI.SetActive(true);
        SceneManager.LoadScene(rand);
        yield return new WaitForSeconds(0.15f);
        timeBar.transform.localScale = new Vector3(1, 1, 1);




    }

    //Lose 1 life update UI calls checklife
    public void loselife() {
        life--;
        gameUI.GetComponent<UIScript>().updateLife();
        checkLife();
        
    }
    //Checks your lifetotal and sends you to Gameover Scene
    private void checkLife() {
        if (life <= 0)
        {
            SceneManager.LoadScene(1);
           // difficulty = 0;
            life = 3;
        }
        else {
            LoadScene();
        }
    }
    
    

}

