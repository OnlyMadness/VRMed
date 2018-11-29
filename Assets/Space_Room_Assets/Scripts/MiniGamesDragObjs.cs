using UnityEngine;

public class MiniGamesDragObjs : MonoBehaviour {

    private Ray ray;
    private bool ActiveMode;

    public static bool DisableDraw;
    private Vector3 ForwardVector;
    private RaycastHit hitInfo;

    public Es.InkPainter.Sample.MousePainter paintObject;

    public float MaxPosX;

    private void OnEnable()
    {
        if (DisableDraw) DisableDraw = false;
    }

    public void EnableDraw()
    {
        DisableDraw = false;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Finger")
        {
            paintObject = other.gameObject.GetComponentInChildren<Es.InkPainter.Sample.MousePainter>();

            if (paintObject.CanDraw == false) DisableDraw = true;

            paintObject.CanDraw = false;
            ActiveMode = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            ActiveMode = true;

            if (transform.localPosition.x > MaxPosX)
            {
                transform.localPosition = new Vector3(MaxPosX, transform.localPosition.y, transform.localPosition.z);

            }

            if (transform.localPosition.x < -MaxPosX)
            {
                transform.localPosition = new Vector3(-MaxPosX, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {

            if (transform.localPosition.x >= MaxPosX)
            {
                transform.localPosition = new Vector3(MaxPosX - 0.001f, transform.localPosition.y, transform.localPosition.z);

            }

            if (transform.localPosition.x <= -MaxPosX)
            {
                transform.localPosition = new Vector3(-MaxPosX + 0.001f, transform.localPosition.y, transform.localPosition.z);
            }

            if (!DisableDraw) paintObject.CanDraw = true;

            paintObject = null;
            ActiveMode = false;
        }
    }



    void Update()
    {
        if (ActiveMode) ActiveModeTransform();
        else SleepModeTransform();
    }

    void ActiveModeTransform()
    {
        ForwardVector = transform.TransformDirection(Vector3.back);
        ray = new Ray(transform.position, ForwardVector);

        if (paintObject != null && Physics.Raycast(ray, out hitInfo) && hitInfo.collider.tag == "Terminal")
        {
            if (Mathf.Abs(transform.localPosition.x) < MaxPosX)
            {
                transform.position = paintObject.HitPoint + (transform.TransformDirection(Vector3.forward) / 500);
                transform.rotation = Quaternion.LookRotation(hitInfo.normal);
            }
        }
    }

    void SleepModeTransform()
    {
        ForwardVector = transform.TransformDirection(Vector3.back);
        ray = new Ray(transform.position, ForwardVector);

        if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.tag == "Terminal")
        {
            transform.position = hitInfo.point + (transform.TransformDirection(Vector3.forward) / 500);
            transform.rotation = Quaternion.LookRotation(hitInfo.normal);

            //   Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.green, 2, false);
            //   Debug.DrawRay(transform.position, transform.localEulerAngles, Color.red, 2, false);
        }
    }
}
