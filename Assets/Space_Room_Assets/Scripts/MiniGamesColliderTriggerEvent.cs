using UnityEngine;

public class MiniGamesColliderTriggerEvent : MonoBehaviour {

    public GameObject Target;
    public bool CatchTarget;

    private void OnEnable()
    {
        CatchTarget = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Target)
        {
            CatchTarget = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Target)
        {
            CatchTarget = false;
        }
    }
}
