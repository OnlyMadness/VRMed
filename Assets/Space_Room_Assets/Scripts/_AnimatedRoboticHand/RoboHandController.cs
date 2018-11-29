using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Formika.Motorika
{
    public class RoboHandController : MonoBehaviour
    {
        public event System.Action UpdateEvent;

        //public Animation animationComponent;
        public AnimParametricAction[] animParametricActions;

        private void Awake()
        {
            //if (animationComponent == null)
            //    animationComponent = transform.GetComponent<Animation>();

            //foreach (var a in animParametricActions)
            //    a.Init(animationComponent, this);

            foreach (var a in animParametricActions)
                a.Init(this);
        }

        private void Update()
        {
            if (UpdateEvent != null)
                UpdateEvent();

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.S))
                CopyLocalRotation(true);

            if (Input.GetKeyDown(KeyCode.E))
                CopyLocalRotation(false);
#endif
        }

        private void CopyLocalRotation(bool isStartRotation)
        {
            foreach (var o in animParametricActions)
                o.CopyLocalRotation(isStartRotation);
        }
    }

    [System.Serializable]
    public class AnimParametricAction
    {
        public Transform src;
        [HideInInspector]
        public Quaternion startRotation, endRotation;
        [HideInInspector]
        public Vector3 startRotationVector, endRotationVector, deltaVector;
        public AnimationClip animationClip;

        public Animation animationComponent;

        public void Init(RoboHandController roboHandController)
        {
            roboHandController.UpdateEvent += UpdateAction;
            deltaVector = startRotationVector - endRotationVector;
            animationComponent.AddClip(animationClip, animationClip.name);
            animationComponent.Play(animationClip.name);
            animationComponent[animationClip.name].speed = 0f;
        }

        public void UpdateAction()
        {
            var currentLocalRotation = src.localRotation;
            var currentEulerAngles = currentLocalRotation.eulerAngles;

            var eulerAngles = startRotationVector - currentLocalRotation.eulerAngles;
            Debug.Log(eulerAngles);

            var clampedEulerAngles = new Vector3(
               Mathf.Clamp(eulerAngles.x ,0f, deltaVector.x),
               Mathf.Clamp(eulerAngles.y, 0f, deltaVector.y),
               Mathf.Clamp(eulerAngles.z, 0f, deltaVector.z));

            var clampedLocalRotation = new Quaternion();
            clampedLocalRotation.eulerAngles = clampedEulerAngles;

            var lerpValue = clampedEulerAngles.z / deltaVector.z;
            Debug.Log(lerpValue);

            animationComponent.Play(animationClip.name);
            animationComponent[animationClip.name].time = animationClip.length * lerpValue;
        }

        public void CopyLocalRotation(bool isStartRotation)
        {
            if (isStartRotation)
            {
                startRotation = src.localRotation;
                startRotationVector = startRotation.eulerAngles;
            }
            else
            {
                endRotation = src.localRotation;
                endRotationVector = endRotation.eulerAngles;
            }
        }
    }
}