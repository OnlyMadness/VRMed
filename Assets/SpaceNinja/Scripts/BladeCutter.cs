using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class BladeCutter : MonoBehaviour {
    public Material CutMaterial;
    
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Asteroid")
            GameControllerNinja.Score++;
        if (collision.collider.gameObject.tag == "Planet")
            GameControllerNinja.Score_Error++;
        if (collision.collider.gameObject.tag == "Start")
            GameControllerNinja.GameStart();
        
        GameObject victim = collision.collider.gameObject;
        GameObject[] parts = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, CutMaterial);

        if (!parts[1].GetComponent<Rigidbody>())
            parts[1].AddComponent<Rigidbody>();
        Destroy(parts[1],1);
       // collision.collider.gameObject.tag = "Untagged";
    }
}
