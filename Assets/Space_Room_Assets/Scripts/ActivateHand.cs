using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHand : MonoBehaviour {

    public Transform ReferencePosition;
    public GameObject ControllerHand;
	void Start () {
        StartCoroutine(ActHand());

    }
    private IEnumerator ActHand() {
        yield return new WaitForSeconds(5f);
        ControllerHand.SetActive(true);
        GameObject.Find("LeftController").transform.localPosition = ReferencePosition.position;
        GameObject.Find("LeftController").transform.localRotation = ReferencePosition.rotation;
    }
}
