﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMan : MonoBehaviour {

    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.name == "Ground" || collision.gameObject.name == "Ground 2"))
        {
            isDead = true;
        } 
    }
}
