using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DedScreen : MonoBehaviour
{
	public float timer = 5f;

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0) Restart();
    }

    private void Restart()
	{
		SceneManager.LoadScene(0);
	}
}
