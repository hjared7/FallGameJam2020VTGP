using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FazePlatforms : MonoBehaviour
{
    public GameObject fazeTiles;

    float timer = 2f;
    bool swap;
    bool visible = true;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            swap = !visible;
            timer = 2f;
        }

        if(visible != swap)
        {
            fazeTiles.SetActive(swap);
            visible = swap;
        }
    }


}
