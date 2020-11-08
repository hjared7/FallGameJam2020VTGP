using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishAI : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;

    public Transform whatTheFuck;

    float moveSpeed = 1.5f;

    private Vector3 pos;
    private bool resp;

    // Start is called before the first frame update
    void Awake()
    {
        resp = false;
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resp)
        {
            transform.position = pos;
            resp = false;
        }

        Debug.DrawRay(transform.position, target.position - transform.position);
        whatTheFuck = Physics2D.Raycast(transform.position, target.position - transform.position).transform;
        if (Physics2D.Raycast(transform.position, target.position - transform.position).transform.tag != "Solid")
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
        }

        if(rb.velocity != new Vector2(0, 0))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void Respawn()
    {
        resp = true;
    }
}
