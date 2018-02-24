using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The MovementScript moves the meteorites.
public class MovementScript : MonoBehaviour {


    private float Timer;
	// Use this for initialization
	void Start () {
        Timer = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Timer = Timer - Time.deltaTime;
        
        // Move the meteorite; 
        transform.Translate(Vector3.down * Time.deltaTime*5);

        // Destroy the meteorite if it is not longer in game view
        if(Timer <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
