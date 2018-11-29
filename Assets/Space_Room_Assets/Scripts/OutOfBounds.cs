using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBounds : MonoBehaviour {

    public Material BoundMatelial;
    private Color ColorOfBounMessage;
    private Color ColorOfBoundCurrent;
    
   

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
             ColorOfBounMessage = Color.clear;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Head")
            ColorOfBounMessage = Color.white;
    }
    private void Update()
    {
        BoundMatelial.color = Color.Lerp(ColorOfBoundCurrent, ColorOfBounMessage, Time.deltaTime);
       // BoundMessage.color = Color.Lerp(BoundMessage.color, ColorOfBounMessage,Time.deltaTime);
    }


}
