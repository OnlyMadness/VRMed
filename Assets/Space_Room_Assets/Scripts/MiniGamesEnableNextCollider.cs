using UnityEngine;

public class MiniGamesEnableNextCollider : MonoBehaviour {

    public Collider ColliderToEnable;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            ColliderToEnable.enabled = true;
        }
    }
}
