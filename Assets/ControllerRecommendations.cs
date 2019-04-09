using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRecommendations : MonoBehaviour {
    public GameObject[] ImageRecommendations;
	// Use this for initialization
	async void Start () {
        SqlConnection sqlconnect = new SqlConnection();
        await sqlconnect.SelectMarksPatientAsync(Session.Id_Patient);
        for (int i = 0; i < sqlconnect.RecommendationsGamesList.Count; i++)
        {
            if (sqlconnect.RecommendationsGamesList[i].nScore <= sqlconnect.RecommendationsGamesList[i].MarkTest)
                ImageRecommendations[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
