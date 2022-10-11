using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
{
    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
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
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        gameManager = GameManager.instance;
    }

    private void Start()
    {
        DataInit();
        CheckFirstPlay();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        isAlreadyPlayedKey = "Played";
        myNameKey = "Name";
        _myName = null;
    }

    public void GetPlayerPrefsName() // PlayerPrefs로 저장된 로컬네임 불러오기
    {
        _myName = PlayerPrefs.GetString(myNameKey);
    }

    public void SetPlayerPrefsPlayed(int value) // 최초 실행인지 아닌지 저장
    {
        PlayerPrefs.SetInt(isAlreadyPlayedKey, value);
    }

    public void SetPlayerPrefsName(string _name) // 로컬네임 저장
    {
        PlayerPrefs.SetString(myNameKey, _name);
    }

    public void CheckFirstPlay() // 최초 플레이인지 확인
    {
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
