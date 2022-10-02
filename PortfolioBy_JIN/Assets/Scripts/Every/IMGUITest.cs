using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUITest : MonoBehaviour
{
    public portPlayerPrefs resource;
    public void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 300, 100), "Show Me The Money"))
        {
            resource.resources[0] += 30000;
            resource.setResources();
        }

        if (GUI.Button(new Rect(100, 200, 300, 100), "RESET"))
        {
            resource.testReset();
        }

        if (GUI.Button(new Rect(100, 300, 300, 100), "TimeFast"))
        {
            for (int i = 0; i < resource.rTime.Length; i++)
            {
                resource.rTime[i] = 5f;
                resource.SetResources_Time();
            }
        }

        if (GUI.Button(new Rect(100, 400, 300, 100), "RoundSet"))
        {
            resource.round++;
            resource.setRound();
        }

        if (GUI.Button(new Rect(100, 500, 300, 100), "ResourcesUp"))
        {
            for(int i = 1; i < resource.resources.Length; i++)
            {
                resource.resources[i] += 10;
                resource.setResources();
            }
        }

        if(GUI.Button(new Rect(100, 600, 300, 100), "ResetNameData"))
        {
            PlayerPrefsManager.instance.SetPlayerPrefsPlayed(0);
        }
    }
}
