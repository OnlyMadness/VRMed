using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mole")
        {
            Debug.Log("ez");
            Destroy(collision.collider.gameObject);
        }
    }
}