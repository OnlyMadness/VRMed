﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerNinja : MonoBehaviour {
    public static byte lvl_game;

    public static bool Game;
    public static bool Finish;
    public static bool MainMenuBool;
    public static int Score;
    public static int Score_Error;

    public GameObject Score_text;
    public GameObject Score_Error_text;

    public GameObject Score_stats_finish_text;
    public GameObject Error_stats_finish_text;
    public GameObject Canvas_stats;
    // Use this for initialization
    void Start () {
       //StartCoroutine(Timer());
    }

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(1);
    //}

    public static void GameStart()
    {
       // Canvas_stats.GetComponent<Canvas>().enabled = false;
        Instantiate(Resources.Load("SpaceNinja/LightButton"));
        Instantiate(Resources.Load("SpaceNinja/HardButton"));
        Game = true;
        //Enable_lvl_select();
        //Spawner.SpawnMode = true;
    }

    public static void MainMenu()
    {
        Instantiate(Resources.Load("SpaceNinja/LightButton"));
        Instantiate(Resources.Load("SpaceNinja/HardButton"));
        Game = true;
    }

    private void Reset()
    {
        Score = 0;
        Score_Error = 0;
        Score_text.GetComponent<Text>().text = Score.ToString();
        Score_Error_text.GetComponent<Text>().text = Score_Error.ToString();
    }
    // Update is called once per frame
    void Update () {
        if (Game)
        {
            Score_text.GetComponent<Text>().text = Score.ToString();
            Score_Error_text.GetComponent<Text>().text = Score_Error.ToString();
        }
        else
        {
            if (Finish)
            {            
                Canvas_stats.GetComponent<Canvas>().enabled = true;
                Score_stats_finish_text.GetComponent<Text>().text = Score.ToString();
                Error_stats_finish_text.GetComponent<Text>().text = Score_Error.ToString();
                Finish = false;
                Reset();
                Instantiate(Resources.Load("SpaceNinja/RetryButton"));
            }
        }
        if (MainMenuBool)
            Canvas_stats.GetComponent<Canvas>().enabled = false;
    }
}
