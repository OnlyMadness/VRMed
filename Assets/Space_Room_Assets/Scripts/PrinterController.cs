using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterController : MonoBehaviour
{

    public GameObject ParticleObj;
    public Transform ParticlePos;
    private float MaxDistanceFade;
    public GameObject[] Objs;
    public Transform InstPos;
    public int CounterObjs;
    public Vector3 torq;
    private float ColorInterpolateMultiplyer;

    [Range(0f, 5f)]
    public float Speed = 1.0f;

    [Range(0f, 5f)]
    public float MaxDistance = 5.0f;

    public float TimeToRotate = 3.0f;
    public float StartTorque = 3.0f;
    public float ForceDown = 10.0f;




    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnNweObject();


        }

        //if (ColorInterpolateMultiplyer <= MaxDistanceFade)
        //{
        //    ColorInterpolateMultiplyer += 0.05f;
        //    ObjMat.SetFloat("_Distance", ColorInterpolateMultiplyer);
        //}
    }

    public void SpawnNweObject()
    {

        int ind = Random.Range(0, Objs.Length);
        GameObject inObj = Instantiate(Objs[ind], InstPos);
        GameObject parInObj = Instantiate(ParticleObj, ParticlePos, false);


        AddCurrentObjs(1);

        //   rb.GetComponent<AudioSource>().Play();


        var ObjMat = inObj.GetComponent<Renderer>().material;
        var TempMaterial = new Material(ObjMat);
        inObj.GetComponent<Renderer>().material = TempMaterial;
        TempMaterial.SetFloat("_Distance", 0.0f);
        StartCoroutine(Forces(inObj.transform));
        StartCoroutine(AfterSpawn(TempMaterial));
    }

    public void AddCurrentObjs(int ObjToAdd)
    {
        CounterObjs += ObjToAdd;
    }

    public IEnumerator AfterSpawn(Material mat)
    {
        while (mat.GetFloat("_Distance") <= MaxDistance)
        {

            var temp = mat.GetFloat("_Distance");
         //   Debug.Log(temp);
            temp += Time.deltaTime * Speed;
            mat.SetFloat("_Distance", temp);
            yield return new WaitForEndOfFrame();

        }
    }
    public IEnumerator Forces(Transform TargetTransform)
    {
        Rigidbody rb = TargetTransform.GetComponent<Rigidbody>();
        rb.useGravity = false;
      //  rb.isKinematic = fa;
        rb.AddTorque(torq);
        yield return new WaitForSeconds(TimeToRotate);
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * ForceDown);
    }
}
