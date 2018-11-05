using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        if (StartGameBool)
        {
            StartGame();
            StartGameBool = false;
        }
        if(Founded_Green ==  6 || Founded_Circles == 5)
        {
            Invoke("Finish", 3);
            //Finish();           
        }
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
// отключить поинтер
    }

    public void StartGame()
    {

    }

}
