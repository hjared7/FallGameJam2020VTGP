using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSFX : MonoBehaviour
{
    public float timer = 5f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) Destroy(this.gameObject);
    }
}
