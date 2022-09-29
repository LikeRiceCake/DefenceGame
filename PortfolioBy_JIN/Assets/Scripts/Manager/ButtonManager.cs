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
        if(gameManager.isCompletedCheck) // �г����� �ߺ� üũ�� �Ϸ�Ǿ��� ������ ���ٸ�
            CreateUserData();

        if (gameManager.isCompletedRead) // ������ �ҷ����Ⱑ �Ϸ�ƴٸ�
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
    public void Aplication_Quit() // ���� ���� ��ư
    {
        Application.Quit();
    }
    #endregion

    #region ///MainScene///
    public void MainStart() // ���� ��ŸƮ(Main)(�̹� �÷����� ���� �ִٸ� �ٷ� ����)(�ƴ϶�� ���� ����� â ��)
    {
        if (gameManager.isAlreadyPlayed)
        {
            firebaseDBManager.ReadData(playerPrefsManager.myName);
        }
        else
            objectManager.createUserFrame.SetActive(true);
    }

    public void ConfirmName() // �г��� Ȯ�� ��ư
    {
        firebaseDBManager.CheckUserName(objectManager.userNameInputText.text);
    }

    public void MainToInCastle() // InCastle������(Main)
    {
        timeManager.IdleTimeCalculation();
        timeManager.IdleTimeForLeftTime();
        SceneManager.LoadScene("InCastle");
    }

    public void CreateUserData() // �г����� �ߺ��� �ƴ϶�� ���� ������ ���� ���� ����
    {
        firebaseDBManager.WriteCreateData(dataManager.UserDataInit(objectManager.userNameInputText.text));
        gameManager.isCompletedCheck = false;
        playerPrefsManager.SetPlayerPrefsName(objectManager.userNameInputText.text);
        playerPrefsManager.SetPlayerPrefsPlayed(1);
        MainToInCastle();
    }
    #endregion

    #region ///InCastleScene///
    public void InCastleToDeffence() // Defence������(InCastle)
    {
        SceneManager.LoadScene("DefenceScene");
    }

    public void InCastleToOutCastle() // Defence������(InCastle)
    {
        SceneManager.LoadScene("OutCastle");
    }
    #endregion

    #region ///OutCastleScene///
    public void OutCastleToInCastle() // InCastle������(OutCastle)
    {
        SceneManager.LoadScene("InCastle");
    }

    public void ForestFrameOnOff() // �� �ڿ� ���� ȭ�� On, Off
    {
        if (objectManager.forestFrame.activeSelf)
            objectManager.forestFrame.SetActive(false);
        else
            objectManager.forestFrame.SetActive(true);
    }

    public void MineFrameOnOff() // ���� �ڿ� ���� ȭ�� On, Off
    {
        if (objectManager.mineFrame.activeSelf)
            objectManager.mineFrame.SetActive(false);
        else
            objectManager.mineFrame.SetActive(true);
    }

    public void TreeWorkFrameOn() // ���� ��ũ ������
    {
        objectManager.treeWorkFrame.SetActive(true);
    }

    public void TreeHire() // ���� �η� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.TreeHirePrice && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.TreeHirePrice;
        }
    }
    #endregion

    public void SceneLoadedButtons() // ���� �ε�� ������ ��ư�� �̺�Ʈ �Ҵ�
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

    // ~~~ButtonsEvent : ~~~�� ��ư�� �̺�Ʈ �Ҵ�

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
