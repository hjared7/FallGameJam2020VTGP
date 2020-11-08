using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject hurtSFX;

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


    public void Damage(GameObject player)
    {
        GameControl.control.health -= 1;
        if (health <= 0)
        {
            health = 1;
            SceneManager.LoadScene(2);
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(hurtSFX, player.transform.position, Quaternion.identity);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Jellyfish");
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<JellyfishAI>().Respawn();
            }

            enemies = GameObject.FindGameObjectsWithTag("Ghost");
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<GhostAI>().Respawn();
            }

            player.transform.position = player.GetComponent<PlayerBehaviour>().respawnPoint;
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

    public bool IsDimension(int dim)
    {
        return (dim == (currentDimension + 1));
    }
}
