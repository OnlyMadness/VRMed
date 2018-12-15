using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuMotorika : MonoBehaviour {

    public void StartNinja()
    {
        Application.LoadLevel(3);
    }
    public void StartFindObjects()
    {
        Application.LoadLevel(4);
    }
    public void Menu()
    {
        Application.LoadLevel(0);
    }
    public void StartKillRabbit()
    {
        Application.LoadLevel(5);
    }
}
