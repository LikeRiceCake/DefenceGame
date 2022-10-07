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
        firstPlayed = 0;
    }

    public void GetPlayerPrefsName() // PlayerPrefs�� ����� ���ó��� �ҷ�����
    {
        _myName = PlayerPrefs.GetString(myNameKey);
    }

    public void SetPlayerPrefsPlayed(int value) // ���� �������� �ƴ��� ����
    {
        PlayerPrefs.SetInt(isAlreadyPlayedKey, value);
    }

    public void SetPlayerPrefsName(string _name) // ���ó��� ����
    {
        PlayerPrefs.SetString(myNameKey, _name);
    }

    public void CheckFirstPlay() // ���� �÷������� Ȯ��
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
