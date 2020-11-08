using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLabelScript : MonoBehaviour
{
    private Text labelText;
    // Start is called before the first frame update
    void Start()
    {
        labelText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        labelText.text = "X " + GameControl.control.health;
    }
}
