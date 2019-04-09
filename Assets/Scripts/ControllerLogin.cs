using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLogin : MonoBehaviour {
    public Dropdown DropDown;
    public List<string> patients;
    public List<string> patients_id;
    public Text Wait;
    public Button AcceptPatient;
    // Use this for initialization
    void Start () {
        SelectExercise();
        GetPatient();
    }

    private async void SelectExercise()
    {
        SqlConnection SqlConnect = new SqlConnection();
        await SqlConnect.SelectExercise();
    }

    private async void GetPatient()
    {
        SqlConnection SqlConnect = new SqlConnection();
        await SqlConnect.SelectPatientAsync();
        for (int i = 0; i < SqlConnect.PatientList.Count; i++)
        {
            patients.Add(SqlConnect.PatientList[i].Full_name);
            patients_id.Add(SqlConnect.PatientList[i].Id);
        }
        DropDown.AddOptions(patients);
        Wait.enabled = false;
        AcceptPatient.GetComponent<Button>().interactable = true;
        DropDown.GetComponent<Dropdown>().interactable = true;
    }
    public void StartMenuTestsAndGames()
    {
        Session.Id_Patient = Convert.ToInt32(patients_id[DropDown.value]);
        Session.FullName_Patient = DropDown.transform.GetChild(0).GetComponent<Text>().text;
        Application.LoadLevel(1);
    }
}
