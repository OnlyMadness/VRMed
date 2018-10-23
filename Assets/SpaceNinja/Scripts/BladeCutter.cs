using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class BladeCutter : MonoBehaviour {
    public Material CutMaterial;
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        GameObject victim = collision.collider.gameObject;
        GameObject[] parts = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, CutMaterial);

        if (!parts[1].GetComponent<Rigidbody>())
            parts[1].AddComponent<Rigidbody>();
        Destroy(parts[1],1);
    }
}
