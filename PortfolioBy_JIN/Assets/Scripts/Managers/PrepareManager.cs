using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareManager : Singleton<PrepareManager>
{
    #region //variable//
    //-------------------------------------------- public
    //-------------------------------------------- private
    int _placedSoldier;
    int _placedSoldierMax;
    #endregion

    #region //constant//
    //-------------------------------------------- public
    public const int PlacedSoldierMaxDefault = 4;
    public const int PlacedSoldierMaxIncreased = 5;
    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    DataManager dataManager;
    #endregion

    #region //property//
    public int placedSoldier { get { return _placedSoldier; } set { _placedSoldier = value; } }
    public int placedSoldierMax { get { return _placedSoldierMax; } }
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake(); 
    }

    private void OnEnable()
    {
        dataManager = DataManager.instance;
    }

    private void Start()
    {
        DataInit();
    }

    void Update()
    {
        
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        _placedSoldier = 0;
        _placedSoldierMax = PlacedSoldierMaxDefault + dataManager.myUserInfo.m_nWave / PlacedSoldierMaxIncreased;
    }

    public void PlacedSoldierSet()
    {
        
    }
    //-------------------------------------------- private

    #endregion
}