using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotate : MonoBehaviour {

    private Vector2 mouseScreenPosition;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButton(0))
        {
            mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

            transform.up = direction;
        }
    }
}
