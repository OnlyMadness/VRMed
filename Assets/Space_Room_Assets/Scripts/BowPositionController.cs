using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPositionController : MonoBehaviour {

    public Transform BowTransform;
    public Transform HandlePonitUngrabTransform;

    public Transform HandleTransform;

    public bool HanldeGrabbed = false;
    public Transform HandPivot;
	
	void Update () {
        if (!HanldeGrabbed)
        {
            HandleTransform.position = HandlePonitUngrabTransform.position;
            HandleTransform.rotation = HandlePonitUngrabTransform.rotation;
        }
        if (HanldeGrabbed)
        {
            var tempRotation = BowTransform.rotation;
            BowTransform.LookAt(HandleTransform);
            BowTransform.eulerAngles = new Vector3(BowTransform.eulerAngles.x, BowTransform.eulerAngles.y, tempRotation.eulerAngles.z);
        }
         //   BowTransform.eulerAngles = new Vector3(-HandleTransform.eulerAngles.x, -HandleTransform.eulerAngles.y, BowTransform.eulerAngles.z) ;
    }
    public void SetBoolHandleGrab(bool B)
    {
        HanldeGrabbed = B;
    }
}
