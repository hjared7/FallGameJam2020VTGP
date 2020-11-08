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

    //Bone to throw
    public GameObject projectile;
    //Use 'GameControl.control.ammo' for ammo

    private Rigidbody2D rb;
    private Animator anim;
    private float moveDirection;
    private float lookDirection = 1;
    private float vertical;
    private bool jumped;
    private int currentJumps;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //Get any player inputs and get ready for the physics update.
    void Update()
    {
        //Get player movement.
        moveDirection = Input.GetAxisRaw("Horizontal");
        if(!moveDirection.Equals(0.0f))
        {
            lookDirection = moveDirection;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        anim.SetFloat("Direction", lookDirection);

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

        if (Input.GetKeyDown(KeyCode.Space) && GameControl.control.ammo > 0)
        {
            GameControl.control.ammo--;
            GameObject projectileObject = Instantiate(projectile , rb.position + Vector2.up * 0.1f + Vector2.right * lookDirection, Quaternion.identity);
            projectileObject.GetComponent<BoneBehaviour>().throwDirection = lookDirection;
        }
    }

    //Physics stuff is in here.
    void FixedUpdate()
    {
        //Sets the player's new velocity.
        rb.velocity = new Vector2(moveDirection*runSpeed*Time.fixedDeltaTime, vertical);
        jumped = false;
    }

    //Jump.
    private void jump()
    {

        Debug.Log("Jumped");

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));
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
