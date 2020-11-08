using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkBehaviour : MonoBehaviour
{
    public int bonesGiven;
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
}
