using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Formika.Motorika
{
    public class RaycastCameraController : MonoBehaviour
    {
        public Transform mainCamera;
        public int layerMask;
        public float raycastDistance = 100;
        private bool lastResult = false;
        public Transform[] directions;

        public UnityEvent onExit, onEnter;

        private void Start()
        {
            if (!mainCamera)
                mainCamera = Camera.main.transform;
        }

        private void Update()
        {
           

            if (!mainCamera) return;

            RaycastHit raycastHit;

            foreach(Transform t in directions)
            { 
              var fwdVec = t.forward;
              var ray = new Ray(mainCamera.position, fwdVec * raycastDistance);

                //if (Physics.Raycast(ray, out raycastHit) && raycastHit.transform.gameObject.layer == layerMask && !lastResult)
               if (Physics.Raycast(ray, out raycastHit))
               {
                  onEnter.Invoke();

                  //Debug.Log(lastResult + "onEnter");
               }
               else
               {
                   onExit.Invoke();
                
                   //Debug.Log(lastResult + "onExit");
               }
            }
        }
    }
}