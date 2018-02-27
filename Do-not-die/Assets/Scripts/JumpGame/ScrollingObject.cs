using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    private float speed;
    private Rigidbody2D rb2d;
    private GameObject JumpMain;

    void Start()
    { //sets the speed of movement
        JumpMain = GameObject.Find("GameController");
        speed = JumpMain.GetComponent<JumpController>().ScrollSpeed;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
    }
}
