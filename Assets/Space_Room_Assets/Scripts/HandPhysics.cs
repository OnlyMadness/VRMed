using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandPhysicsExtenstions;
using VRTK.Examples;

public class HandPhysics : MonoBehaviour {

    void Start () {
		
	}
    
    public HandPhysicsController Controller
    {
        get
        {
            if (_controller == null)
                _controller = gameObject.GetComponent<HandPhysicsController>();
            return _controller;
        }
    }
    private HandPhysicsController _controller;

    // Update is called once per frame

    public void DoGrab()
    {       
        Controller.StartBendFingers();
        Debug.Log("DOGRAB");
    }
    public void DoUngrab()
    {
        Controller.StopBendFingers();
    }
}
