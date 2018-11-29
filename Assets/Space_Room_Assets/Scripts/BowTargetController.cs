using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTargetController : MonoBehaviour
{

    private Vector3 TargetTransform;
    [Header("Constrains")]
    [Range(-5.0f, 5.0f)]
    public float minX;
    [Range(-5.0f, 5.0f)]
    public float maxX;
    [Range(-5.0f, 5.0f)]
    public float minY;
    [Range(-5.0f, 5.0f)]
    public float maxY;
    [Header("Speed Of Target")]
    public float Speed;
    private Vector3 velocity = Vector3.zero;
    public GameObject Target;
    public GameObject ParticlesArrow;

    private void Awake()
    {
        TargetTransform = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0.0f);
        NewPos();
    }

    public void NewPos()
    {
        TargetTransform = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0.0f);
        StartCoroutine(SetNewPos());

    }
    IEnumerator SetNewPos()
    {
        yield return new WaitForSeconds(4f);
        NewPos();
    }
    private void Update()
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, TargetTransform, ref velocity, Time.deltaTime * Speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            transform.parent.GetComponent<ScreenBowGame>().ShootHit();
            GameObject StartTarget = new GameObject();
            StartTarget.transform.position = other.transform.position;
            Instantiate(ParticlesArrow, StartTarget.transform);
            var instantiatedHint = Instantiate(Target, transform);

            instantiatedHint.transform.parent = transform.parent;
            instantiatedHint.transform.localPosition = TargetTransform;

            other.gameObject.tag = "Untagged";
            Destroy(gameObject);

        }
    }

}