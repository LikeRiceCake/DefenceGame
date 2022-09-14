using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public portPlayerPrefs data;
    public TimeSpan subTime;
    public DateTime lastDateTime;

    private void Start()
    {
        lastDateTime = DateTime.Parse(data.Quit_Time);
        subTime = DateTime.Now - lastDateTime;
    }

    void OnApplicationQuit()
    {
        data.Quit_Time = DateTime.Now.ToString();
        data.SetQuit_Time();
    }
}
