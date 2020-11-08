using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class SkellyDance : MonoBehaviour
{
    public float timer;
    public Sprite[] sp;

    private int counter;
    private Image im;
    private float time;

    void Awake()
    {
        im = GetComponent<Image>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timer)
        {
            time = 0;
            im.sprite = sp[counter++];
            if (counter == sp.Length)
            {
                counter = 0;
            }
        }
    }
}
