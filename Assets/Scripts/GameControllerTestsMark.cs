using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerTestsMark : MonoBehaviour {
    public static string[] TestsMark = new string[Session.TestList.Length];
    public static string[] TestsComment = new string[Session.TestList.Length];
    public GameObject WindowForMark;
    public static bool GradingActive;
    //private void Start()
    //{
    //    for (int i = 1; i < TestsMark.Length; i++)
    //        TestsMark[i] = null;
    //}
    public void SetMark(Dropdown DropDownMark)
    {
        if((DropDownMark.GetComponent<Dropdown>().value - 1) == -1)
            TestsMark[Convert.ToInt32(DropDownMark.gameObject.name) - 1] = null;
        else
           TestsMark[Convert.ToInt32(DropDownMark.gameObject.name)-1] = (DropDownMark.GetComponent<Dropdown>().value-1).ToString();       
    }
    public void SetComment(InputField InputFieldComment)
    {
        TestsComment[Convert.ToInt32(InputFieldComment.gameObject.name)-1] = InputFieldComment.text;
    }
    public void MenuTestsAndGames()
    {
        Application.LoadLevel(1);
    }
    public void FinishTests()
    {
        SqlConnection sqlconnect = new SqlConnection();
        sqlconnect.PostInsertMarksCommentsTestAsync(TestsMark, TestsComment);
        Application.LoadLevel(1);
    }
    public void CloseWindow() {
        WindowForMark.SetActive(false);
        GradingActive = false;
    }
}

