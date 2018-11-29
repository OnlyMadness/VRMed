using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletController : MonoBehaviour {

    public Animation _animation;
    public Animator _animator;
    public AnimationClip _aClip;
    public bool animAnimated;
  //  public AnimationClip animationClip;

    private void Start()
    {
        if (GetComponent<Animation>()) _animation = GetComponent<Animation>();
        if (GetComponent<Animator>()) _animator = GetComponent<Animator>();
        _animation.Play();
        _aClip = new AnimationClip();
        _animation.AddClip(_aClip,"TabletReady");

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
            animAnimated = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "hand")
            animAnimated = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            animAnimated = true;
        else
            animAnimated = false;

        if (_animation && animAnimated)
            // Walk backwards
            _animation["TabletReady"].speed = 1f;

        if (_animation && !animAnimated)
        {
            _animation.Play("TabletReady");
            _animation["TabletReady"].speed = 1f;
        }
    }

}
