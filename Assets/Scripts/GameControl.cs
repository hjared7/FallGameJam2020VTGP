using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public static GameControl control;

    // Values to store
    public float health;
    public int ammo;
    // Call valuse using GameControl.control.valueName

    // Array that holds all of the dimensions. Each dimension should be an empty
    // GameObject that has all of the dimensions assests as it's children.
    public GameObject[] dimensions;

    //Track dimension information.
    public int availableDimensions = 1;
    private int currentDimension = 0;

    void Awake()
    {
        // Makes object a singleton
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }else if(control != this)
        {
            Destroy(gameObject);
        }

        //Disable all non-active dimensions.
        for (int i = 0; i < dimensions.Length; i++)
        {
            if (i != currentDimension)
            {
                dimensions[i].SetActive(false);
            }
            else
            {
                dimensions[i].GetComponent<Dimension>().Activate();
            }
        }
    }

    public void SwitchDimension()
    {
        if (availableDimensions > 1)
        {
            dimensions[currentDimension++].SetActive(false);
            if (currentDimension == availableDimensions || currentDimension == dimensions.Length)
            {
                currentDimension = 0;
            }
            dimensions[currentDimension].SetActive(true);
            dimensions[currentDimension].GetComponent<Dimension>().Activate();
        }
    }
}
