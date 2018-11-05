using System;
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
        if (StartGameBool)
        {
            StartGame();
            StartGameBool = false;
        }
        if(Founded_Green ==  6 || Founded_Circles == 5)
        {
<<<<<<< HEAD
            Invoke("Finish", 3);
=======
            Invoke("Finish",3f);
>>>>>>> e1f703b99734650c8ca62b3daa7b53bcd1f8eb16
            //Finish();           
        }
    }

    private void Finish()
    {
<<<<<<< HEAD
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
=======
        Application.LoadLevel(Application.loadedLevel);
        //for(int i = 0; i<5;i++)
        //    CircleObjects.transform.GetChild(i).GetComponent<GrabObject>().Founded = false;
        //for (int i = 0; i < 5; i++)
        //    GreenObjects.transform.GetChild(i).GetComponent<GrabObject>().Founded = false;
        //GreenObjects.SetActive(true);
        //CircleObjects.SetActive(true);
        //CanvasSelectTypeObjects.SetActive(true);
        //Founded_Green = 0;
        //Founded_Circles = 0;
        //RightController.GetComponent<VRTK_Pointer>().enabled = false;
        //LeftController.GetComponent<VRTK_Pointer>().enabled = false;
>>>>>>> e1f703b99734650c8ca62b3daa7b53bcd1f8eb16
    }

    public void StartGame()
    {

    }

}
