﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour {

    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

    private void Start()
    {
        desiredPosition = player.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (swipeControls.SwipeLeft && player.position.x > -3)
            desiredPosition += Vector3.left*2;
        if (swipeControls.SwipeRight && player.position.x < 3)
            desiredPosition += Vector3.right*2;
      

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 9f * Time.deltaTime);
	}
}
