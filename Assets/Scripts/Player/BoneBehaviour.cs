using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BoneBehaviour : MonoBehaviour
{
    public float despawnTimer;
    //Speed of bone when thrown.
    public float throwVelocity;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
        
        else if(collision.gameObject.layer == 9)
        {
            //Remove enemy health or destroy them
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(throwVelocity * throwDirection, 0);
        if (timer >= despawnTimer)
        {
            Destroy(this.gameObject);
        }
    }
}
