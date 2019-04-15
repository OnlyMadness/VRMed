using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuTestsAndGames : MonoBehaviour {

    public GameObject CanvasMenu;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CanvasMenu.SetActive(true);
        }
    }
    public void CloseCanvasMenu()
    {
        CanvasMenu.SetActive(false);
    }
    public void StartTests()
    {
        Application.LoadLevel(3);
    }
    public void StartMenuGames()
    {
        Application.LoadLevel(2);
    }
}
