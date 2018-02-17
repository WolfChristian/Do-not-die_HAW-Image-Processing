using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private float speed;
    private Rigidbody2D rb2d;


    public GameObject JumpMain;

    
    // Use this for initialization
    void Start () {
        speed = JumpMain.GetComponent<JumpController>().scrollSpeed;
        //speed = -1.5f;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
	}	
	// Update is called once per frame
	void FixedUpdate() {
		
	}
}
