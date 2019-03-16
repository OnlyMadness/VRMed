using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLogin : MonoBehaviour {
    public Dropdown DropDown;
    public List<string> patients;
    public Text Wait;
    public Button AcceptPatient;
    // Use this for initialization
    void Start () {
        GetPatient();
    }
    private async void GetPatient()
    {
        SqlConnection SqlConnect = new SqlConnection();
        await SqlConnect.SelectPatientAsync();
        for (int i = 0; i < SqlConnect.PatientList.Count; i++)
        {
            patients.Add(SqlConnect.PatientList[i].FirstName + " " + SqlConnect.PatientList[i].Lastname);
            
        }
        DropDown.AddOptions(patients);
        Wait.enabled = false;
        AcceptPatient.GetComponent<Button>().interactable = true;
        DropDown.GetComponent<Dropdown>().interactable = true;
    }
    public void StartMenuTestsAndGames()
    {
        Patient.Id = DropDown.value.ToString();
        Patient.FullName = DropDown.transform.GetChild(0).GetComponent<Text>().text;
        Application.LoadLevel(1);
    }
}
