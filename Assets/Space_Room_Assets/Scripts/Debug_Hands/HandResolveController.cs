namespace Formika
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    //[System.Serializable]
    //public class HandDevice
    //{
    //    public GameObject handGameObject;
    //    //public SteamVR_TrackedObject.EIndex currentEIndex;
    //    public HandSideEnum handSide;
    //    public int indexPriority;
    //    [HideInInspector]
    //    public SteamVR_TrackedObject trackedObjectComponent;
    //}

    //[System.Serializable]
    //public enum HandSideEnum
    //{
    //    Left, Right
    //}

    
    public class HandResolveController : MonoBehaviour
    {
    //    public HandDevice[] m_handDevices;  //m_handLet1, m_handRight1, m_handLeft2, m_handRight2;

    //    private List<HandDevice> rightHandsList = new List<HandDevice>();
    //    private List<HandDevice> leftHandsList = new List<HandDevice>();

    //    private void Start()
    //    {
    //        SetupHands();
    //    }

    //    private void SetupHands()
    //    {
    //        foreach (var temp in m_handDevices)
    //        {
    //            temp.trackedObjectComponent = temp.handGameObject.GetComponent<SteamVR_TrackedObject>();
    //            //temp.handGameObject.SetActive(temp.trackedObjectComponent.isValid);
    //            if (temp.handSide == HandSideEnum.Left)
    //                leftHandsList.Add(temp);
    //            else
    //                rightHandsList.Add(temp);
    //        }


    //    }
 
    //    private HandDevice SortBySideAndPriority(List<HandDevice> list)
    //    {
    //        int maxPriority = -1;
    //        HandDevice handDevice = null;
    //        foreach (var i in list)
    //        {
    //            if (i.indexPriority > maxPriority && i.trackedObjectComponent.isValid)
    //            {
    //                maxPriority = i.indexPriority;
    //                if (handDevice != null)
    //                    handDevice.handGameObject.SetActive(false);

    //                handDevice = i;
    //            }
    //            else
    //              if (i.indexPriority < maxPriority && handDevice != null)
    //                handDevice.handGameObject.SetActive(false);
    //        }

    //        return handDevice;
    //    }

    //    private void Update()
    //    {
    //        SortBySideAndPriority(leftHandsList);
    //        SortBySideAndPriority(rightHandsList);
    //    }
    }
}
