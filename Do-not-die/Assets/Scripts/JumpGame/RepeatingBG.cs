using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x * 2.318501f;

    }

    void FixedUpdate()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBG();
        }
    }

    private void RepositionBG() //set the background or the floor back to the start position
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
