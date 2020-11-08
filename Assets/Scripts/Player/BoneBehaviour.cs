using System.Collections;
using System.Collections.Generic;
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
    private float timer;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0;

        //The ten should be replaced with the players layermask
        GameObject player = GameObject.FindWithTag("Player");
        throwDirection = Mathf.Sign((transform.position - player.transform.position).x);
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    // Basic collision logic.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yo");
        if(collision.gameObject.layer == 8)
        {
            Debug.Log("ground");
            Destroy(this.gameObject);
        }
        
        else if(collision.gameObject.tag == "Jellyfish")
        {
            Debug.Log("jelly");
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
