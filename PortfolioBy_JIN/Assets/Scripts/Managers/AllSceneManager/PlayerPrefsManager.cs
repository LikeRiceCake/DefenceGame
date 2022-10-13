using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
{
    #region //variable//
    string isAlreadyPlayedKey;
    string myNameKey;
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        DataInit();
    }
    #endregion

    #region //function//
    public void DataInit()
    {
        isAlreadyPlayedKey = "Played";
        myNameKey = "Name";
    }

    public string GetPlayerPrefsName() // PlayerPrefs로 저장된 로컬네임 불러오기
    {
        return PlayerPrefs.GetString(myNameKey);
    }

    public void SetPlayerPrefsPlayed(int value) // 최초 실행인지 아닌지 저장
    {
        PlayerPrefs.SetInt(isAlreadyPlayedKey, value);
    }

    public void SetPlayerPrefsName(string _name) // 로컬네임 저장
    {
        PlayerPrefs.SetString(myNameKey, _name);
    }

    public int GetPlayerPrefsPlayed()
    {
        return PlayerPrefs.GetInt(isAlreadyPlayedKey);
    }

    public bool CheckFirstPlay() // 최초 플레이인지 확인
    {
        if (GetPlayerPrefsPlayed() == 0)
            return true;
        else
            return false;
        
    }
    #endregion
}
