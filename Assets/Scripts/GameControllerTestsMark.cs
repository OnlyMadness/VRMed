using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerTestsMark : MonoBehaviour {
    public static int[] TestsMark = new int[12];
    public static string[] TestsComment = new string[12];
    public void SetMark(Dropdown DropDownMark)
    {
        TestsMark[Convert.ToInt32(DropDownMark.gameObject.name)-1] = DropDownMark.GetComponent<Dropdown>().value;
        
    }
    public void SetComment(InputField InputFieldComment)
    {
        TestsComment[Convert.ToInt32(InputFieldComment.gameObject.name)-1] = InputFieldComment.text;
    }
    public void FinishTests()
    {
        SqlConnection sqlconnect = new SqlConnection();
        sqlconnect.PostInsertMarksCommentsTestAsync(TestsMark, TestsComment);
       // Application.LoadLevel(1);
    }
}

