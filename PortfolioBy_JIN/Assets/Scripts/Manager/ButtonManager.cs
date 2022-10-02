using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    #region //delegate//

    #endregion

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
        if (gameManager.isCompletedCheck) // 닉네임의 중복 체크가 완료되었고 문제가 없다면
        {
            CreateUserData();
        }

        if (gameManager.isCompletedRead) // 데이터 불러오기가 완료됐다면
        {
            gameManager.isCompletedRead = false;
            timeManager.IdleTimeCalculation();
            timeManager.IdleTimeForLeftTime();
            MainToInCastle();
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
            firebaseDBManager.ReadData(playerPrefsManager.myName);
        else
            objectManager.createUserFrame.SetActive(true);
    }

    public void ConfirmName() // 닉네임 확인 버튼
    {
        firebaseDBManager.CheckUserName(objectManager.userNameInputText.text);
    }

    public void MainToInCastle() // InCastle씬으로(Main)
    {
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
        {
            objectManager.forestFrame.SetActive(false);
            TreeWorkFrameOff();
        }
        else
        {
            objectManager.forestFrame.SetActive(true);
        }
    }

    public void MineFrameOnOff() // 광산 자원 수급 화면 On, Off
    {
        if (objectManager.mineFrame.activeSelf)
            objectManager.mineFrame.SetActive(false);
        else
            objectManager.mineFrame.SetActive(true);
    }

    public void TreeWorkFrameOn() // 나무 워크 프레임 On
    {
        objectManager.treeWorkFrame.SetActive(true);
    }

    public void TreeWorkFrameOff() // 나무 워크 프레임 Off
    {
        objectManager.treeWorkFrame.SetActive(false);
    }

    public void TreeHire() // 나무 인력 고용
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.TreeHirePrice && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.TreeHirePrice;
        }
    }

    public void StoneButtonOn() // 돌 버튼 On
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emStone].gameObject.SetActive(true);
    }

    public void StoneButtonOff() // 돌 버튼 Off
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emStone].gameObject.SetActive(false);
    }

    public void IronButtonOn() // 철 버튼 On
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emIron].gameObject.SetActive(true);
    }

    public void IronButtonOff() // 철 버튼 Off
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emIron].gameObject.SetActive(false);
    }

    public void GoldButtonOn() // 금 버튼 On
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emGold].gameObject.SetActive(true);
    }

    public void GoldButtonOff() // 금 버튼 Off
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emGold].gameObject.SetActive(false);
    }

    public void DiamondButtonOn() // 다이아 버튼 On
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emDiamond].gameObject.SetActive(true);
    }

    public void DiamondButtonOff() // 다이아 버튼 Off
    {
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emDiamond].gameObject.SetActive(false);
    }

    public void StoneWorkFrameOn() // 돌 워크 프레임 On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emStone].SetActive(true);
    }

    public void StoneWorkFrameOff() // 돌 워크 프레임 Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emStone].SetActive(false);
    }

    public void IronWorkFrameOn() // 철 워크 프레임 On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emIron].SetActive(true);
    }

    public void IronWorkFrameOff() // 철 워크 프레임 Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emIron].SetActive(false);
    }

    public void GoldWorkFrameOn() // 금 워크 프레임 On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emGold].SetActive(true);
    }

    public void GoldWorkFrameOff() // 금 워크 프레임 Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emGold].SetActive(false);
    }

    public void DiamondWorkFrameOn() // 다이아 워크 프레임 On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emDiamond].SetActive(true);
    }

    public void DiamondWorkFrameOff() // 다이아 워크 프레임 Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emDiamond].SetActive(false);
    }

    public void SwitchToNextMineral() // 다음 광물로 변경
    {
        switch (dataManager.currentMineralState)
        {
            case DataManager._EMineral_.emStone:
                SetMineralState(DataManager._EMineral_.emIron);
                break;
            case DataManager._EMineral_.emIron:
                SetMineralState(DataManager._EMineral_.emGold);
                break;
            case DataManager._EMineral_.emGold:
                SetMineralState(DataManager._EMineral_.emDiamond);
                break;
            case DataManager._EMineral_.emDiamond:
                SetMineralState(DataManager._EMineral_.emStone);
                break;
            default:
                SetMineralState(DataManager._EMineral_.emStone);
                break;
        }

        MineralObjectSelectedOnOff();
    }

    public void MineralObjectSelectedOnOff() // 현재 광물에 맞는 프레임 및 버튼 On, Off
    {
        for(int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            if((int)dataManager.currentMineralState == i)
            {
                objectManager.mineralOnButton[i].gameObject.SetActive(true);
                objectManager.mineralWorkFrame[i].SetActive(true);
                continue;
            }
            objectManager.mineralOnButton[i].gameObject.SetActive(false);
            objectManager.mineralWorkFrame[i].SetActive(false);
        }
    }

    public void SetMineralState(DataManager._EMineral_ newMineralState)
    {
        dataManager.currentMineralState = newMineralState;
    }

    #endregion

    public void SceneLoadedButtons() // 씬이 로드될 때마다 버튼들 이벤트 할당
    {
        AllSceneButtonsEvent();

        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                MainButtonsEvent();
                break;
            case GameManager._ESceneState_.esInCastle:
                InCastleButtonsEvent();
                break;
            case GameManager._ESceneState_.esOutCastle:
                OutCastleButtonsEvent();
                break;
            case GameManager._ESceneState_.esDefence:
                DefenceButtonsEvent();
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
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emStone].onClick.AddListener(StoneWorkFrameOn);
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emIron].onClick.AddListener(IronWorkFrameOn);
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emGold].onClick.AddListener(GoldWorkFrameOn);
        objectManager.mineralOnButton[(int)DataManager._EMineral_.emDiamond].onClick.AddListener(DiamondWorkFrameOn);
        objectManager.nextMineralButton.onClick.AddListener(SwitchToNextMineral);
    }

    public void DefenceButtonsEvent()
    {

    }

    // -------------------------------------------- private

    #endregion
}
