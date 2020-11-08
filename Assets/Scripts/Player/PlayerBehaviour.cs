using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Benjamin Schmidt 11/07/2020

public class PlayerBehaviour : MonoBehaviour
{
    //Checks to see if a player has entered a ghost's radius
    public bool ghostTrigger = false;
    public bool jellyTrigger = false;
<<<<<<< HEAD
    
=======

>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
    //Number of jumps that the player can do before landing on the ground.
    public int midairJumps = 1;
    //Velocity of the the player when it jumps.
    public float jumpSpeed = 4f;
    //Velocity of the character when walking.
    public float runSpeed = 100f;

    //Bone to throw
    public GameObject projectile;
<<<<<<< HEAD
    public int projectileNumber = 3;
=======
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e

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
<<<<<<< HEAD
        if(!moveDirection.Equals(0.0f))
=======
        if (!moveDirection.Equals(0.0f))
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
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

        //Throw bone
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Space) && projectileNumber > 0)
=======
        if (Input.GetKeyDown(KeyCode.Space) && GameControl.control.ammo > 0)
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
        {
            launch();
        }

        //Try to use Gravestones.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector2(lookDirection, 0f), 0.5f, LayerMask.GetMask("Gravestone"));
            if (hit.collider != null)
            {
                GravestoneBehaviour grave = hit.collider.GetComponent<GravestoneBehaviour>();
                if (grave != null)
                {
                    grave.ChangeDimension();
                }
            }
        }
    }

    //Physics stuff is in here.
    void FixedUpdate()
    {
        //Sets the player's new velocity.
<<<<<<< HEAD
        rb.velocity = new Vector2(moveDirection*runSpeed*Time.fixedDeltaTime, vertical);
        jumped = false;
=======
        rb.velocity = new Vector2(moveDirection * runSpeed * Time.fixedDeltaTime, vertical);
        jumped = false;
        anim.SetBool("Jumped", false);
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
    }

    //Throw bone
    private void launch()
    {
<<<<<<< HEAD
        projectileNumber--;
=======
        GameControl.control.ammo--;
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
        GameObject projectileObject = Instantiate(projectile, rb.position + Vector2.up * 0.1f + Vector2.right * lookDirection, Quaternion.identity);
        projectileObject.GetComponent<BoneBehaviour>().throwDirection = lookDirection;
    }

    //Jump.
    private void jump()
    {
        //Ground jump doesn't use midair jumps.
        if (grounded())
        {
            jumped = true;
            vertical = jumpSpeed;
<<<<<<< HEAD
=======
            anim.SetBool("Jumped", true);
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
        }

        //Midair jump.
        else if (currentJumps < midairJumps)
        {
            jumped = true;
            currentJumps++;
            vertical = jumpSpeed;
<<<<<<< HEAD
=======
            anim.SetBool("Jumped", true);
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
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
<<<<<<< HEAD
=======
        anim.SetBool("Grounded", hit);
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
        return hit;
    }

    //Ghost radius check
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            ghostTrigger = true;
<<<<<<< HEAD
        }else if (other.CompareTag("Jellyfish"))
=======
        }
        else if (other.CompareTag("Jellyfish"))
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
        {
            jellyTrigger = true;
        }

<<<<<<< HEAD
        
=======

>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
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
<<<<<<< HEAD
}
=======
}
>>>>>>> 40e1c09eb85c6197256dcc1c07fbdcc6a407f64e
