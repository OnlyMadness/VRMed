using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour {
    public float TimeLife = 5.0f;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroySelf());

    }

    private IEnumerator DestroySelf() {
        yield return new WaitForSeconds(TimeLife);
      //  GameObject.Find("MiniGameScreen").GetComponent<ScreenBowGame>().ShootHit();
        Destroy(gameObject);
    }
}
