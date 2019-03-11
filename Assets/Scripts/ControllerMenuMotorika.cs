using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuMotorika : MonoBehaviour {

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
}
