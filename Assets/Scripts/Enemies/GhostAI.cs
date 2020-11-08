using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    float moveSpeed = 1;

    float distance;

    Rigidbody2D rb;
    Transform target;
    GameObject player;

    private Vector3 pos;
    private bool resp;

    // Start is called before the first frame update
    void Awake()
    {
        resp = false;
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (resp)
        {
            transform.position = pos;
            resp = false;
        }

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
            GameControl.control.Damage(player);
        }
    }

    public void Respawn()
    {
        resp = true;
    }
}
