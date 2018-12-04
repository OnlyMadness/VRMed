using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuTestsAndGames : MonoBehaviour {

    public void StartTests()
    {
        Application.LoadLevel(2);
    }
    public void StartMenuGames()
    {
        Application.LoadLevel(1);
    }
}
