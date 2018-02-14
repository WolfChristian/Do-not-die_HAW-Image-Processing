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
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    public void LoadScene()
    {
        int rand = Random.Range(1, 3);
        SceneManager.LoadScene(rand);
        difficulty++;


    }

    public void loselife() {
        life--;
        checkLife();
    }
    //Checks your lifetotal and sends you to Gameover Scene
    private void checkLife() {
        if (life <= 0)
        {
            //Scenemanager.LoadScene(x);
            difficulty = 0;
            life = 3;
        }
        else {
            LoadScene();
        }
    }
    public void loadMainMenu() {
        SceneManager.LoadScene(0);
    }

}

