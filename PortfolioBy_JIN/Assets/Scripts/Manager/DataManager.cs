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
        esuFirstSoldier,
        esuSecondSoldier,
        esuThirdSoldier,
        esuFourthSoldier,
        esuFifthSoldier,
        esuSixthSoldier,
        esuMax
    }

    public enum _ESoldierLock_
    {
        eslFirstSoldier,
        eslSecondSoldier,
        eslThirdSoldier,
        eslFourthSoldier,
        eslFifthSoldier,
        eslSixthSoldier,
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
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //constant//
    //-------------------------------------------- public
    public const int MaxHire = 5;
    public static readonly float[] MaxLeftTime = { 3600f, 3600f, 10800f, 86400f, 604800f };

    public const int TreeHirePrice = 5000;
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
        _myUserInfo = null;
    }

    public User UserDataInit() // 서버에서 받아올 데이터의 껍데기를 생성
    {
        return _myUserInfo = new User();
    }

    public User UserDataInit(string _name) // User의 이름을 가지고 초기 데이터 생성
    {
        return _myUserInfo = new User(_name);
    }
    //-------------------------------------------- private

    #endregion
}