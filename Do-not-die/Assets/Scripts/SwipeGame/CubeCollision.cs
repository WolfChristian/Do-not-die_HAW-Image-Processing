using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CubeCollision destroys the meteorite after the collision
public class CubeCollision : MonoBehaviour {

    private bool trigger = false;

    public bool Trigger
    {
        get
        {
            return trigger;
        }

        set
        {
            trigger = value;
        }
    }



    //Destroy meteorite on collision
    void OnTriggerEnter(Collider collision)
    {
        Trigger = true;
        Destroy(collision.gameObject);
    }
}
