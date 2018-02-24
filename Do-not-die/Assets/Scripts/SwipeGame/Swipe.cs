using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Swipe class adds the ability to let the game recognize swipes on the screen.
public class Swipe : MonoBehaviour
{

    [SerializeField] private GameObject Ui;
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;

    public bool Tap
    {
        get
        {
            return tap;
        }

        set
        {
            tap = value;
        }
    }

    public bool SwipeLeft
    {
        get
        {
            return swipeLeft;
        }

        set
        {
            swipeLeft = value;
        }
    }

    public bool SwipeRight
    {
        get
        {
            return swipeRight;
        }

        set
        {
            swipeRight = value;
        }
    }

    public bool SwipeUp
    {
        get
        {
            return swipeUp;
        }

        set
        {
            swipeUp = value;
        }
    }

    public bool SwipeDown
    {
        get
        {
            return swipeDown;
        }

        set
        {
            swipeDown = value;
        }
    }

    private void Start()
    {
        Ui = GameObject.Find("UIComponents");
    }

    private void FixedUpdate()
    {
        // Reset all values to not fire them off multiple times
        Tap = SwipeLeft = SwipeRight = SwipeUp = SwipeDown = false;

        // Save tap for mouse control (Only editor)
        if (Input.GetMouseButtonDown(0))
        {
            Tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }

        // Save tap for touch control (for smartphone)
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }

        // Calculate the distance

        swipeDelta = Vector2.zero;
        if (isDraging && !Ui.GetComponent<PauseMenu>().gameIsPaused)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;

            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //Did we cross the deadzone?
        if (swipeDelta.magnitude > 30)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or right
                if (x < 0)
                    SwipeLeft = true;
                else
                    SwipeRight = true;
            }
            else
            {
                //Up or down
                if (y < 0)
                {
                    Debug.Log("Down!!");
                    SwipeDown = true;
                }
                else
                    SwipeUp = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        isDraging = false;
        startTouch = swipeDelta = Vector2.zero;
    }

  


}
