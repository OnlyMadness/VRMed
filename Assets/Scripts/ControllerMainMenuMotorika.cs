using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMainMenuMotorika : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            if (gameObject.name == "ButtonStartSpaceNinja")
            {
                Application.LoadLevel(3);
            }
            if (gameObject.name == "ButtonStartFindObject")
            {
                Application.LoadLevel(4);
            }
            if (gameObject.name == "Return")
            {
                Application.LoadLevel(1);
            }
            if (gameObject.name == "MotorikaMenuButton")
            {
                Application.LoadLevel(2);
            }
        }
    }
}
