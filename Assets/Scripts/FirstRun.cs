using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class FirstRun : MonoBehaviour {

    int FirstRunGame = 0;

    void Start () {
        FirstRunGame = PlayerPrefs.GetInt("IsFirstRun");
        if (FirstRunGame == 0)
        {
            PlayerPrefs.SetInt("IsFirstRun", 1);
            PlayerPrefs.SetString("MacAdress", GetMacAddress());
          //  Debug.Log("First  " + GetMacAddress());
        }
        else
        {
           // Debug.Log("NeFirst  "+ GetMacAddress());
          //  if(PlayerPrefs.GetString("MacAdress") != GetMacAddress())
          //  {
            //    Application.Quit();
          //  }
        }
    }
    private string GetMacAddress()
    {
        string macAddresses = "";
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == OperationalStatus.Up)
            {
                macAddresses += nic.GetPhysicalAddress().ToString();
                break;
            }
        }
        return macAddresses;
    }
}
