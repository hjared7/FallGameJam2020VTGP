using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BoneBehaviour : MonoBehaviour
{

    public float falloffTimer = 1f;
    public float despawnTimer = 4f;

    Rigidbody2D rb;
    BoxCollider2D bc;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        timer = despawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void FixedUpdate()
    {
        if (bc.IsTouchingLayers(8))
        {
            Destroy(this);
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this);
        }
        //TODO
    }
}
