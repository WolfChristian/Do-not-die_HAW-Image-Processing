using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CubeCollision destroys the meteorite after the collision
public class CubeCollision : MonoBehaviour {

    public bool trigger = false;

   

    //Destroy meteorite on collision
    void OnTriggerEnter(Collider collision)
    {
        trigger = true;
        Destroy(collision.gameObject);
    }
}
