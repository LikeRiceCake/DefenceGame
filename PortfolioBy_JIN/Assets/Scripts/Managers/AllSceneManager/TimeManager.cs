using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : Singleton<TimeManager>
{
    #region //enumeration//
    public enum _EGameSpeed_
    {
        egsStop,
        egsNoraml,
        egsDouble,
        egsTriple,
        egsMax
    }
    _EGameSpeed_ _currentGameSpeed;
    #endregion

    #region //constant//
    public static readonly float[] TimeFast = { 0f, 1f, 2f, 3.5f };
    #endregion

    #region //class//
    TimeSpan idleTime;

    DataManager dataManager;

    GameManager gameManager;

    UIManager uiManager;

    ObjectManager objectManager;
    #endregion

    #region //property//
    public _EGameSpeed_ currentGameSpeed { get { return _currentGameSpeed; } }
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        dataManager = DataManager.instance;
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
        objectManager = ObjectManager.instance;
    }

    void Update()
    {
        WorkingResource();

        SkillCoolDown();
    }
    #endregion

    #region //function//
    public void IdleTimeCalculation() // 최종 종료 시간과 현재 시간을 뺀 결과
    {
        if (dataManager.myUserInfo.m_sQuitTime != "")
            idleTime = DateTime.Now - Convert.ToDateTime(dataManager.myUserInfo.m_sQuitTime);
    }

    public void IdleTimeForLeftTime() // 유휴시간에 지나간 시간만큼 작업 시간 감소
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

    public void WorkingResource() // 자원 채취 작업
    {
        if (gameManager.currentSceneState != GameManager._ESceneState_.esMain)
        {
            if (dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood] > 0)
                CutDownTree();
            
            if (dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone] > 0)
                MiningStone();
            
            if (dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron] > 0)
                MiningIron();
            
            if (dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehGold] > 0)
                MiningGold();
            
            if (dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehDiamond] > 0)
                MiningDiamond();
        }
    }

    public void CutDownTree() // 벌목
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erWood] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltWood];
            uiManager.SetTextResourceUI(DataManager._EResource_.erWood);
        }
    }

    public void MiningStone() // 돌 채광
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erStone] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltStone];
            uiManager.SetTextResourceUI(DataManager._EResource_.erStone);
        }
    }

    public void MiningIron() // 철 채광
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erIron] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltIron];
            uiManager.SetTextResourceUI(DataManager._EResource_.erIron);
        }
    }

    public void MiningGold() // 금 채광
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erGold] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehGold];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltGold];
            uiManager.SetTextResourceUI(DataManager._EResource_.erGold);
        }
    }

    public void MiningDiamond() // 다이아 채광
    {
        dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] -= Time.deltaTime;

        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] <= 0f)
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erDiamond] += dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehDiamond];
            dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] = DataManager.MaxLeftTime[(int)DataManager._ELeftTime_.eltDiamond];
            uiManager.SetTextResourceUI(DataManager._EResource_.erDiamond);
        }
    }

    public void SkillCoolDown()
    {
        if (gameManager.currentBattleState == GameManager._EBattleState_.egBattle && objectManager.useMeteorButtonImage.fillAmount > 0)
            objectManager.useMeteorButtonImage.fillAmount -= (Time.deltaTime / Skill.SkillDelay);
    }


    public void SetGameSpeed(_EGameSpeed_ newGameSpeed) // 현재 게임 속도 변경
    {
        _currentGameSpeed = newGameSpeed;

        TimeControl(_currentGameSpeed);
    }

    public void GamePause(bool _active) // 게임 정지, 플레이
    {
        if (_active)
            SetGameSpeed(_EGameSpeed_.egsStop);
        else
        {
            SetGameSpeed(_EGameSpeed_.egsNoraml);
            uiManager.SetImageGameSpeed("Image/Arrow_Normal");
        }
    }

    public void TimeControl(_EGameSpeed_ select) // 속도 조절(멈춤, 일반, 빠름 등등)
    {
        Time.timeScale = TimeFast[(int)select];
    }
    #endregion
}
