using UnityEngine;

public class MiniGamesResetPosObjs : MonoBehaviour {

    private Vector3 ObjPos;
    private Vector3 ObjRot;

	void OnEnable ()
    {
        ObjPos = transform.localPosition;
        ObjRot = transform.localEulerAngles;
	}
	

	void OnDisable ()
    {
        transform.localPosition = ObjPos;
        transform.localEulerAngles = ObjRot;
    }
}
