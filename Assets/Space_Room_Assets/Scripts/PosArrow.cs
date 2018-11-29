using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosArrow : MonoBehaviour {

    public Transform bow;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = bow.transform.position;
        gameObject.transform.rotation = bow.transform.rotation;
    }
}
