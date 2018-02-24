using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The SwipeMove class moves the player character on swipes.
public class SwipeMove : MonoBehaviour {

    [SerializeField] private Swipe swipeControls;
    [SerializeField] private Transform player;
    private Vector3 desiredPosition;

    private void Start()
    {
        desiredPosition = player.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate () {

        // Move left
        if (swipeControls.SwipeLeft && player.position.x > -3)
            desiredPosition += Vector3.left*2;

        // Move right
        if (swipeControls.SwipeRight && player.position.x < 3)
            desiredPosition += Vector3.right*2;
      
        // Fire movement
        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 9f * Time.deltaTime);
	}
}
