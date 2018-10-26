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
        {
            if(collision.collider.gameObject.tag == "Asteroid")
                collision.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            else
                collision.collider.gameObject.GetComponent<SphereCollider>().enabled = false;
            parts[1].AddComponent<Rigidbody>();
            parts[1].AddComponent<AsteroidsAndPlanets>();
            parts[1].GetComponent<Rigidbody>().mass = 100;
            parts[1].GetComponent<Rigidbody>().angularDrag = 0;
        }
       // Destroy(parts[1],1);
       // collision.collider.gameObject.tag = "Untagged";
    }
}
