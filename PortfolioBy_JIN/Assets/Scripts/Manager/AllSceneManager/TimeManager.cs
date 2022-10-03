using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : Singleton<TimeManager>
{
    #region //enumeration//
    public enum _ETimeFast_
    {
        etfStop,
        etfNormal,
        etfFast,
        etfVeryFast,
        etfMax
    }
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //constant//
    //-------------------------------------------- public
    public static readonly float[] TimeFast = { 0f, 1f, 2f, 3.5f };
    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    TimeSpan idleTime;

    DataManager dataManager;

    GameManager gameManager;

    UIManager uiManager;
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
        WorkingResource();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        dataManager = DataManager.instance;
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
    }

    public void IdleTimeCalculation() // ���� ���� �ð��� ���� �ð��� �� ���
    {
        idleTime = DateTime.Now - dataManager.myUserInfo.m_sQuitTime;
    }

    public void IdleTimeForLeftTime() // ���޽ð��� ������ �ð���ŭ �۾� �ð� ����
    {
        for (int i = 0; i < (int)DataManager._ELeftTime_.eltMax; i++)
        {
            if (dataManager.myUserInfo.m_nHired[i] > 0)
            {
                dataManager.myUserInfo.m_nResource[i + 1] += (int)(idleTime.TotalSeconds / DataManager.MaxLeftTime[i]);
                dataManager.myUserInfo.m_fLeftTime[i] -= idleTime.TotalSeconds % DataManager.MaxLeftTime[i];
            }
        }
    }

    public void WorkingResource() // �ڿ� ä�� �۾�
    {
        if (gameManager.currentSceneState != GameManager._ESceneState_.esMain && dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood] > 0)
        {
            CutDownTree();
        }
        if (gameManager.currentSceneState != GameManager._ESceneState_.esMain && dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone] > 0)
        {
            MiningStone();
        }
        if (gameManager.currentSceneState != GameManager._ESceneState_.esMain && dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron] > 0)
        {
            MiningIron();
        }
        if (gameManager.currentSceneState != GameManager._ESceneState_.esMain && dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehGold] > 0)
        {
            MiningGold();
        }
        if (gameManager.currentSceneState != GameManager._ESceneState_.esMain && dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehDiamond] > 0)
        {
            MiningDiamond();
        }
    }

    public void CutDownTree() // ����
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erWood] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltWood];
            uiManager.SetResourceUI(DataManager._EResource_.erWood);
        }
    }

    public void MiningStone() // �� ä��
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erStone] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltStone];
            uiManager.SetResourceUI(DataManager._EResource_.erStone);
        }
    }

    public void MiningIron() // ö ä��
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erIron] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltIron];
            uiManager.SetResourceUI(DataManager._EResource_.erIron);
        }
    }

    public void MiningGold() // �� ä��
{
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erGold] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehGold];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltGold];
            uiManager.SetResourceUI(DataManager._EResource_.erGold);
        }
    }

    public void MiningDiamond() // ���̾� ä��
{
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erDiamond] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehDiamond];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltDiamond];
            uiManager.SetResourceUI(DataManager._EResource_.erDiamond);
        }
    }

    public void TimeControl(_ETimeFast_ select)
    {
        Time.timeScale = TimeFast[(int)select];
    }
    //-------------------------------------------- private
    void OnApplicationQuit()
    {
        if (gameManager.currentSceneState != GameManager._ESceneState_.esMain)
            dataManager.myUserInfo.m_sQuitTime = DateTime.Now;
    }
    #endregion
}
