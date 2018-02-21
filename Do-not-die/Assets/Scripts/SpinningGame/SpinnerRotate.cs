using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotate : MonoBehaviour {

    private Vector2 mouse_position;
    private Transform target;
    private Vector2 object_position;
    private float angle;

    private Vector2 mouseScreenPosition;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseScreenPosition - (Vector2) transform.position).normalized;

        transform.up = direction;
        /*
        mouse_position = Input.mousePosition;
        angle = Mathf.Atan2(mouse_position.y, mouse_position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        */	
    }
}
