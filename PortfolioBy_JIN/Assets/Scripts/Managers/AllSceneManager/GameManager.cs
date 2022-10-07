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

    public enum _EBattleState_
    {
        egNotBattle,
        egBattle,
        eqMax
    } _EBattleState_ _currentBattleState;
    #endregion

    #region delegate
    delegate void myDelegate();

    myDelegate sceneLoadedManager;
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    bool _isAlreadyInMain;
    bool _isAlreadyInCastle;
    bool _isAlreadyOutCastle;
    bool _isAlreadyDefence;
    bool _isAlreadyPlayed;
    bool _isCompletedCheck;
    bool _isCompletedRead;
    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    ObjectManager objectManager;

    ButtonManager buttonManager;

    SoundManager soundManager;

    UIManager uiManager;
    #endregion

    #region //property//
    public _EGameState_ currentGameState { get { return _currentGameState; } }

    public _ESceneState_ currentSceneState { get { return _currentSceneState; } }

    public _EBattleState_ currentBattleState { get { return _currentBattleState; } }

    public bool isAlreadyInCastle { get { return _isAlreadyInCastle; } set { _isAlreadyInCastle = value; } }
    public bool isAlreadyOutCastle { get { return _isAlreadyOutCastle; } set { _isAlreadyOutCastle = value; } }
    public bool isAlreadyDefence { get { return _isAlreadyDefence; } set { _isAlreadyDefence = value; } }
    public bool isAlreadyInMain { get { return _isAlreadyInMain; } set { _isAlreadyInMain = value; } }
    public bool isAlreadyPlayed { get { return _isAlreadyPlayed; } set { _isAlreadyPlayed = value; } }
    public bool isCompletedCheck { get { return _isCompletedCheck; } set { _isCompletedCheck = value; } }
    public bool isCompletedRead { get { return _isCompletedRead; } set { _isCompletedRead = value; } }
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnEnable()
    {
        objectManager = ObjectManager.instance;
        buttonManager = ButtonManager.instance;
        uiManager = UIManager.instance;
        soundManager = SoundManager.instance;

        sceneLoadedManager += objectManager.SceneLoadedObjects;
        sceneLoadedManager += buttonManager.SceneLoadedButtons;
        sceneLoadedManager += uiManager.SceneLoadedUIs;
        sceneLoadedManager += soundManager.SceneLoadedSounds;
    }

    private void Start()
    {
        DataInit();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit() // ���� �ʱ�ȭ
    {
        SetGameState(_EGameState_.egInGame);
        SetSceneState(_ESceneState_.esMain);
        SetBattleState(_EBattleState_.egNotBattle);

        _isCompletedCheck = false;

        _isCompletedRead = false;

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

    public void SetBattleState(_EBattleState_ newBattleState) // ���� ��Ʋ ���� ����
    {
        _currentBattleState = newBattleState;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) // ���� �ε�� ������ ȣ��Ǵ� �Լ�
    {
        
        switch (scene.name) // ���� �̸��� ��
        {
            case "Main":
                SetSceneState(_ESceneState_.esMain);
                break;
            case "InCastle":
                SetSceneState(_ESceneState_.esInCastle);
                GameObject.Find("PrepareManager").gameObject.GetComponent<PrepareManager>().enabled = false;
                break;
            case "OutCastle":
                SetSceneState(_ESceneState_.esOutCastle);
                break;
            case "Defence":
                SetSceneState(_ESceneState_.esDefence);
                GameObject.Find("PrepareManager").gameObject.GetComponent<PrepareManager>().enabled = true;
                break;
            default:
                break;
        }

        sceneLoadedManager(); // �� ���� �� ȣ��Ǿ�� �� �Լ����� ���� ȣ��
    }
    //-------------------------------------------- private

    #endregion
}
