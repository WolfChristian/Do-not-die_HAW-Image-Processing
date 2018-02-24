using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Swipe class adds the ability to let the game recognize swipes on the screen.
public class Swipe : MonoBehaviour
{

    [SerializeField] private GameObject Ui;
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;


    private void Start()
    {
        Ui = GameObject.Find("UIComponents");
    }

    private void FixedUpdate()
    {
        // Reset all values to not fire them off multiple times
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        // Save tap for mouse control (Only editor)
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
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
                tap = true;
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
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or down
                if (y < 0)
                {
                    Debug.Log("Down!!");
                    swipeDown = true;
                }
                else
                    swipeUp = true;
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
