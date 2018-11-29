using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLayer : MonoBehaviour {
    void Start()
    {
        for (int i = 0; i > 18; i++)
            Physics.IgnoreLayerCollision(18, i);
        Physics.IgnoreLayerCollision(18, 17, false);
    }

}
