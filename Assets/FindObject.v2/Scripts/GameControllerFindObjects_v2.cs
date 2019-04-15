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

    public GameObject FinishMarkCanvas;
    private int MarkFindObjects_v2;
    private string CommentFindObjects_v2;

    public GameObject CanvasSelectTypeObjects;

    private void Start()
    {
        Founded_Weapons = 0;
        StartGameBool = true;
    }
    public void CloseMenuCanvas()
    {
        FinishMarkCanvas.SetActive(false);
    }
    public void MenuGames()
    {
        Application.LoadLevel(2);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FinishMarkCanvas.SetActive(true);
        }
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
            FinishMarkCanvas.SetActive(true);
            ///////////// Invoke("Finish", 10);         так было
        }
    }
    public void Mark(Dropdown Mark)
    {
        MarkFindObjects_v2 = Mark.GetComponent<Dropdown>().value;
    }
    public void Comment(InputField Comment)
    {
        CommentFindObjects_v2 = Comment.text;
    }
    public async void FinishFindObjects_v2()
    {
        SqlConnection sqlconnect = new SqlConnection();
        await sqlconnect.PostInsertMarksCommentsGameAsync(Session.Id_Patient, 4, MarkFindObjects_v2, CommentFindObjects_v2);
        Application.LoadLevel(2);
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
