﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMan : MonoBehaviour {


    public float upForce = 450f;
    public float fallMultiplier = 3f;
    public GameObject JumpMain;

    private bool isTouchingGround = false;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    
	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
            if (isTouchingGround && Input.GetMouseButton(0))
            {
                    isTouchingGround = false;
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
            }
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.name == "Ground" || collision.gameObject.name == "Ground 2"))
        {
            JumpMain.GetComponent<JumpController>().loseTheGame();
        }
        else
        {
            isTouchingGround = true;
        } 
    }
}
