namespace Formika
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    public class TabletController : MonoBehaviour
    {
        public enum TabletState
        {
            Waiting, IsTriggered, IsActive
        }

        public Transform m_OtherHandTransform;
        public TabletState tabletState = TabletState.Waiting;
        public float timeTabletActivation = 1f;
        private float deltaTime;

        // classic events
        public static event Action OnTabletWaitingEvent, OnTabletTriggeredEvent, OnTabletActiveEvent;
        // unity events
        public UnityEvent OnTabletWaitingUnityEvent, OnTabletTriggeredUnityEvent, OnTabletActiveUnityEvent;

        private void Start()
        {
            //DEBUG + Unity Events
            OnTabletWaitingEvent += () => { Debug.Log("OnTabletWaitingEvent"); OnTabletWaitingUnityEvent.Invoke(); };
            OnTabletTriggeredEvent += () => { Debug.Log("OnTabletTriggeredEvent"); OnTabletTriggeredUnityEvent.Invoke(); };
            OnTabletActiveEvent += () => { Debug.Log("OnTabletActiveEvent"); OnTabletActiveUnityEvent.Invoke(); };
        }


        private void Update()
        {
            if (tabletState == TabletState.IsTriggered)
            {
                deltaTime += Time.deltaTime;
                if (deltaTime >= timeTabletActivation)
                {
                    if (OnTabletActiveEvent != null)
                        OnTabletActiveEvent();

                    deltaTime = 0f;
                    tabletState = TabletState.IsActive;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.LogFormat("OnTriggerEnter : {0}", other.name);
            if (other.transform == m_OtherHandTransform)
            {
                if (tabletState == TabletState.Waiting)
                {
                    tabletState = TabletState.IsTriggered;
                    deltaTime = 0f;
                    if (OnTabletTriggeredEvent != null)
                        OnTabletTriggeredEvent();
                }
                else
                if (tabletState == TabletState.IsActive)
                {
                    tabletState = TabletState.Waiting;
                    if (OnTabletWaitingEvent != null)
                        OnTabletWaitingEvent();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //Debug.LogFormat("OnTriggerExit : {0}", other.name);
            if (other.transform == m_OtherHandTransform)
            {
                if (tabletState == TabletState.IsTriggered)
                {
                    tabletState = TabletState.Waiting;
                    deltaTime = 0f;
                    if (OnTabletWaitingEvent != null)
                        OnTabletWaitingEvent();
                }
            }
        }
    }
}