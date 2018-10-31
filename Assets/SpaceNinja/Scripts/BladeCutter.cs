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
        {
            
            GameControllerNinja.MainMenuBool = false;
            GameControllerNinja.GameStart();
            //Destroy(collision.collider.gameObject);
        }
        if (collision.collider.gameObject.tag == "MainMenu")
        {
            //collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            GameControllerNinja.GameStart();
            GameControllerNinja.MainMenuBool = true;
            //Destroy(collision.collider.gameObject);
        }
        if (collision.collider.gameObject.tag == "lvl_1")
        {
           // collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            GameControllerNinja.MainMenuBool = false;
            GameControllerNinja.lvl_game = 1;
            Spawner.SpawnMode = true;
            //Destroy(collision.collider.gameObject);
            Destroy(GameObject.FindWithTag("lvl_3"));
        }
        if (collision.collider.gameObject.tag == "lvl_3")
        {
            GameControllerNinja.MainMenuBool = false;
            //collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            GameControllerNinja.lvl_game = 3;
            Spawner.SpawnMode = true;
            //Destroy(collision.collider.gameObject);
            Destroy(GameObject.FindWithTag("lvl_1"));
        }

        if(collision.collider.gameObject.tag == "Asteroid")
        {
            CutMaterial = collision.collider.gameObject.GetComponent<AsteroidsAndPlanets>().cut;
        }
        else
        {
            CutMaterial = Resources.Load("SpaceNinja/Cut_Victim_cap") as Material;
        }

        GameObject victim = collision.collider.gameObject;
        GameObject[] parts = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, CutMaterial);

        if (!parts[1].GetComponent<Rigidbody>())
        {
            if(collision.collider.gameObject.tag == "Asteroid")
                collision.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (collision.collider.gameObject.tag == "Planet")
                collision.collider.gameObject.GetComponent<SphereCollider>().enabled = false;             
            if (!(collision.collider.gameObject.tag == "Asteroid") && !(collision.collider.gameObject.tag == "Planet"))
            {
                collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                collision.collider.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            }
                parts[1].AddComponent<Rigidbody>(); 
                parts[1].AddComponent<AsteroidsAndPlanets>();
                parts[1].GetComponent<Rigidbody>().mass = 100;
                parts[1].GetComponent<Rigidbody>().angularDrag = 0;
                parts[1].GetComponent<Rigidbody>().useGravity = true;
        }
       // Destroy(parts[1],1);
       // collision.collider.gameObject.tag = "Untagged";
    }
}
