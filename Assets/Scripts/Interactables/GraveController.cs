using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveController : MonoBehaviour
{

    public GameObject[] dimensions;

    public int availableDimensions = 1;
    public int currentDimension = 0;

    void Awake()
    {
        for(int i = 0; i < dimensions.Length; i++)
        {
            if (i != currentDimension)
            {
                dimensions[i].SetActive(false);
            }
        }
    }

    public void SwitchDimension()
    {
        Debug.Log("bruh");
        if(availableDimensions > 1)
        {
            dimensions[currentDimension++].SetActive(false);
            if(currentDimension == availableDimensions || currentDimension == dimensions.Length)
            {
                currentDimension = 0;
            }
            dimensions[currentDimension].SetActive(true);
        }
    }
}
