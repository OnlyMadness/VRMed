using UnityEngine;

public class MiniGamesHexButtonTrueState : MonoBehaviour {

    public MiniGamesTimer timer;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            timer.StartTimer = true;
        }
    }
}
