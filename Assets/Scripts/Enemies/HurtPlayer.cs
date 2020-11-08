using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    GameObject player;
    public bool foundPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            foundPlayer = true;
            player.transform.position = player.GetComponent<PlayerBehaviour>().respawnPoint;
            GameControl.control.health -= 1;
        }
    }
}
