using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishAI : MonoBehaviour
{
    Transform transform;
    Transform target;
    Rigidbody2D rb;

    Vector3 direction;

    float moveSpeed = 1;
    float distance;

    RaycastHit2D[] hits;

    // Start is called before the first frame update
    void Awake()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        hits = Physics2D.RaycastAll(transform.position, target.position);
        if (hits[0].transform.tag != "")
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
        }

        //if(rb.velocity != new Vector2(0, 0))
        //{
            //rb.velocity = new Vector2(0, 0);
        //}
    }
}
