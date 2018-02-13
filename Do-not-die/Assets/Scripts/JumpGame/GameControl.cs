using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject gameOverText;
    public bool gameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ManDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
