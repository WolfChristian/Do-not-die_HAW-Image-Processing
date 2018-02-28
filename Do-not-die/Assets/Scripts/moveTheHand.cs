using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTheHand : MonoBehaviour
{
    private float Timerstart = 1f;
    private float Timer = 100;
    private Vector3 position1;
    private Vector3 position2;


    void Start()
    {
        Timer = Timerstart;
        position1 = gameObject.transform.position;
        if (position1.x < 0)
        {
            position2 = gameObject.transform.position + new Vector3(1f, 0f, 0f);
        }
        else
        {
            position2 = gameObject.transform.position + new Vector3(-1f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        Timer = Timer - Time.deltaTime;

        if (Timer < 0) //reset Timer
        {
            Timer = Timerstart;
        }
        else if (Timer >= (Timerstart / 2))
        {
            gameObject.transform.position = position1;
        }
        else if (Timer <= (Timerstart / 2))
        {
            gameObject.transform.position = position2;
        }
    }
}
