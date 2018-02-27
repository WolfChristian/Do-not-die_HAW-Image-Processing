using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMan : MonoBehaviour
{

    [SerializeField] private GameObject JumpMain;

    private float upForce = 85f;
    private float fallMultiplier = 2.5f;
    private bool isTouchingGround = false;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 4f; //gravity is changed for a better jump experience
    }

    void FixedUpdate()
    {
        if (isTouchingGround && Input.GetMouseButton(0)) // starts the jump
        {
            isTouchingGround = false;
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce * 10));
        }
        if (rb2d.velocity.y < 0) // increases the jump gravity during the fall
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.name == "Ground" || collision.gameObject.name == "Ground 2"))
        {
            JumpMain.GetComponent<JumpController>().loseTheGame(); //lose condition
        }
        else
        {
            isTouchingGround = true;
        }
    }
}
