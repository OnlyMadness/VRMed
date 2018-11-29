using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsControllerImage4Test : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            if (gameObject.name == "Button_L_U" || gameObject.name == "Button_R_U" || gameObject.name == "Button_L_D" || gameObject.name == "Button_R_D")
                gameObject.GetComponent<Button>().onClick.Invoke();
            if (gameObject.name == "Answer_1" || gameObject.name == "Answer_2" || gameObject.name == "Answer_3" || gameObject.name == "Answer_4")
                gameObject.GetComponent<Button>().onClick.Invoke();
            if (gameObject.name == "Restart")
                gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
