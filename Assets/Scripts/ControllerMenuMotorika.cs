using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuMotorika : MonoBehaviour {
    public GameObject CanvasMenu;
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
    public void StartNinja()
    {
        Application.LoadLevel(4);
    }
    public void StartFindObjects()
    {
        Application.LoadLevel(5);
    }
    public void Menu()
    {
        Application.LoadLevel(1);
    }
    public void StartKillRabbit()
    {
        Application.LoadLevel(6);
    }
    public void StartFindObjects_v2()
    {
        Application.LoadLevel(7);
    }

}
