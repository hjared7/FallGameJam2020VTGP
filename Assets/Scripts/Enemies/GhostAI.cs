using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    float moveSpeed = 1;
    bool triggered = false;

    Vector3 direction;
    float distance;

    Rigidbody2D rb;
    Transform transform;
    Transform target;
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (player.GetComponent<PlayerBehaviour>().ghostTrigger && distance > 0.5)
        {
            direction = new Vector3((target.position.x - transform.position.x), target.position.y - transform.position.y);
            direction.x /= Mathf.Abs(direction.x);
            direction.y /= Mathf.Abs(direction.y);
            
            rb.MovePosition(transform.position + direction * moveSpeed*Time.deltaTime);
        }
    }
}
