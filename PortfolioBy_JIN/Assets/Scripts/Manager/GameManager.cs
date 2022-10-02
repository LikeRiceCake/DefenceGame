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

    public bool isAlreadyInCastle { get { return _isAlreadyInCastle; } set { _isAlreadyInCastle = value; } }
    public bool isAlreadyOutCastle { get { return _isAlreadyOutCastle; } set { _isAlreadyOutCastle = value; } }
    public bool isAlreadyDefence { get { return _isAlreadyDefence; } set { _isAlreadyDefence = value; } }
    public bool isAlreadyInMain { get { return _isAlreadyInMain; } set { _isAlreadyInMain = value; } }
    public bool isAlreadyPlayed { get { return _isAlreadyPlayed; } set { _isAlreadyPlayed = value; } }
    public bool isCompletedCheck { get { return _isCompletedCheck; } set { _isCompletedCheck = value; } }
    public bool isCompletedRead { get { return _isCompletedRead; } set { _isCompletedRead = value; } }
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit() // 최초 초기화
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Scene이 로드될 때마다 호출될 이벤트를 추가

        SetGameState(_EGameState_.egInGame);
        SetSceneState(_ESceneState_.esMain);

        objectManager = ObjectManager.instance;
        buttonManager = ButtonManager.instance;
        soundManager = SoundManager.instance;
        uiManager = UIManager.instance;

        sceneLoadedManager += objectManager.SceneLoadedObjects;
        sceneLoadedManager += buttonManager.SceneLoadedButtons;
        sceneLoadedManager += uiManager.SceneLoadedUIs;
        sceneLoadedManager += soundManager.SceneLoadedSounds;

        _isCompletedCheck = false;

        _isCompletedRead = false;

        _isAlreadyInMain = _isAlreadyInCastle = _isAlreadyOutCastle = _isAlreadyDefence = false;
    }

    public void SetGameState(_EGameState_ newGameState) // 현재 게임 상태 변경
    {
        _currentGameState = newGameState;
    }
    
    public void SetSceneState(_ESceneState_ newSceneState) // 현재 장면 변경
    {
        _currentSceneState = newSceneState;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) // 씬이 로드될 때마다 호출되는 함수
    {
        switch(scene.name) // 씬의 이름을 비교
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

        sceneLoadedManager(); // 씬 변경 시 호출되어야 할 함수들을 전부 호출
    }
    //-------------------------------------------- private

    #endregion
}
