﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK;
using VRTK.Examples;

public class GameControllerFindObjects : MonoBehaviour {
    public static int Founded_Circles;
    public static int Founded_Green;
    public static string TypeObjects;
    public GameObject FoundedText;
    public static bool StartGameBool;

    public GameObject GreenObjects;
    public GameObject CircleObjects;
    public GameObject CanvasSelectTypeObjects;

    public GameObject RightController;
    public GameObject LeftController;
    private void Start()
    {
        Founded_Circles = 0;
        Founded_Green = 0;
    }
    private void Update()
    {
        if(TypeObjects == "Circle")
            FoundedText.GetComponent<Text>().text = Founded_Circles.ToString();
        else
            FoundedText.GetComponent<Text>().text = Founded_Green.ToString();
        //if (StartGameBool)
        //{
         //   StartGame();
          //  StartGameBool = false;
        //}
        if(Founded_Green ==  6 || Founded_Circles == 6)
        {
            CanvasSelectTypeObjects.transform.Find("Panel").transform.Find("Score").gameObject.SetActive(false);
            CanvasSelectTypeObjects.transform.Find("Panel").transform.Find("Finish").gameObject.SetActive(true);
            GameControllerFindObjects.StartGameBool = false;

            Invoke("Finish", 10);         
        }
    }

    public void ButtonTest() {
        Application.LoadLevel(2);
    }

    private void Finish()
    {
        for(int i = 0; i < 5;i++)
            CircleObjects.transform.GetChild(i).GetComponent<GrabObject>().Founded = false;
        for (int i = 0; i < 6; i++)
            GreenObjects.transform.GetChild(i).GetComponent<GrabObject>().Founded = false;
        GreenObjects.SetActive(true);
        CircleObjects.SetActive(true);
        CanvasSelectTypeObjects.SetActive(true);
        Founded_Green = 0;
        Founded_Circles = 0;
        // перезапуск сцены по окончанию 
        Application.LoadLevel(Application.loadedLevel);
    }
}
