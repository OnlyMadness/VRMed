﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
