using UnityEngine;

public class LeftRightHandsSwicher : MonoBehaviour {

    public bool RightHand;
    public bool LeftHand;

	void Start ()
    {
        if (RightHand)
        {
            LeftHand = false;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        if (LeftHand)
        {
            RightHand = false;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
