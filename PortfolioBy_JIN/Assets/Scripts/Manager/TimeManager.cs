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

    //-------------------------------------------- private
    TimeSpan idleTime;

    TimeSpan testTime;

    DataManager dataManager;
    #endregion

    #region //property//
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }

    void Update()
    {
        if (GameManager.instance.currentSceneState != GameManager._ESceneState_.esMain && dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood] > 0)
        {
            CutDownTree();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        dataManager = DataManager.instance;
    }

    public void IdleTimeCalculation()
    {
        idleTime = DateTime.Now - dataManager.myUserInfo.m_sQuitTime;
    }

    public void CutDownTree()
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erWood] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltWood];
        }

    }

    public void IdleTimeForLeftTime()
    {
        for(int i = 0; i < (int)DataManager._ELeftTime_.eltMax; i++)
        {
            dataManager.myUserInfo.m_nResource[i + 1] += (int)(idleTime.TotalSeconds / DataManager.MaxLeftTime[i]);
            dataManager.myUserInfo.m_fLeftTime[i] -= idleTime.TotalSeconds % DataManager.MaxLeftTime[i];
        }
    }

    //-------------------------------------------- private
    void OnApplicationQuit()
    {
        if(GameManager.instance.currentSceneState != GameManager._ESceneState_.esMain)
            dataManager.myUserInfo.m_sQuitTime = DateTime.Now;
    }
    #endregion
}
