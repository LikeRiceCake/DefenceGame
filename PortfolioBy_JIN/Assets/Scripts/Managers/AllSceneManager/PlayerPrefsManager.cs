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
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        isAlreadyPlayedKey = "Played";
        myNameKey = "Name";
    }

    public string GetPlayerPrefsName() // PlayerPrefs�� ����� ���ó��� �ҷ�����
    {
        return PlayerPrefs.GetString(myNameKey);
    }

    public void SetPlayerPrefsPlayed(int value) // ���� �������� �ƴ��� ����
    {
        PlayerPrefs.SetInt(isAlreadyPlayedKey, value);
    }

    public void SetPlayerPrefsName(string _name) // ���ó��� ����
    {
        PlayerPrefs.SetString(myNameKey, _name);
    }

    public int GetPlayerPrefsPlayed()
    {
        return PlayerPrefs.GetInt(isAlreadyPlayedKey);
    }

    public bool CheckFirstPlay() // ���� �÷������� Ȯ��
    {
        if (GetPlayerPrefsPlayed() == 0)
            return true;
        else
            return false;
        
    }
    //-------------------------------------------- private

    #endregion
}
