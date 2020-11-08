using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneBehaviour : MonoBehaviour
{
    public void ChangeDimension()
    {
        GameControl.control.SwitchDimension();
    }
}
