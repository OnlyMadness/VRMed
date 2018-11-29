using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public bool CanUseDestroyer;
    public GameObject Table;

    private void OnTriggerStay(Collider other)
    {
        if (CanUseDestroyer)
        {
            if (other.tag == "SpawnObjs")
            {
                Destroy(other.gameObject);
                Table.GetComponent<PrinterController>().AddCurrentObjs(-1);
            }
        }
    }
}
