using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatiscticsList : MonoBehaviour {
    public GameObject StatisticsListPrefab;
    public static string[] Why;
    public static int[] Image_Number;
    public static int NumberGroupEntry = 1;
    public int CountGroupImage=10;
    public static int CountGroupImageStatic;
    public static bool ShowStat;
    public static bool Reset;
    public GameObject ThisGO;
	// Use this for initialization
	void Start () {
        Why = new string[CountGroupImage];
        Image_Number = new int[CountGroupImage];
        CountGroupImageStatic = CountGroupImage;
    }
	
    public void Statistics()
    {      
        for (int i = 1; i < CountGroupImage+1; i++)
        {
            GameObject go = Instantiate(StatisticsListPrefab);
            go.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            go.transform.GetChild(1).GetComponent<Text>().text = Image_Number[i-1].ToString();
            go.transform.GetChild(2).GetComponent<Text>().text = Why[i-1];
            go.transform.SetParent(this.transform);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, 0f);
            go.GetComponent<RectTransform>().localPosition = new Vector3(go.GetComponent<RectTransform>().localPosition.x, go.GetComponent<RectTransform>().localPosition.y, 0f);

        }
    }

	// Update is called once per frame
	void Update () {
        if (ShowStat)
        {
            Statistics();
            ShowStat = false;
        }
        if (Reset)
        {
            for (int i = 0; i < CountGroupImage; i++)
            {
                DestroyImmediate(gameObject.transform.GetChild(0).gameObject);

            }
            Reset = false;
        }
	}
}
