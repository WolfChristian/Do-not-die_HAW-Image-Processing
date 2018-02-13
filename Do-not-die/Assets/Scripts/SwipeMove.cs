﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour {

    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

	// Update is called once per frame
	void FixedUpdate () {

        if (swipeControls.SwipeLeft)
            desiredPosition += Vector3.left;
        if (swipeControls.SwipeRight)
            desiredPosition += Vector3.right;
        if (swipeControls.SwipeUp)
        {
            Debug.Log("SwipeUP");
            desiredPosition += Vector3.up;
        }

            
        if (swipeControls.SwipeDown)
            desiredPosition += Vector3.down;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);
	}
}
