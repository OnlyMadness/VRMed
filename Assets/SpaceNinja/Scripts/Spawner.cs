using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] target_Prefab;
    private byte WaitSec;
    public static bool SpawnMode;
    public int CountAster, CountPlanet;
    private int select_prefab;

    private void Start()
    {
        if (SpawnMode == true)
        {
            StartCoroutine(Spawn());
            CountAster = 6 / GameControllerNinja.lvl_game / 2;
            CountPlanet = CountAster;
        }
    }
    private void Update()
    {
        if (SpawnMode == true)
        {
            CountAster = 6 / GameControllerNinja.lvl_game / 2;
            CountPlanet = CountAster;
            StartCoroutine(Spawn());
            SpawnMode = false;
        }
    }
    IEnumerator Spawn()
    {
        while (CountPlanet > 0 || CountAster > 0)
        {
          //  if (SpawnMode)
          //  {
                select_prefab = Random.Range(0, target_Prefab.Length);
                if (select_prefab <= 5)
                {
                    if (CountAster == 0)
                    {
                        select_prefab = Random.Range(5, target_Prefab.Length);
                        CountPlanet--;
                    }
                    else
                    {
                        CountAster--;
                    }
                }
                else
                {
                    if (CountPlanet == 0)
                    {
                        select_prefab = Random.Range(0, 5);
                        CountAster--;
                    }
                    else
                    {
                        CountPlanet--;
                    }
                }
                GameObject go = Instantiate(target_Prefab[select_prefab]);
                Rigidbody temp = go.GetComponent<Rigidbody>();
                temp.velocity = new Vector3(0f, 5f, 5f);
                temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
                temp.useGravity = true;

                Vector3 pos = transform.position;
                pos.x += Random.Range(-1f, 1f);
                go.transform.position = pos;
                yield return new WaitForSeconds(GameControllerNinja.lvl_game);
          //  }
          //  else
           //     yield return null;
        }
        StopCoroutine(Spawn());
       // GameControllerNinja.MainMenu();
        GameControllerNinja.Finish = true;
        GameControllerNinja.Game = false;
    }
}
