using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButton(0))
        {
            var pos = Input.mousePosition;
            pos.z = 45;
            pos = Camera.main.ScreenToWorldPoint(pos);
            transform.position = pos;
        }
    }
}
