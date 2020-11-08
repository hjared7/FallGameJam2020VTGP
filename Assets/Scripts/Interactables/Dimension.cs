using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    public GameObject player;

    public Color dimensionColor;
    public int midairJumps = 0;
    public float jumpSpeed = 6f;
    public float gravity = 1f;

    private PlayerBehaviour pb;
    private Rigidbody2D rb;
    private Camera cam;

    void Awake()
    {
        pb = player.GetComponent<PlayerBehaviour>();
        rb = player.GetComponent<Rigidbody2D>();
        cam = player.GetComponentInChildren<Camera>();
    }

    public void Activate()
    {
        cam.backgroundColor = dimensionColor;
        pb.midairJumps = this.midairJumps;
        pb.jumpSpeed = this.jumpSpeed;
        rb.gravityScale = gravity;
    }


}
