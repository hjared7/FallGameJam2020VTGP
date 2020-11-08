using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    public GameObject player;
    public Camera cam;

    public Color dimensionColor;
    public int midairJumps = 0;
    public float jumpSpeed = 6f;
    public float gravity = 1f;
    public AudioClip music;

    private PlayerBehaviour pb;
    private Rigidbody2D rb;
    private AudioSource aus;

    public void Activate()
    {
        if(pb == null)
        {
            pb = player.GetComponent<PlayerBehaviour>();
        }
        if (rb == null)
        {
            rb = player.GetComponent<Rigidbody2D>();
        }
        if (aus == null)
        {
            aus = player.GetComponentInChildren<AudioSource>();
        }

        cam.backgroundColor = dimensionColor;
        pb.midairJumps = this.midairJumps;
        pb.jumpSpeed = this.jumpSpeed;
        rb.gravityScale = gravity;
        aus.clip = music;
        aus.Play();
    }


}
