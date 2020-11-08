using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FazePlatforms : MonoBehaviour
{
    public GameObject fazeTilesA;
    public GameObject fazeTilesB;

    float timer = 2.5f;
    bool swap;
    bool visibleA = true;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.control.IsDimension(1))
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0f)
            {
                swap = !visibleA;
                timer = 2f;
            }

            if (visibleA != swap)
            {
                fazeTilesA.SetActive(swap);
                fazeTilesB.SetActive(!swap);
                visibleA = swap;
            }
        }
        else
        {
            fazeTilesA.SetActive(false);
            fazeTilesB.SetActive(false);
        }
            
    }
}
