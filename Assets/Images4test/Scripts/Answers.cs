using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public string[] GroupImage1;
    public string[] GroupImage2;
    public string[] GroupImage3;
    public string[] GroupImage4;
    public string[] GroupImage5;
    public string[] GroupImage6;
    public string[] GroupImage7;
    public string[] GroupImage8;
    public string[] GroupImage9;
    public string[] GroupImage10;

    public static string[] Answer1;
    public static string[] Answer2;
    public static string[] Answer3;
    public static string[] Answer4;
    public static string[] Answer5;
    public static string[] Answer6;
    public static string[] Answer7;
    public static string[] Answer8;
    public static string[] Answer9;
    public static string[] Answer10;

    private void Start()
    {
        Answer1 = GroupImage1;
        Answer2 = GroupImage2;
        Answer3 = GroupImage3;
        Answer4 = GroupImage4;
        Answer5 = GroupImage5;
        Answer6 = GroupImage6;
        Answer7 = GroupImage7;
        Answer8 = GroupImage8;
        Answer9 = GroupImage9;
        Answer10 = GroupImage10;
    }
}
