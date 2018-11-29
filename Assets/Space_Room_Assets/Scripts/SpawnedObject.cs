using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour {

    private Material LumMaterial;
    private float DissolveValue = 0.0f;
    public float DissolveSpeed;
    private Color IlumValue = Color.white;
    public float IlumSpeed;
    public float timeToGravity;

    private void Awake()
    {
        LumMaterial = gameObject.GetComponent<MeshRenderer>().material;

        LumMaterial.SetVector("_Center", gameObject.transform.position);
        IlumValue = LumMaterial.GetColor("_EmissionColor");
        Debug.Log(IlumValue);
        StartCoroutine(AddForceToObj());
    }

    void Update()
    {
        DissolveValue = Mathf.Lerp(DissolveValue, 3, Time.deltaTime* DissolveSpeed);
        LumMaterial.SetFloat("_Distance", DissolveValue);

        IlumValue = Color.Lerp(IlumValue, Color.clear, Time.deltaTime * IlumSpeed);
        LumMaterial.SetColor("_EmissionColor", IlumValue);
    }

    public IEnumerator AddForceToObj()
    {
        yield return new WaitForSeconds(timeToGravity);
        gameObject.GetComponent<Rigidbody>().drag = 0.0f;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down*300f);
    }
}
