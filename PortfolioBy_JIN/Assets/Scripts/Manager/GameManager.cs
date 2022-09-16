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
        egInMenu
    } _EGameState_ _currentGameState;

    public enum _ESceneState_
    {
        esInCastle,
        esOutCastle,
        esDefence,
        egMain
    } _ESceneState_ _currentSceneState;
    #endregion

    #region delegate
    delegate void MyDelegate();

    MyDelegate managerSceneLoadedObjects;
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
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
    UIManager _uiManager;

    ButtonManager _buttonManager;
    #endregion

    #region //property//
    public UIManager uiManager { get { return _uiManager; } }

    public ButtonManager buttonManager { get { return _buttonManager; } }

    public _EGameState_ currentGameState { get { return _currentGameState; } }

    public _ESceneState_ currentSceneState { get { return _currentSceneState; } }

    public bool isAlreadyInCastle { get { return _isAlreadyInCastle; } set { _isAlreadyInCastle = value; } }
    public bool isAlreadyOutCastle { get { return _isAlreadyOutCastle; } set { _isAlreadyOutCastle = value; } }
    public bool isAlreadyDefence { get { return _isAlreadyDefence; } set { _isAlreadyDefence = value; } }
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        SetGameState(_EGameState_.egInGame);
        SetSceneState(_ESceneState_.egMain);

        _uiManager = UIManager.instance;
        _buttonManager = ButtonManager.instance;

        managerSceneLoadedObjects += _uiManager.SceneLoadedObjects;
        managerSceneLoadedObjects += _buttonManager.SceneLoadedButtons;

        _isAlreadyInCastle = _isAlreadyOutCastle = _isAlreadyDefence = false;
    }

    public void SetGameState(_EGameState_ newGameState)
    {
        _currentGameState = newGameState;
    }
    
    public void SetSceneState(_ESceneState_ newSceneState)
    {
        _currentSceneState = newSceneState;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) // 씬이 로드될 때마다 호출되는 함수
    {
        switch(scene.name) // 씬의 이름을 비교
        {
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
        if(!isAlreadyDefence || !isAlreadyInCastle || !isAlreadyOutCastle) // 씬 전부 한 번씩은 전환했었다면 더이상 오브젝트들을 참조할 필요가 없음
            managerSceneLoadedObjects();
    }
    //-------------------------------------------- private

    #endregion
}
