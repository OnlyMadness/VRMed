using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForce : MonoBehaviour {

    [Range (0.1f,1000f)]
    public float StartForce = 1.0f;

    [Range(0.1f, 2.0f)]
    public float LifeTime = 1.0f;

    public void Shoot(float PowerForce)
    {
        gameObject.transform.SetParent(transform.root);
      
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * StartForce * PowerForce);
        Debug.Log("Shoot");
        //GameObject.Find("MiniGameScreen").GetComponent<ScreenBowGame>().ShootHit();
        StartCoroutine (DestroyArrow());
    }
    public IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
}
