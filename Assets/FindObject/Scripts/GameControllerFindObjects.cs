using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerFindObjects : MonoBehaviour {
    public static int Founded_Circles;
    public static int Founded_Green;
    public static string TypeObjects;
    public GameObject FoundedText;
    public static bool StartGameBool;
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
    }
    public void StartGame()
    {

    }

}
