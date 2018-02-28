using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMovement : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;
    private bool moveAllowed = false;
    private float x, y;
    //Get the Rigidbody2d component of the object
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    /*
     * Checks if the GameObject was touched and moves it according to the movement of the input. 
     */
    void FixedUpdate () {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase) {
                //If the object is touched you are able to move it
                case TouchPhase.Began:

                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {

                        x = touchPos.x - transform.position.x;
                        y = touchPos.y - transform.position.y;

                        moveAllowed = true;

                        rb.freezeRotation = true;
                        rb.velocity = new Vector2(0, 0);
                        rb.gravityScale = 0;

                    }
                    break;
               //While movemen is allowed set the position of the object to new position of the touch input
                case TouchPhase.Moved:
                    if (moveAllowed)
                    {
                        rb.MovePosition(new Vector2(touchPos.x - x, touchPos.y - y));
                    }
                    break;
                //If the touch input ends objects is not allowed to move again
                case TouchPhase.Ended:
                    moveAllowed = false;
                    rb.freezeRotation = false;
                    rb.gravityScale = 2;
                    break;


            }
        }
	}
}
