using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJoint : MonoBehaviour {

	void Update ()
    {
        if (transform.rotation.x > 160.0f)
        {
            gameObject.GetComponent<HingeJoint>().useSpring = true;
        }
        else
            gameObject.GetComponent<HingeJoint>().useSpring = false;
    }
}
