using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGames_Game5_Controller : MonoBehaviour {

    public GameObject[] _triggers;
    public GameObject Stats_Manager;

    private void OnDisable()
    {
        for (int i = 0; i < _triggers.Length; i++)
        {
           if (_triggers[i].GetComponent<MiniGamesColliderTriggerEvent>().CatchTarget == false) return;
        }

        if (Stats_Manager)
            Stats_Manager.GetComponent<MiniGamesStats>().MiniGames_Stats[4] = 1.0f;
    }
}
