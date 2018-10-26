using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerNinja : MonoBehaviour {
    public static int Score;
    public static int Score_Error;

    public GameObject Score_text;
    public GameObject Score_Error_text;

    // Use this for initialization
    void Start () {
		
	}

    public static void GameStart()
    {
        Spawner.SpawnMode = true;
    }
	
	// Update is called once per frame
	void Update () {
        Score_text.GetComponent<Text>().text = Score.ToString();
        Score_Error_text.GetComponent<Text>().text = Score_Error.ToString();
    }
}
