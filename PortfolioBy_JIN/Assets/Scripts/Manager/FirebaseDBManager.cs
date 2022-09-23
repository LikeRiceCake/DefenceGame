using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Database;
using UnityEngine.UI;

public class FirebaseDBManager : Singleton<FirebaseDBManager>
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
    DatabaseReference DBRef;

    DataManager dataManager;

    ObjectManager objectManager;

    GameManager gameManager;
    #endregion

    #region //property//
    #endregion

    #region //unityLifeCycle//
    private void Awake()
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
        DBRef = FirebaseDatabase.DefaultInstance.RootReference;
        dataManager = DataManager.instance;
        objectManager = ObjectManager.instance;
        gameManager = GameManager.instance;
    }

    public void WriteCreateData(DataManager.User userData) // 처음 데이터 생성 시 서버에 저장
    {
        string jsonData = JsonUtility.ToJson(userData);

        DBRef.Child("users").Child(dataManager.myUserInfo.m_sUserName).SetRawJsonValueAsync(jsonData);
        print("완료");
        print(jsonData);
    }

    public void WriteUpdateData() // 데이터 덮어쓰기(업데이트) 서버에 저장
    {
        string jsonData = JsonUtility.ToJson(dataManager.myUserInfo);

        DBRef.Child("users").Child(dataManager.myUserInfo.m_sUserName).SetRawJsonValueAsync(jsonData);
        print("완료");
        print(jsonData);
    }

    public void ReadData(string _path)
    {
        DatabaseReference readData = FirebaseDatabase.DefaultInstance.GetReference("users");

        print("데이터 읽기 시작");

        readData.GetValueAsync().ContinueWith(
            task =>
            {
                if(task.IsCompleted)
                {
                    DataSnapshot testSnapShot = task.Result;

                    print("데이터 읽기 시작 2");
                    foreach (var data in testSnapShot.Child(_path).Children)
                    {
                        print(data);
                    }
 
                    print(dataManager.myUserInfo);
                    gameManager.isCompletedRead = true;
                }
            });
    }

    public void CheckUserName(string _name) // 최초 플레이 시 닉네임 중복 체크
    {
        DatabaseReference readData = FirebaseDatabase.DefaultInstance.GetReference("users");

        readData.GetValueAsync().ContinueWith(
            task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot testSnapShot = task.Result;

                    IDictionary info = (IDictionary)testSnapShot.Value;

                    if (info.Contains(_name))
                        gameManager.isCompletedCheck = false;
                    else
                        gameManager.isCompletedCheck = true;
                }
            });
    }
    //-------------------------------------------- private

    #endregion
}
