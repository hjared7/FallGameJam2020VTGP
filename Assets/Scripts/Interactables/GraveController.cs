using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveController : MonoBehaviour
{

    // Array that holds all of the dimensions. Each dimension should be an empty
    // GameObject that has all of the dimensions assests as it's children.
    public GameObject[] dimensions;

    public int availableDimensions = 1;
    public int currentDimension = 0;


    //Sets all dimensions accept for the current one to Not Active.
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
