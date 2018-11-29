using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrimitiveCreator : MonoBehaviour
{
    private SteamVR_TrackedController _controller;
    private PrimitiveType _currentPrimitiveType = PrimitiveType.Sphere;
    public UnityEvent AnimationPlay;
    public UnityEvent AnimationUnPlay;

    private void OnEnable()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += HandleTriggerClicked;
    }

    private void OnDisable()
    {
        _controller.TriggerUnclicked -= HandleTriggerUnClicked;
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        AnimationPlay.Invoke();
    }

    private void HandleTriggerUnClicked(object sender, ClickedEventArgs e)
    {
        AnimationUnPlay.Invoke();
    }

}