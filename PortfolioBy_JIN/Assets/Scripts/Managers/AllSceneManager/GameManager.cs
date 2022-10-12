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

    DataManager dataManager;

    PrepareManager prepareManager;
    #endregion

    #region //property//
    public _EGameState_ currentGameState { get { return _currentGameState; } }

    public _ESceneState_ currentSceneState { get { return _currentSceneState; } }

    public _EBattleState_ currentBattleState { get { return _currentBattleState; } }

    public bool isAlreadyInCastle { get { return _isAlreadyInCastle; } set { _isAlreadyInCastle = value; } }
    public bool isAlreadyOutCastle { get { return _isAlreadyOutCastle; } set { _isAlreadyOutCastle = value; } }
    public bool isAlreadyDefence { get { return _isAlreadyDefence; } set { _isAlreadyDefence = value; } }
    public bool isAlreadyInMain { get { return _isAlreadyInMain; } set { _isAlreadyInMain = value; } }
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
        dataManager = DataManager.instance;
        prepareManager = PrepareManager.instance;

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
    public void DataInit() // 최초 초기화
    {
        SetGameState(_EGameState_.egInGame);
        SetSceneState(_ESceneState_.esMain);
        SetBattleState(_EBattleState_.egNotBattle);

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

    public void SetBattleState(_EBattleState_ newBattleState) // 현재 배틀 상태 변경
    {
        _currentBattleState = newBattleState;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) // 씬이 로드될 때마다 호출되는 함수
    {
        
        switch (scene.name) // 씬의 이름을 비교
        {
            case "Main":
                SetSceneState(_ESceneState_.esMain);
                break;
            case "InCastle":
                if (prepareManager.isPreviousRound)
                    prepareManager.PreviousRoundReturnSet();

                SetSceneState(_ESceneState_.esInCastle);
                GameObject.Find("Managers").transform.Find("PrepareManager").gameObject.SetActive(false);
                GameObject.Find("Managers").transform.Find("BattleManager").gameObject.SetActive(false);
                GameObject.Find("Managers").transform.Find("EnemyManager").gameObject.SetActive(false);
                GameObject.Find("Managers").transform.Find("SkillManager").gameObject.SetActive(false);
                break;
            case "OutCastle":
                SetSceneState(_ESceneState_.esOutCastle);
                break;
            case "Defence":
                SetSceneState(_ESceneState_.esDefence);
                GameObject.Find("Managers").transform.Find("PrepareManager").gameObject.SetActive(true);
                GameObject.Find("Managers").transform.Find("BattleManager").gameObject.SetActive(true);
                GameObject.Find("Managers").transform.Find("EnemyManager").gameObject.SetActive(true);
                GameObject.Find("Managers").transform.Find("SkillManager").gameObject.SetActive(true);
                SkillManager.instance.SceneLoadedSkills();
                EnemyManager.instance.SceneLoadedEnemys();
                prepareManager.ResetCnt();
                break;
            default:
                break;
        }

        sceneLoadedManager(); // 씬 변경 시 호출되어야 할 함수들을 전부 호출
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    //-------------------------------------------- private

    #endregion
}
