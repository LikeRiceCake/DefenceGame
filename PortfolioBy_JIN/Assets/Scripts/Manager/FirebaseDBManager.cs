using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Database;
using UnityEngine.UI;

public class FirebaseDBManager : MonoBehaviour
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
    public class User
    {
        public string name;
        public int number;

        public User(string _name, int _number)
        {
            name = _name;
            number = _number;
        }
    }
    //-------------------------------------------- private
    DatabaseReference DBRef;

    User user1;
    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    private void Awake()
    {
        DataInit();
    }

    private void Start()
    {
        WriteDataTest();
    }

    void Update()
    {
        
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        DBRef = FirebaseDatabase.DefaultInstance.RootReference;
        user1 = new User("¿Ã¡¯µŒ", 1);
    }

    public void WriteDataTest()
    {
        string jsonData = JsonUtility.ToJson(user1);

        DBRef.Child("users").Child(DBRef.Push().Key).SetRawJsonValueAsync(jsonData);
    }
    //-------------------------------------------- private

    #endregion
}
