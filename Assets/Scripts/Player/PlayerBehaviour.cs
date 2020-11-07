using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Benjamin Schmidt 11/06/2020

public class PlayerBehaviour : MonoBehaviour
{

    //Number of jumps that the player can do before landing on the ground.
    public int jumpAmount = 2;
    //Velocity of the the player when it jumps.
    public float jumpSpeed = 4f;
    //Velocity of the character when walking.
    public float runSpeed = 100f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private bool jumped;
    private int jumpCurrent;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Get any player inputs and get ready for the physics update.
    void Update()
    {
        //Get player movement.
        horizontal = Input.GetAxisRaw("Horizontal");

        //Try to jump if we haven't already.
        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            jump();
        }
        else if (!jumped)
        {
            vertical = rb.velocity.y;
        }
    }

    //Physics stuff is in here.
    void FixedUpdate()
    {
        //Sets the player's new velocity.
        rb.velocity = new Vector2(horizontal*runSpeed*Time.deltaTime, vertical);
        jumped = false;
    }

    //First checks to see if the player is on the ground, and then jumps if they have any remaining.
    private void jump()
    {
        if (grounded())
        {
            jumpCurrent = 0;
        }

        if (jumpCurrent < jumpAmount)
        {
            jumped = true;
            jumpCurrent++;
            vertical = jumpSpeed;
        }
        else
        {
            vertical = rb.velocity.y;
        }
    }

    //Thanks Damien :)
    private bool grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));
        return hit;
    }
}
