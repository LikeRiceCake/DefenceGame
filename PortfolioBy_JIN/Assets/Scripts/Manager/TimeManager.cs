using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : Singleton<TimeManager>
{
    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public
    public portPlayerPrefs data;
    public TimeSpan subTime;
    public DateTime lastDateTime;
    //-------------------------------------------- private

    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    void Start()
    {
        lastDateTime = DateTime.Parse(data.Quit_Time);
        subTime = DateTime.Now - lastDateTime;
    }

    void Update()
    {
        
    }
    #endregion

    #region //function//
    //-------------------------------------------- public

    //-------------------------------------------- private
    void OnApplicationQuit()
    {
        data.Quit_Time = DateTime.Now.ToString();
        data.SetQuit_Time();
    }
    #endregion
}
