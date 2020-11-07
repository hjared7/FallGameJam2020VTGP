using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BoneBehaviour : MonoBehaviour
{

    //Time before bone starts falling.
    public float falloffTimer = 1f;
    //Amount the bone falls by.
    public float falloffGravity = 1f;
    //Time befor bone despawns.
    public float despawnTimer = 3f;
    //Speed of bone when thrown.
    public float throwVelocity = 5f;
    //Direction to throw the bone.
    public float throwDirection;

    Rigidbody2D rb;
    BoxCollider2D bc;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    // Basic collision logic.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(throwVelocity * throwDirection, rb.velocity.y);
        if (timer >= despawnTimer)
        {
            Destroy(this.gameObject);
        }
        if(timer >= falloffTimer)
        {
            rb.gravityScale = falloffGravity;
        }
    }
}
