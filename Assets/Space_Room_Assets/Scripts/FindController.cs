using UnityEngine;
using Valve.VR;

public class FindController : MonoBehaviour
{
    public SteamVR_TrackedObject[] _TrackedObject;

    void OnEnable()
    {
        var vr = SteamVR.instance;

        if (vr == null)
        {
            Debug.Log("SteamVR is not ready");
            return;
        }

        else
        {
            int i = 1;
            int DevicesCount = 0;

            while (i <= 15)
            {
                if (vr.hmd.GetTrackedDeviceClass((uint)i) == ETrackedDeviceClass.Controller)
                {
                    if (DevicesCount < _TrackedObject.Length) _TrackedObject[DevicesCount].SetDeviceIndex(i);
                    else Debug.Log("Too many devices !");

                    DevicesCount++;
                }

                i++;
            }

        }

    }

}