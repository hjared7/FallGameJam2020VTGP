using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneBehaviour : MonoBehaviour
{

    public GameObject graveController;

    private GraveController gc;

    void Awake()
    {
        gc = graveController.GetComponent<GraveController>();
    }

    public void ChangeDimension()
    {
        gc.SwitchDimension();
    }
}
