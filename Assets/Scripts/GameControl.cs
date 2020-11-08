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
    }
}
