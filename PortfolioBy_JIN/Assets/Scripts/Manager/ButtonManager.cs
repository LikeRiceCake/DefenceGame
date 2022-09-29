using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    #region ///AllScene///

    #endregion

    #region ///MainScene///

    #endregion

    #region ///InCastleScene///

    #endregion

    #region ///OutCastleScene///

    #endregion

    ObjectManager objectManager;

    GameManager gameManager;

    FirebaseDBManager firebaseDBManager;

    DataManager dataManager;

    PlayerPrefsManager playerPrefsManager;

    TimeManager timeManager;
    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }

    void Update()
    {
        if(gameManager.isCompletedCheck) // 닉네임의 중복 체크가 완료되었고 문제가 없다면
            CreateUserData();

        if (gameManager.isCompletedRead) // 데이터 불러오기가 완료됐다면
        {
            MainToInCastle();
            gameManager.isCompletedRead = false;
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        playerPrefsManager = PlayerPrefsManager.instance;
        dataManager = DataManager.instance;
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;
        firebaseDBManager = FirebaseDBManager.instance;
        timeManager = TimeManager.instance;
    }

    #region ///AllScene///
    public void Aplication_Quit() // 게임 종료 버튼
    {
        Application.Quit();
    }
    #endregion

    #region ///MainScene///
    public void MainStart() // 게임 스타트(Main)(이미 플레이한 적이 있다면 바로 시작)(아니라면 유저 만들기 창 온)
    {
        if (gameManager.isAlreadyPlayed)
        {
            firebaseDBManager.ReadData(playerPrefsManager.myName);
        }
        else
            objectManager.createUserFrame.SetActive(true);
    }

    public void ConfirmName() // 닉네임 확인 버튼
    {
        firebaseDBManager.CheckUserName(objectManager.userNameInputText.text);
    }

    public void MainToInCastle() // InCastle씬으로(Main)
    {
        timeManager.IdleTimeCalculation();
        timeManager.IdleTimeForLeftTime();
        SceneManager.LoadScene("InCastle");
    }

    public void CreateUserData() // 닉네임이 중복이 아니라면 유저 데이터 생성 과정 실행
    {
        firebaseDBManager.WriteCreateData(dataManager.UserDataInit(objectManager.userNameInputText.text));
        gameManager.isCompletedCheck = false;
        playerPrefsManager.SetPlayerPrefsName(objectManager.userNameInputText.text);
        playerPrefsManager.SetPlayerPrefsPlayed(1);
        MainToInCastle();
    }
    #endregion

    #region ///InCastleScene///
    public void InCastleToDeffence() // Defence씬으로(InCastle)
    {
        SceneManager.LoadScene("DefenceScene");
    }

    public void InCastleToOutCastle() // Defence씬으로(InCastle)
    {
        SceneManager.LoadScene("OutCastle");
    }
    #endregion

    #region ///OutCastleScene///
    public void OutCastleToInCastle() // InCastle씬으로(OutCastle)
    {
        SceneManager.LoadScene("InCastle");
    }

    public void ForestFrameOnOff() // 숲 자원 수급 화면 On, Off
    {
        if (objectManager.forestFrame.activeSelf)
            objectManager.forestFrame.SetActive(false);
        else
            objectManager.forestFrame.SetActive(true);
    }

    public void MineFrameOnOff() // 광산 자원 수급 화면 On, Off
    {
        if (objectManager.mineFrame.activeSelf)
            objectManager.mineFrame.SetActive(false);
        else
            objectManager.mineFrame.SetActive(true);
    }

    public void TreeWorkFrameOn() // 나무 워크 프레임
    {
        objectManager.treeWorkFrame.SetActive(true);
    }

    public void TreeHire() // 나무 인력 고용
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.TreeHirePrice && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.TreeHirePrice;
        }
    }
    #endregion

    public void SceneLoadedButtons() // 씬이 로드될 때마다 버튼들 이벤트 할당
    {
        AllSceneButtonsEvent();

        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                if (gameManager.isAlreadyInMain)
                    return;
                MainButtonsEvent();
                gameManager.isAlreadyInMain = true;
                break;
            case GameManager._ESceneState_.esInCastle:
                if (gameManager.isAlreadyInCastle)
                    return;
                InCastleButtonsEvent();
                gameManager.isAlreadyInCastle = true;
                break;
            case GameManager._ESceneState_.esOutCastle:
                if (gameManager.isAlreadyOutCastle)
                    return;
                OutCastleButtonsEvent();
                gameManager.isAlreadyOutCastle = true;
                break;
            case GameManager._ESceneState_.esDefence:
                if (gameManager.isAlreadyDefence)
                    return;
                DefenceButtonsEvent();
                gameManager.isAlreadyDefence = true;
                break;
            default:
                break;
        }
    }

    // ~~~ButtonsEvent : ~~~씬 버튼의 이벤트 할당

    public void AllSceneButtonsEvent()
    {
        objectManager.quitButton.onClick.AddListener(Aplication_Quit);
    }

    public void MainButtonsEvent()
    {
        objectManager.mainToInCastleButton.onClick.AddListener(MainStart);
        objectManager.createUserButton.onClick.AddListener(ConfirmName);
    }

    public void InCastleButtonsEvent()
    {
        objectManager.inCastleToDefenceButton.onClick.AddListener(InCastleToDeffence);
        objectManager.inCastleToOutCastleButton.onClick.AddListener(InCastleToOutCastle);
    }

    public void OutCastleButtonsEvent()
    {
        objectManager.outCastleToInCastleButton.onClick.AddListener(OutCastleToInCastle);
        objectManager.forestFrameOnButton.onClick.AddListener(ForestFrameOnOff);
        objectManager.mineFrameOnButton.onClick.AddListener(MineFrameOnOff);
        objectManager.forestFrameOffButton.onClick.AddListener(ForestFrameOnOff);
        objectManager.mineFrameOffButton.onClick.AddListener(MineFrameOnOff);
        objectManager.treeWorkFrameOnButton.onClick.AddListener(TreeWorkFrameOn);
        objectManager.treeHireButton.onClick.AddListener(TreeHire);
    }

    public void DefenceButtonsEvent()
    {

    }

    // -------------------------------------------- private

    #endregion
}
