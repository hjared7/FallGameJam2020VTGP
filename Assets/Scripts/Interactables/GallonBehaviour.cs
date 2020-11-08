using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GallonBehaviour : MonoBehaviour
{
    public float frequency = 0.5f;
    public float amplitude = 1f;

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
            SceneManager.LoadScene(3);
        }
    }
}
