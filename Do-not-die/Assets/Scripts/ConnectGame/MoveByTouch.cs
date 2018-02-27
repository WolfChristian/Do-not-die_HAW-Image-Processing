using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{

    private bool moveAllowed = false;
    private GameObject Controller;
    private bool finished = false;
    private int nameInInt;
    private LineRenderer line;


    void Start()
    {
        transform.localScale *= 2f; // changes the size for better visual visibility
        nameInInt = System.Convert.ToInt32(this.gameObject.name); // nameInInt is used for identifing the prefab
        Controller = GameObject.Find("GameController");
        transform.position = Controller.GetComponent<GameController>().getStartVector(nameInInt);

        //sets the parameters for the LineRender
        line = this.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.positionCount = 2;
    }

    private void OnTriggerEnter2D(Collider2D other) //checks for the right connection
    {
        if (other.gameObject.name == Controller.GetComponent<GameController>().getName(nameInInt))
        {
            finished = true;
            Controller.GetComponent<GameController>().countConnections();
        }
    }
    void FixedUpdate()
    {
        //paints the line between the points
        line.SetPosition(0, Controller.GetComponent<GameController>().getStartVector(nameInInt));
        line.SetPosition(1, Controller.GetComponent<GameController>().getMovingPointVector(nameInInt));

        if (finished) //if the connection was successful, the input is redirected to this statement
        {
            transform.position = Controller.GetComponent<GameController>().getEndVector(nameInInt);
        }
        else // if the connection was not successful jet, checks for touch input
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                switch (touch.phase)
                {
                    //If the object is touched you are able to move it
                    case TouchPhase.Began:

                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        {
                            moveAllowed = true;
                            transform.position = touchPos;
                        }
                        break;
                    //While movemen is allowed set the position of the object to new position of the touch input
                    case TouchPhase.Moved:
                        if (moveAllowed)
                        {
                            transform.position = touchPos;
                        }
                        break;
                    //If the touch input ends objects is not allowed to move again
                    case TouchPhase.Ended:
                        moveAllowed = false;
                        transform.position = Controller.GetComponent<GameController>().getStartVector(nameInInt);
                        break;
                }
            }
        }
    }
}
