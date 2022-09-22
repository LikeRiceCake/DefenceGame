using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    #region //enumeration//
    public enum _EResource_
    {
        ertMoney,
        ertWood,
        ertStone,
        ertIron,
        ertGold,
        ertDiamond,
        ertMax
    }

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

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public
    public class User
    {
        public int m_nWave;
        public int m_nCastleUpgrade;
        public int m_nBallistaUpgrade;
        public int[] m_nSoldierUpgrade;
        public int[] m_nSoldierLock;
        public int[] m_nResource;
        public int[] m_nHired;
        public float[] m_fLeftTime;
        public string m_sUserName;
        public string m_sQuitTime;

        public User(string _name)
        {
            Init(_name);
        }

        void Init(string _name)
        {
            m_nWave = 1;
            m_nCastleUpgrade = 0;
            m_nBallistaUpgrade = 0;
            m_nSoldierUpgrade = new int[(int)_ESoldierUpgrade_.esuMax];
            m_nSoldierLock = new int[(int)_ESoldierLock_.eslMax];
            m_nResource = new int[(int)_EResource_.ertMax];
            m_nHired = new int[(int)_EHired_.ehMax];
            m_fLeftTime = new float[(int)_ELeftTime_.eltMax];
            m_sUserName = _name;
            m_sQuitTime = null;
        }
    }
    //-------------------------------------------- private
    User _myUserInfo;

    FirebaseDBManager firebaseDBManager;
    #endregion

    #region //property//
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
    }

    public void UserDataCreate(string _name)
    {
        _myUserInfo = new User(_name);

        firebaseDBManager.WriteCreateData();
    }
    //-------------------------------------------- private

    #endregion
}