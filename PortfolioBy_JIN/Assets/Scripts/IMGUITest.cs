using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUITest : MonoBehaviour
{
    public void OnGUI()
    {
        if(GUI.Button(new Rect(100, 200, 300, 100), "ShowMeTheMoney"))
        {
            DataManager.instance.myUserInfo.m_nResource[0] += 1000000;
        }
        if(GUI.Button(new Rect(100, 600, 300, 100), "ResetNameData"))
        {
            PlayerPrefsManager.instance.SetPlayerPrefsPlayed(0);
        }
    }
}
