using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotate : MonoBehaviour {

    private Vector2 mouseScreenPosition;
    private Vector2 direction;
    private Vector2 startPoint;
    private float angleCounter = 0.0f;
    private float angle = 0.0f;
    private int score;

    public GameObject SpinningMain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(startPoint);
        }
        if (Input.GetMouseButton(0))
        {
            mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
            transform.up = direction;

            angle = Vector2.Angle(startPoint, mouseScreenPosition);
            angleCounter += angle;
            if (score < Mathf.RoundToInt((angleCounter - (angleCounter % 360)) / 360))
            {
                Debug.Log(score);
                if(score == 5)
                {
                    SpinningMain.GetComponent<SpinningController>().winTheGame();
                }
            }
            score = Mathf.RoundToInt((angleCounter - (angleCounter % 360)) / 360);
            startPoint = mouseScreenPosition;
        }
    }
}
