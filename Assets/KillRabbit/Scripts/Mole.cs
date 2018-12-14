using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {

    public float maxVisibleHeight = 0.2f;
    public float hiddenHeight = -0.3f;
    public float speed = 4f;
    public float disappearDuration;
    public Transform HideTransform;
    public static bool RiseMole;
    public bool hit;

    private Vector3 targetPosition;
    private float disappearTimer;
    private bool attackable = false;
    private AudioSource hitSound;

    // Use this for initialization

    void Start() {
        hitSound = GetComponentInChildren<AudioSource>();
        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z
            );
        disappearTimer = disappearDuration;
        transform.localPosition = targetPosition;
    }

    // Update is called once per frame
    void Update() {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer <= 0f) {
            attackable = false;
            Hide();
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
    }

    public void Rise() {
        attackable = true;
        targetPosition = new Vector3(
            transform.localPosition.x,
            maxVisibleHeight,
            transform.localPosition.z
            );

        disappearTimer = disappearDuration;
    }

    public bool OnHit() {   
        if (attackable) {
            if (hitSound.isPlaying)
            {
                hitSound.Stop();
            }
            Hide();
            hitSound.Play();
            GameControllerRabbit.Score++;
            attackable = false;
            return true;
        }
        return false;
    }

    private void Hide() {
        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z
            );
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            OnHit();
        }
    }
}