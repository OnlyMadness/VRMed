using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsAndPlanets : MonoBehaviour {
    public Material cut;
    public bool OnCut;
    public float Velocity;
    void Update()
    {
        if (transform.position.y < 1f)
        {
            if (gameObject.tag == "Start")
            {

                GameControllerNinja.MainMenuBool = false;
                GameControllerNinja.GameStart();
                //Destroy(collision.collider.gameObject);
            }
            if (gameObject.tag == "MainMainMenu")
            {
                Application.LoadLevel(1);
            }
            if (gameObject.tag == "MainMenu")
            {
                //collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                GameControllerNinja.GameStart();
                GameControllerNinja.MainMenuBool = true;
                /////Destroy(GameObject.FindWithTag("MainMainMenu"));
                //Destroy(collision.collider.gameObject);
            }
            if (gameObject.tag == "lvl_1")
            {
                // collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                GameControllerNinja.MainMenuBool = false;
                GameControllerNinja.lvl_game = 1;
                Spawner.SpawnMode = true;
                //Destroy(collision.collider.gameObject);
                Destroy(GameObject.FindWithTag("lvl_3"));
                
            }
            if (gameObject.tag == "lvl_3")
            {
                GameControllerNinja.MainMenuBool = false;
                //collision.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                GameControllerNinja.lvl_game = 3;
                Spawner.SpawnMode = true;
                //Destroy(collision.collider.gameObject);
                Destroy(GameObject.FindWithTag("lvl_1"));
            }
            Destroy(gameObject);
        }
        // if (!(gameObject.tag == "Asteroid") && !(gameObject.tag == "Planet"))
        //     gameObject.transform.Translate(Vector3.down * Time.deltaTime);
        //  if (((gameObject.tag == "Start") || (gameObject.tag == "lvl-3") || (gameObject.tag == "lvl_1"))&&(OnCut))
        //if ((!(gameObject.tag == "Asteroid") && !(gameObject.tag == "Planet"))&& (OnCut))
        //{
        //  //  gameObject.transform.Translate(Vector3.forward * Time.deltaTime*Velocity);
        //}
    }
}
