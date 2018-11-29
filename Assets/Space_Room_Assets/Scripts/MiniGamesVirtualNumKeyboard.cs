using UnityEngine;

public class MiniGamesVirtualNumKeyboard : MonoBehaviour {

    public int num;
    public bool Remove;
    public bool SetAnswer;

    public MiniGames_Game7_Controller Game7_Controller;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            if (!Remove && !SetAnswer) Game7_Controller.AddNumber(num);
            if (Remove) Game7_Controller.RemoveNumber();
            if (SetAnswer) Game7_Controller.Calculate();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            transform.localScale = new Vector3(1.0f, 1.05f, 1.0f);
        }
    }
}
