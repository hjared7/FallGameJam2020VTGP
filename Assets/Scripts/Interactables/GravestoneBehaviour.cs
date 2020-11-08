using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneBehaviour : MonoBehaviour
{

    //This must be the object with the GraveController component in the scene.
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
