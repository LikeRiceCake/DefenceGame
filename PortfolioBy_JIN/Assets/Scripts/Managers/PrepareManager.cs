using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareManager : Singleton<PrepareManager>
{
    #region //variable//
    int _currentSummonedSoldier;
    int _summonedSoldierMax;
    int _currentDeployedWeapon;
    int _deployedWeaponMax;
    int _previousRound;

    bool _isPreviousRound;
    #endregion

    #region //constant//
    public const int SummonedSoldierMaxDefault = 4;
    public const int SummonedSoldierMaxIncreased = 5;
    public const int DeployedWeaponMaxDefault = 1;
    public const int DeployedWeaponMaxIncreased = 15;
    #endregion

    #region //class//
    DataManager dataManager;

    EnemyManager enemyManager;
    #endregion

    #region //property//
    public int currentSummonedSoldier { get { return _currentSummonedSoldier; } set { _currentSummonedSoldier = value; } }
    public int summonedSoldierMax { get { return _summonedSoldierMax; } }
    public int currentDeployedWeapon { get { return _currentDeployedWeapon; } set { _currentDeployedWeapon = value ; } }
    public int deployedWeaponMax { get { return _deployedWeaponMax; } }
    public int previousRound { get { return _previousRound; } set { _previousRound = value; } }

    public bool isPreviousRound { get { return _isPreviousRound; } set { _isPreviousRound = value; } }
    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        dataManager = DataManager.instance;

        enemyManager = EnemyManager.instance;

        PlacedSoldierMaxSet();
        DeployedWeaponMaxSet();
    }

    private void Start()
    {
        DataInit();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        _currentDeployedWeapon = 0;
        _currentSummonedSoldier = 0;

        _previousRound = dataManager.myUserInfo.m_nWave;

        _isPreviousRound = false;
    }

    public void PlacedSoldierMaxSet()
    {
        _summonedSoldierMax = SummonedSoldierMaxDefault + dataManager.myUserInfo.m_nWave / SummonedSoldierMaxIncreased;
    }

    public void DeployedWeaponMaxSet()
    {
        _deployedWeaponMax = DeployedWeaponMaxDefault + dataManager.myUserInfo.m_nWave / DeployedWeaponMaxIncreased;
    }

    public void PreviousRoundSet()
    {
        _previousRound = dataManager.myUserInfo.m_nWave--;
        isPreviousRound = true;
    }

    public void PreviousRoundReset()
    {
        dataManager.myUserInfo.m_nWave = _previousRound;
        isPreviousRound = false;
    }

    public void SceneLoadedCounts()
    {
        if (GameManager.instance.currentSceneState == GameManager._ESceneState_.esDefence)
        {
            PlacedSoldierMaxSet();
            DeployedWeaponMaxSet();
            _currentDeployedWeapon = 0;
            _currentSummonedSoldier = 0;
        }
    }
    #endregion
}
