using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour {

    private bool moveAllowed = false;
    private float x, y;

    public GameObject Controller;
    private bool finished = false;
    private int nameInInt;
    private LineRenderer line;

    //private bool activ = false;
    //private bool mouseOver = false;

    // Use this for initialization
    void Start () {
        transform.localScale *= 2f;
        nameInInt = System.Convert.ToInt32(this.gameObject.name);
        Controller = GameObject.Find("GameController");
        transform.position = Controller.GetComponent<GameController>().getStartVector(nameInInt);

        line = this.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.positionCount = 2;
    }

    private void OnMouseOver()
    {
        //mouseOver = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == Controller.GetComponent<GameController>().getName(nameInInt))
        {
            finished = true;
            Controller.GetComponent<GameController>().countConnections();
        }
    }
    void FixedUpdate () {
        line.SetPosition(0, Controller.GetComponent<GameController>().getStartVector(nameInInt));
        line.SetPosition(1, Controller.GetComponent<GameController>().getMovingPointVector(nameInInt));
        if(finished)
        {
            transform.position = Controller.GetComponent<GameController>().getEndVector(nameInInt);
        }else
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
