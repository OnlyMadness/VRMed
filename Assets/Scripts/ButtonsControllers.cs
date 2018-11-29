using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsControllers : MonoBehaviour {

    public void ResetNumbMaterials()
    {
        for (int i=1; i<6; i++)
        {
             GameObject.Find("Numb_Resolution_" + i.ToString()).transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring") as Material;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finger")
        {
            if (gameObject.name == "Numb_Resolution_1")
            {
                Schulte_scripts_UI.Size_static = 3;
                ResetNumbMaterials();
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
            }
            if (gameObject.name == "Numb_Resolution_2")
            {
                Schulte_scripts_UI.Size_static = 4;
                ResetNumbMaterials();
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
            }
            if (gameObject.name == "Numb_Resolution_3")
            {
                Schulte_scripts_UI.Size_static = 5;
                ResetNumbMaterials();
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
            }
            if (gameObject.name == "Numb_Resolution_4")
            {
                Schulte_scripts_UI.Size_static = 6;
                ResetNumbMaterials();
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
            }
            if (gameObject.name == "Numb_Resolution_5")
            {
                Schulte_scripts_UI.Size_static = 7;
                ResetNumbMaterials();
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
            }
            if (gameObject.name == "Numb_Type_1")
            {
                Schulte_scripts_UI.Type_Table_static = 1;

                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
                GameObject.Find("Numb_Type_2").transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring") as Material; // gameObject.GetComponent<Button>().onClick.Invoke();
            }
            if (gameObject.name == "Numb_Type_2")
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring 1") as Material;
                GameObject.Find("Numb_Type_1").transform.GetChild(1).GetComponent<MeshRenderer>().material = Resources.Load("MiniGame_Symbol_Ring") as Material; // gameObject.GetComponent<Button>().onClick.Invoke();
                Schulte_scripts_UI.Type_Table_static = 0;
            }
            if (gameObject.name == "Numb_Ok")
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
