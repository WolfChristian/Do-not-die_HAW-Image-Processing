using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotate : MonoBehaviour
{
    /*
     * checks the movement of the input in angles
     */
    private Vector2 mouseScreenPosition;
    private Vector2 direction;
    private Vector2 startPoint;
    private float angleCounter = 0.0f;
    private float angle = 0.0f;
    private int score = 0;
    [SerializeField] private GameObject SpinningMain;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) //if the screen is touched for the first time
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0)) //if the screen is touched 
        {
            mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
            transform.up = direction;

            angle = Vector2.Angle(startPoint, mouseScreenPosition);
            angleCounter += angle;
            if (score >= 5)
            {
                //ends the Game at 5 times 360 degrees
                SpinningMain.GetComponent<SpinningController>().winTheGame();
            }
            //updates the score if a change of 360 degrees happens
            score = Mathf.RoundToInt((angleCounter - (angleCounter % 360)) / 360);
            startPoint = mouseScreenPosition;
        }
    }
}
