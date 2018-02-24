using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour {

    public GameObject StartPoint;
    public GameObject EndPoint;

    private bool finished = false;
    private bool mouseOver = false;

    // Use this for initialization
    void Start () {
        transform.position = StartPoint.transform.position;
	}

    private void OnMouseOver()
    {
        mouseOver = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PointB")
        {
            finished = true;
            Debug.Log("Hello");
        }
    }
    void FixedUpdate () {
        if (!finished && mouseOver)
        {
            if (Input.GetMouseButton(0))
            {
                var pos = Input.mousePosition;
                pos.z = 45;
                pos = Camera.main.ScreenToWorldPoint(pos);
                transform.position = pos;
            }
            else
            {
                transform.position = StartPoint.transform.position;
                mouseOver = false;
            }
        }
        else if(finished)
        {
            transform.position = EndPoint.transform.position;
        }
    }
}
