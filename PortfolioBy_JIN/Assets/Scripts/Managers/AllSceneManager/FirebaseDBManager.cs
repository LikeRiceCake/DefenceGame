using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Database;
using UnityEngine.UI;

public class FirebaseDBManager : Singleton<FirebaseDBManager>
{
    #region //enumeration//
    public enum _EDBAction_
    {
        edbaAllRead,
        edbaNameRead,
        edbaMax
    }

    Coroutine waitCoroutine;
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    bool isCheckOver;
    bool isOverlap;
    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    DatabaseReference DBRef;

    DataManager dataManager;

    ObjectManager objectManager;

    GameManager gameManager;
    #endregion

    #region //property//
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        DBRef = FirebaseDatabase.DefaultInstance.RootReference;
        dataManager = DataManager.instance;
        objectManager = ObjectManager.instance;
        gameManager = GameManager.instance;
    }

    private void Start()
    {
        DataInit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            ReadData("users");
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            WriteCreateData(dataManager.myUserInfo);
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        isCheckOver = false;
    }
       
    public void WriteCreateData(DataManager.User userData) // ó�� ������ ���� �� ������ ����
    {
        string jsonData = JsonUtility.ToJson(userData);

        DBRef.Child("users").Child(userData.m_sUserName).SetRawJsonValueAsync(jsonData);
    }

    public void WriteUpdateData() // ������ �����(������Ʈ) ������ ����(��������)
    {
        string jsonData = JsonUtility.ToJson(dataManager.myUserInfo);

        if (dataManager.myUserInfo == null)
            return;

        DBRef.Child("users").Child(dataManager.myUserInfo.m_sUserName).SetRawJsonValueAsync(jsonData);
    }

    public void ReadData(string _path) // �������� ������ �о����
    {
        DatabaseReference readData = FirebaseDatabase.DefaultInstance.GetReference("users");

        dataManager.UserDataInit();

        waitCoroutine = StartCoroutine(WaitingAsync(_EDBAction_.edbaAllRead));

        readData.GetValueAsync().ContinueWith(
            task =>
            {
                if(task.IsCompleted)
                {
                    DataSnapshot testSnapShot = task.Result;

                    IDictionary info = (IDictionary)testSnapShot.Child(_path).Value;

                    dataManager.myUserInfo.m_nWave = Convert.ToInt32(info["m_nWave"]);
                    dataManager.myUserInfo.m_nCastleUpgrade = Convert.ToInt32(info["m_nCastleUpgrade"]);
                    dataManager.myUserInfo.m_sUserName = Convert.ToString(info["m_sUserName"]);
                    dataManager.myUserInfo.m_sQuitTime = Convert.ToString(info["m_sQuitTime"]);

                    int index = 0;

                    foreach (var value in testSnapShot.Child(_path).Child("m_nWeaponUpgrade").Children)
                    {
                        dataManager.myUserInfo.m_nWeaponUpgrade[index++] = Convert.ToInt32(value.Value);
                    }

                    index = 0;

                    foreach (var value in testSnapShot.Child(_path).Child("m_nSoldierUpgrade").Children)
                    {
                        dataManager.myUserInfo.m_nSoldierUpgrade[index++] = Convert.ToInt32(value.Value);
                    }

                    index = 0;

                    foreach (var value in testSnapShot.Child(_path).Child("m_bSoldierLock").Children)
                    {
                        dataManager.myUserInfo.m_bSoldierLock[index++] = Convert.ToBoolean(value.Value);
                    }

                    index = 0;

                    foreach (var value in testSnapShot.Child(_path).Child("m_bWeaponLock").Children)
                    {
                        dataManager.myUserInfo.m_bWeaponLock[index++] = Convert.ToBoolean(value.Value);
                    }

                    index = 0;

                    foreach (var value in testSnapShot.Child(_path).Child("m_nResource").Children)
                    {
                        dataManager.myUserInfo.m_nResource[index++] = Convert.ToInt32(value.Value);
                    }

                    index = 0;

                    foreach (var value in testSnapShot.Child(_path).Child("m_nHired").Children)
                    {
                        dataManager.myUserInfo.m_nHired[index++] = Convert.ToInt32(value.Value);
                    }

                    index = 0;

                    foreach (var value in testSnapShot.Child(_path).Child("m_fLeftTime").Children)
                    {
                        dataManager.myUserInfo.m_fLeftTime[index++] = Convert.ToDouble(value.Value);
                    }
                }

                isCheckOver = true;
            });
    }

    public void CheckUserName(string _name) // ���� �÷��� �� �г��� �ߺ� üũ
    {
        DatabaseReference readData = FirebaseDatabase.DefaultInstance.GetReference("users");

        waitCoroutine = StartCoroutine(WaitingAsync(_EDBAction_.edbaNameRead));

        readData.GetValueAsync().ContinueWith(
            task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot testSnapShot = task.Result;

                    IDictionary info = (IDictionary)testSnapShot.Value;

                    if (info != null && info.Contains(_name))
                        isOverlap = true;
                    else
                        isOverlap = false;
                }

                isCheckOver = true;
            });
    }

    public IEnumerator WaitingAsync(_EDBAction_ select)
    {
        yield return new WaitUntil(() => isCheckOver == true);
        isCheckOver = false;
        switch (select)
        {
            case _EDBAction_.edbaAllRead:
                ButtonManager.instance.CompletedRead();
                break;
            case _EDBAction_.edbaNameRead:
                ButtonManager.instance.CreateUserData(isOverlap);
                break;
            default:
                break;
        }
    }
    //-------------------------------------------- private

    #endregion
}
