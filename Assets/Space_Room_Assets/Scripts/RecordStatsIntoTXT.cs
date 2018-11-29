using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#pragma warning disable 0219
#endif

public class RecordStatsIntoTXT : MonoBehaviour {

    public MiniGamesStats gamesStats;
    private string AllStats;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Record();
        }
    }

    public void Record()
    {
        AllStats = "";

        string folder = Path.Combine(Application.dataPath, "/Stats_Attilian");
        Directory.CreateDirectory(folder);

        string filename = folder + "/stats_" + System.DateTime.Now.ToString("dd_MM_HH_mm_ss") + ".txt";

        for (int i = 0; i < gamesStats.MiniGames_Names.Length; i++)
        {
            AllStats += gamesStats.MiniGames_Names[i] + " = " + gamesStats.MiniGames_Stats[i] + "   ";
        }

        File.WriteAllText(filename, AllStats);

        #if UNITY_EDITOR
        AssetDatabase.Refresh();
        #endif
    }
}
