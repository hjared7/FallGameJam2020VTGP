using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    float moveSpeed = 1;

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

        if (player.GetComponent<PlayerBehaviour>().ghostTrigger)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        if (rb.velocity != new Vector2(0, 0))
        {
            rb.velocity = new Vector2(0, 0);
        }

        if(distance < 0.4)
        {
            GameControl.control.health -= 1;
            player.transform.position = player.GetComponent<PlayerBehaviour>().respawnPoint;
        }
    }
}
