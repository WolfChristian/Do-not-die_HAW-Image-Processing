using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public GameObject JumpMain;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "JumpMan")
        {
            JumpMain.GetComponent<JumpController>().ScoreUpdate();
            Debug.Log("Hello");
        }
    }


}
