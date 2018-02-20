using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

    public int difficulty = 0;
    public int life = 3;
    public GameObject gameUI;

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
        int rand = Random.Range(2, 7);
        SceneManager.LoadScene(rand);
        difficulty++;


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

