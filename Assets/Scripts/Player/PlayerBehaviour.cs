using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Benjamin Schmidt 11/06/2020

public class PlayerBehaviour : MonoBehaviour
{
    //Checks to see if a player has entered a ghost's radius
    public bool ghostTrigger = false;
    public bool jellyTrigger = false;
    
    //Number of jumps that the player can do before landing on the ground.
    public int midairJumps = 1;
    //Velocity of the the player when it jumps.
    public float jumpSpeed = 4f;
    //Velocity of the character when walking.
    public float runSpeed = 100f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private bool jumped;
    private int currentJumps;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Get any player inputs and get ready for the physics update.
    void Update()
    {
        //Get player movement.
        horizontal = Input.GetAxisRaw("Horizontal");

        //Check to see if the player is on the ground.
        if (grounded())
        {
            currentJumps = 0;
        }

        //Try to jump if we haven't already.
        if (Input.GetKeyDown(KeyCode.W) && !jumped)
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

    //Jump.
    private void jump()
    {
        //Ground jump doesn't use midair jumps.
        if (grounded())
        {
            jumped = true;
            vertical = jumpSpeed;
        }

        //Midair jump.
        else if (currentJumps < midairJumps)
        {
            jumped = true;
            currentJumps++;
            vertical = jumpSpeed;
        }

        //No jumps left.
        else
        {
            vertical = rb.velocity.y;
        }
    }

    //Thanks Damien :)
    private bool grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, LayerMask.GetMask("Ground"));
        return hit;
    }

    //Ghost radius check
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            ghostTrigger = true;
        }else if (other.CompareTag("Jellyfish"))
        {
            jellyTrigger = true;
        }

        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            ghostTrigger = false;
        }
        else if (other.CompareTag("Jellyfish"))
        {
            jellyTrigger = false;
        }
    }
}
