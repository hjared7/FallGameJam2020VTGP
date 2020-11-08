using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkBehaviour : MonoBehaviour
{
    public int bonesGiven;
    public float frequency = 0.5f;
    public float amplitude = 1f;
    public GameObject particles;
    public GameObject SFX;

    private Vector3 tempPos;
    private Vector3 originalPos;

    void Awake()
    {
        originalPos = transform.position;
    }
    void Update()
    {
        // Float up/down with a Sin()
        tempPos = originalPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameControl.control.ammo+= bonesGiven;
            Instantiate(particles, transform.position, Quaternion.identity);
            Instantiate(SFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
