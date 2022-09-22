using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region //enumeration//
    public enum _EGameState_
    {
        egInGame,
        egInMenu,
        eqMax
    } _EGameState_ _currentGameState;

    public enum _ESceneState_
    {
        esInCastle,
        esOutCastle,
        esDefence,
        esMain,
        esMax
    } _ESceneState_ _currentSceneState;
    #endregion

    public enum _EResourceType_
    {
        ertMoney,
        ertWood,
        ertStone,
        ertIron,
        ertGold,
        ertDiamond,
        ertMax
    }

    #region delegate
    delegate void MyDelegate();

    MyDelegate sceneLoadedManager;
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    bool _isAlreadyInMain;
    bool _isAlreadyInCastle;
    bool _isAlreadyOutCastle;
    bool _isAlreadyDefence;
    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    ObjectManager _objectManager;

    ButtonManager _buttonManager;
    #endregion

    #region //property//
    public _EGameState_ currentGameState { get { return _currentGameState; } }

    public _ESceneState_ currentSceneState { get { return _currentSceneState; } }

    public bool isAlreadyInCastle { get { return _isAlreadyInCastle; } set { _isAlreadyInCastle = value; } }
    public bool isAlreadyOutCastle { get { return _isAlreadyOutCastle; } set { _isAlreadyOutCastle = value; } }
    public bool isAlreadyDefence { get { return _isAlreadyDefence; } set { _isAlreadyDefence = value; } }
    public bool isAlreadyInMain { get { return _isAlreadyInMain; } set { _isAlreadyInMain = value; } }
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit() // ���� �ʱ�ȭ
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Scene�� �ε�� ������ ȣ��� �̺�Ʈ�� �߰�

        SetGameState(_EGameState_.egInGame);
        SetSceneState(_ESceneState_.esMain);

        _objectManager = ObjectManager.instance;
        _buttonManager = ButtonManager.instance;

        sceneLoadedManager += _objectManager.SceneLoadedObjects;
        sceneLoadedManager += _buttonManager.SceneLoadedButtons;

        _isAlreadyInMain = _isAlreadyInCastle = _isAlreadyOutCastle = _isAlreadyDefence = false;
    }

    public void SetGameState(_EGameState_ newGameState) // ���� ���� ���� ����
    {
        _currentGameState = newGameState;
    }
    
    public void SetSceneState(_ESceneState_ newSceneState) // ���� ��� ����
    {
        _currentSceneState = newSceneState;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) // ���� �ε�� ������ ȣ��Ǵ� �Լ�
    {
        switch(scene.name) // ���� �̸��� ��
        {
            case "Main":
                SetSceneState(_ESceneState_.esMain);
                break;
            case "InCastle":
                SetSceneState(_ESceneState_.esInCastle);
                break;
            case "OutCastle":
                SetSceneState(_ESceneState_.esOutCastle);
                break;
            case "Defence":
                SetSceneState(_ESceneState_.esDefence);
                break;
            default:
                break;
        }

        sceneLoadedManager(); // �� ���� �� ȣ��Ǿ�� �� �Լ����� ���� ȣ��
    }
    //-------------------------------------------- private

    #endregion
}
