using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMovement : MonoBehaviour {
    public Rigidbody2D rb;
    bool moveAllowed = false;
    float x, y;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase) {

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
                case TouchPhase.Moved:
                    if (moveAllowed)
                    {
                        rb.MovePosition(new Vector2(touchPos.x - x, touchPos.y - y));
                    }
                    break;
                case TouchPhase.Ended:
                    moveAllowed = false;
                    rb.freezeRotation = false;
                    rb.gravityScale = 2;
                    break;


            }
        }
	}
}
