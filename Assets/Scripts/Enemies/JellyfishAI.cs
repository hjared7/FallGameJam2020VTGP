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
    void FixedUpdate()
    {
        hits = Physics2D.RaycastAll(transform.position, target.position);
        if (!hits[0].transform.CompareTag("Solid"))
        {
            distance = Vector3.Distance(target.position, transform.position);
            
            direction = new Vector3((target.position.x - transform.position.x), target.position.y - transform.position.y);
            direction.x /= Mathf.Abs(direction.x);
            direction.y /= Mathf.Abs(direction.y);

            rb.MovePosition(transform.position + direction.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
