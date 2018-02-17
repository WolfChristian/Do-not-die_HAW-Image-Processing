using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {


    private float Timer;
	// Use this for initialization
	void Start () {
        Timer = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Timer = Timer - Time.deltaTime;
        transform.Translate(Vector3.down * Time.deltaTime*5);

        if(Timer <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
