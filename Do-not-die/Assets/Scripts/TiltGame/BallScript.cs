using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public Rigidbody2D ball;
    private float moveSpeed = 0.8f;
    private float dirX, dirY;
    //Gets the Rigidbody2D of the ball for the update function
   	void Start () {
        ball.GetComponent<Rigidbody2D>();

	}

    /*
     * Updates the acceleration of the device in x and y direction.
     * Multiply the acceleration with the movesSpeed.
    */
    void Update()
    {

        dirX = Input.acceleration.x * moveSpeed;
        dirY = Input.acceleration.y * moveSpeed;
       

    }

    //Sets Velocity of the ball
    void FixedUpdate () {
        
        ball.velocity = new Vector2(ball.velocity.x + dirX, ball.velocity.y + dirY);

    }
    
}
