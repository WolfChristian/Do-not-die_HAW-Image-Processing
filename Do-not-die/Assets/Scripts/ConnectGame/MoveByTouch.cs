using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour {

    public GameObject Controller;

    private bool activ = false;
    private int nameInInt;
    private bool finished = false;
    private bool mouseOver = false;
    private LineRenderer line;
    // Use this for initialization
    void Start () {
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
        mouseOver = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == Controller.GetComponent<GameController>().getName(nameInInt))
        {
            finished = true;
            Debug.Log("Hello");
        }
    }
    void FixedUpdate () {
        line.SetPosition(0, Controller.GetComponent<GameController>().getStartVector(nameInInt));
        line.SetPosition(1, Controller.GetComponent<GameController>().getMovingPointVector(nameInInt));

        if (!finished && mouseOver && Input.GetMouseButtonDown(0))
        {
            activ = true;
        }
            if (Input.GetMouseButton(0) && activ)
            {
                var pos = Input.mousePosition;
                pos.z = 45;
                pos = Camera.main.ScreenToWorldPoint(pos);
                transform.position = pos;
            }
            else
            {
                transform.position = Controller.GetComponent<GameController>().getStartVector(nameInInt);
                mouseOver = false;
                activ = false;
            }
        
        if(finished)
        {
            transform.position = Controller.GetComponent<GameController>().getEndVector(nameInInt);
        }
    }
}
