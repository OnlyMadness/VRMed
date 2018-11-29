using UnityEngine;

public class TerminalUpDownPosition : MonoBehaviour {

    public float PosY_Min;
    private float PosY_Max;

    private void Start()
    {
        PosY_Max = transform.localPosition.y;
    }

    private void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.localPosition.y >= PosY_Max) return;
            else transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.001f, transform.localPosition.z);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.localPosition.y <= PosY_Min) return;
            else transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.001f, transform.localPosition.z);
        }
    }
}
