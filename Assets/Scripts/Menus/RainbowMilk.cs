using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class RainbowMilk : MonoBehaviour
{

    public float frequency = 0.5f;
    public float amplitude = 1f;

    public int minColor;
    public int maxColor;

    private Image im;

    private Vector3 tempPos;
    private Vector3 originalPos;

    private float r;
    private float g;
    private float b;
    private int state;
    

    void Awake()
    {
        r = b = minColor;
        g = maxColor;
        state = 0;
        im = GetComponent<Image>();
        originalPos = transform.position;
        im.color = new Color(r/255f, g/255f, b/255f);
        
    }

    void Update()
    {
        // Float up/down with a Sin()
        tempPos = originalPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

        switch (state)
        {
            case 0:
                {
                    if (++r >= maxColor) state++;
                    break;
                }
            case 1:
                {
                    if (--g <= minColor) state++;
                    break;
                }
            case 2:
                {
                    if (++b >= maxColor) state++;
                    break;
                }
            case 3:
                {
                    if (--r <= minColor) state++;
                    break;
                }
            case 4:
                {
                    if (++g >= maxColor) state++;
                    break;
                }
            case 5:
                {
                    if (--b <= minColor) state = 0;
                    break;
                }
            default:
                {
                    break;
                }
        }

        im.color = new Color(r / 255f, g / 255f, b / 255f);
    }
}
