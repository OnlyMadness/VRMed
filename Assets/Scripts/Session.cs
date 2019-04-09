using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour {
    public static int Id_Patient { get; set; }
    public static string FullName_Patient { get; set; }
    public static int[] GameList = new int[0];
    public static int[] TestList = new int[0];
    //public class Games
    //{
    //    public string id_game;
    //    public string Type;

    //}
    public static void AddGamesList(int id_game, string name_game) {
        Array.Resize(ref GameList, GameList.Length + 1);
        GameList[GameList.Length - 1] = id_game;
    }
    public static void AddTestsList(int id_test, string name_test) {
        Array.Resize(ref TestList, TestList.Length + 1);
        TestList[TestList.Length - 1] = id_test;
    }
    // public static int[] MarksJson { get; set; }
    //  public static string[] CommentsJson { get; set; }
    //  public static string Type { get; set; } //для отправления на сервер
}
