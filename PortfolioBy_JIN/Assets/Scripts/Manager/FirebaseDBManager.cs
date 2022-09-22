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
            ReadDataTest("users");
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            WriteCreateData();
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
    }

    public void WriteCreateData()
    {
        string jsonData = JsonUtility.ToJson(dataManager.myUserInfo);

        DBRef.Child("users").Child(dataManager.myUserInfo.m_sUserName).SetRawJsonValueAsync(jsonData);
        print("완료");
        print(jsonData);
    }

    public void WriteUpdateData()
    {
        string jsonData = JsonUtility.ToJson(dataManager.myUserInfo);

        DBRef.Child("users").Child(dataManager.myUserInfo.m_sUserName).SetRawJsonValueAsync(jsonData);
        print("완료");
        print(jsonData);
    }

    public void ReadDataTest(string _path)
    {
        DatabaseReference readData = FirebaseDatabase.DefaultInstance.GetReference(_path);

        readData.GetValueAsync().ContinueWith(
            task =>
            {
                if(task.IsCompleted)
                {
                    DataSnapshot testSnapShot = task.Result;

                    foreach (DataSnapshot data in testSnapShot.Children)
                    {
                        IDictionary info = (IDictionary)data.Value;
                        print(info["name"] + " " + info["number"]);
                    }
                }
            });
    }

    public void CheckUserName(string _name)
    {
        DatabaseReference readData = FirebaseDatabase.DefaultInstance.GetReference("users");

        readData.GetValueAsync().ContinueWith(
            task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot testSnapShot = task.Result;

                    IDictionary info = (IDictionary)testSnapShot.Value;

                    if(info.Contains(_name))
                    {
                        print("닉네임이 중복됩니다.");
                    }
                    else
                    {
                        print("중복이 아닙니다");
                        dataManager.UserDataCreate(_name);
                    }
                }
            });
    }
    //-------------------------------------------- private

    #endregion
}
