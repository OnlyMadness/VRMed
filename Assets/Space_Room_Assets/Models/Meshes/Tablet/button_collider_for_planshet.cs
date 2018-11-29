using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_collider_for_planshet : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ButtonPressed");
//        Destroy(other.gameObject);
    }
}