using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private GameObject JumpMain;

    void Start()
    {
        JumpMain = GameObject.Find("GameController");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "JumpMan")
        {
            JumpMain.GetComponent<JumpController>().ScoreChange(); //changes the score if JumpMan passes
        }
    }
}
