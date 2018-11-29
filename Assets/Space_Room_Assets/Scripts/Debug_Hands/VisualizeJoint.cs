using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class VisualizeJoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<VisualizeJoint>()==null || (child.gameObject.GetComponent<VisualizeJoint>() == null && child.gameObject.GetComponent<CapsuleCollider>()!=null && child.gameObject.GetComponent<CapsuleCollider>().isTrigger))
            child.gameObject.AddComponent<VisualizeJoint>();

            //if (child.gameObject.GetComponent<VisualizeJoint>() != null && (child.gameObject.GetComponent<CapsuleCollider>() == null || !child.gameObject.GetComponent<CapsuleCollider>().isTrigger))
            //{
            //    var temp = child.gameObject.GetComponent<VisualizeJoint>();
            //    DestroyImmediate(temp);
            //}
        }
        Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, .05f);

		foreach (Transform child in transform){
			Gizmos.DrawLine(transform.position, child.position);
		}
	}
}
