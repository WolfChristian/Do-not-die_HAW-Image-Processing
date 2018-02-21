using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public Rigidbody2D ball;

    public float moveSpeed = 0.8f;

    float dirX, dirY;

	// Use this for initialization
	void Start () {
        ball.GetComponent<Rigidbody2D>();

	}

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;
        dirY = Input.acceleration.y * moveSpeed;
       // transform.Translate(dirX, dirY, 0);

    }
    void 
        FixedUpdate () {
        
        ball.velocity = new Vector2(ball.velocity.x + dirX, ball.velocity.y + dirY);

    }
}
