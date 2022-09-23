using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
{
    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    int firstPlayed;

    string isAlreadyPlayedKey;
    string myNameKey;
    string _myName;
    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    GameManager gameManager;
    #endregion

    #region //property//
    public string myName { get { return _myName; } }
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
        CheckFirstPlay();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        gameManager = GameManager.instance;
        isAlreadyPlayedKey = "Played";
        myNameKey = "Name";
        _myName = null;
        firstPlayed = 0;
    }

    public void GetPlayerPrefsName() // PlayerPrefs로 저장된 로컬네임 불러오기
    {
        _myName = PlayerPrefs.GetString(myNameKey);
    }

    public void SetPlayerPrefsPlayed(int value) // 최초 실행인지 아닌지 저장
    {
        PlayerPrefs.SetInt(isAlreadyPlayedKey, value);
        print("플레이어 프랩스 Played 저장 완료");
    }

    public void SetPlayerPrefsName(string _name) // 로컬네임 저장
    {
        PlayerPrefs.SetString(myNameKey, _name);
        print("플레이어 프랩스 이름 저장 완료");
    }

    public void CheckFirstPlay() // 최초 플레이인지 확인
    {
        print(PlayerPrefs.GetInt(isAlreadyPlayedKey));
        if (PlayerPrefs.GetInt(isAlreadyPlayedKey) == 0)
            gameManager.isAlreadyPlayed = false;
        else
        {
            gameManager.isAlreadyPlayed = true;
            GetPlayerPrefsName();
        }
    }
    //-------------------------------------------- private

    #endregion
}
