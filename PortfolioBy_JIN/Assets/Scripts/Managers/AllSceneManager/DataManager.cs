using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : Singleton<DataManager>
{
    #region //enumeration//
    public enum _EResource_
    {
        erMoney,
        erWood,
        erStone,
        erIron,
        erGold,
        erDiamond,
        erMax
    }

    public enum _EMineral_
    {
        emStone,
        emIron,
        emGold,
        emDiamond,
        emMax
    } _EMineral_ _currentMineralState;

    public enum _EHired_
    {
        ehWood,
        ehStone,
        ehIron,
        ehGold,
        ehDiamond,
        ehMax
    }

    public enum _ESoldierUpgrade_
    {
        esuNormalSoldier,
        esuRareSoldier,
        esuTankSoldier,
        esuUniversalSoldier,
        esuAssassinSoldier,
        esuUnknownSoldier,
        esuMax
    } _ESoldierUpgrade_ _currentSoldierUpgradeState;

    public enum _ESoldierLock_
    {
        eslNoramlSoldier,
        eslRareSoldier,
        eslTankSoldier,
        eslUniversalSoldier,
        eslAssassinSoldier,
        eslUnknownSoldier,
        eslMax
    }

    public enum _ELeftTime_
    {
        eltWood,
        eltStone,
        eltIron,
        eltGold,
        eltDiamond,
        eltMax
    }

    public enum _ESoldierUpgradeInfo_
    {
        esuiCurrentUpgrade,
        esuiAdditionalStat,
        esuiMax
    }
    #endregion

    #region //constant//
    //-------------------------------------------- public
    public const int MaxHire = 5;
    public const int MaxSoldierUpgrade = 10;
    public const int SoldierUpgradePriceCnt = 4;

    public static readonly int[] ResourceHirePrice = { 5000, 10000, 25000, 40000, 100000 };
    public static readonly int[,] SoldierUpgradePrice =  new int[,]  {  {10000, 35000, 70000, 100000 },
                                                                        {12000, 40000, 80000, 130000 },
                                                                        {20000, 56000, 89000, 150000 },
                                                                        {30000, 67000, 95000, 170000 },
                                                                        {45000, 80000, 120000, 200000 },
                                                                        {66000, 130000, 180000, 300000 }
    };

    public static readonly float[] MaxLeftTime = { 3600f, 3600f, 10800f, 86400f, 604800f };
    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public
    public class User
    {
        public int m_nWave;
        public int m_nCastleUpgrade;
        public int m_nBallistaUpgrade;
        public string m_sUserName;
        public int[] m_nSoldierUpgrade;
        public int[] m_nResource;
        public int[] m_nHired;
        public bool[] m_nSoldierLock;
        public double[] m_fLeftTime;
        public DateTime m_sQuitTime;

        public User()
        {
            Init();
        }
        public User(string _name)
        {
            Init(_name);
        }

        void Init()
        {
            m_nWave = 1;
            m_nCastleUpgrade = 0;
            m_nBallistaUpgrade = 0;

            m_nSoldierUpgrade = new int[(int)_ESoldierUpgrade_.esuMax];
            for (int i = 0; i < (int)_ESoldierUpgrade_.esuMax; i++)
            {
                m_nSoldierUpgrade[i] = 0;
            }

            m_nSoldierLock = new bool[(int)_ESoldierLock_.eslMax];
            for (int i = 1; i < (int)_ESoldierLock_.eslMax; i++)
            {
                m_nSoldierLock[i] = false;
            }

            m_nResource = new int[(int)_EResource_.erMax];
            for (int i = 0; i < (int)_EResource_.erMax; i++)
            {
                m_nResource[i] = 0;
            }

            m_nHired = new int[(int)_EHired_.ehMax];
            for (int i = 0; i < (int)_EHired_.ehMax; i++)
            {
                m_nHired[i] = 0;
            }

            m_fLeftTime = new double[(int)_ELeftTime_.eltMax];
            for (int i = 0; i < (int)_ELeftTime_.eltMax; i++)
            {
                m_fLeftTime[i] = MaxLeftTime[i];
            }

            m_sUserName = null;
            m_sQuitTime = default;
        }
        void Init(string _name)
        {
            m_nWave = 1;
            m_nCastleUpgrade = 0;
            m_nBallistaUpgrade = 0;

            m_nSoldierUpgrade = new int[(int)_ESoldierUpgrade_.esuMax];
            for(int i = 0; i < (int)_ESoldierUpgrade_.esuMax; i++)
            {
                m_nSoldierUpgrade[i] = 0;
            }

            m_nSoldierLock = new bool[(int)_ESoldierLock_.eslMax];
            for(int i = 1; i < (int)_ESoldierLock_.eslMax; i++)
            {
                m_nSoldierLock[i] = false;
            }

            m_nResource = new int[(int)_EResource_.erMax];
            for (int i = 0; i < (int)_EResource_.erMax; i++)
            {
                m_nResource[i] = 0;
            }

            m_nHired = new int[(int)_EHired_.ehMax];
            for (int i = 0; i < (int)_EHired_.ehMax; i++)
            {
                m_nHired[i] = 0;
            }

            m_fLeftTime = new double[(int)_ELeftTime_.eltMax];
            for (int i = 0; i < (int)_ELeftTime_.eltMax; i++)
            {
                m_fLeftTime[i] = MaxLeftTime[i];
            }

            m_sUserName = _name;
            m_sQuitTime = default;
        }
    }
    //-------------------------------------------- private
    User _myUserInfo;

    FirebaseDBManager firebaseDBManager;
    #endregion

    #region //property//
    public _EMineral_ currentMineralState { get { return _currentMineralState; } set { _currentMineralState = value; } }
    public _ESoldierUpgrade_ currentSoldierUpgradeState { get { return _currentSoldierUpgradeState; } set { _currentSoldierUpgradeState = value; } }

    public User myUserInfo { get { return _myUserInfo; } set { _myUserInfo = value; } }
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        firebaseDBManager = FirebaseDBManager.instance;
        _currentMineralState = _EMineral_.emStone;
        _currentSoldierUpgradeState = _ESoldierUpgrade_.esuNormalSoldier;
        _myUserInfo = null;
    }

    public User UserDataInit() // �������� �޾ƿ� �������� �����⸦ ����
    {
        return _myUserInfo = new User();
    }

    public User UserDataInit(string _name) // User�� �̸��� ������ �ʱ� ������ ����
    {
        return _myUserInfo = new User(_name);
    }
    //-------------------------------------------- private

    #endregion
}