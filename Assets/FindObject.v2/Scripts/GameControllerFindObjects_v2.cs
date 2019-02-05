using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK;
using VRTK.Examples;

public class GameControllerFindObjects_v2 : MonoBehaviour {
    public static int Founded_Weapons;
    public static string TypeObjects;
    public GameObject FoundedText;
    public static bool StartGameBool;

    public GameObject CanvasSelectTypeObjects;

    private void Start()
    {
        Founded_Weapons = 0;
        StartGameBool = true;
    }
    private void Update()
    {
        //if(TypeObjects == "Circle")
        //    FoundedText.GetComponent<Text>().text = Founded_Circles.ToString();
        //else
        //    FoundedText.GetComponent<Text>().text = Founded_Green.ToString();
        //if (StartGameBool)
        //{
        //   StartGame();
        //  StartGameBool = false;
        //}
        FoundedText.GetComponent<Text>().text = Founded_Weapons.ToString();
        if (Founded_Weapons ==  20)
        {
           // CanvasSelectTypeObjects.transform.Find("Panel").transform.Find("Score").gameObject.SetActive(false);
          //  CanvasSelectTypeObjects.transform.Find("Panel").transform.Find("Finish").gameObject.SetActive(true);
            StartGameBool = false;

            Invoke("Finish", 10);         
        }
    }

    public void ButtonTest() {
       // Application.LoadLevel(2);
    }

    private void Finish()
    {
        CanvasSelectTypeObjects.SetActive(true);
        Founded_Weapons = 0;
        // перезапуск сцены по окончанию 
        Application.LoadLevel(Application.loadedLevel);
    }
}
