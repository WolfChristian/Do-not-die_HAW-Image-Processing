using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour {

    private bool trigger = false;

    public bool Trigger
    {
        get
        {
            return trigger;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider collision)
    {
        trigger = true;
        Destroy(collision.gameObject);
    }
}
