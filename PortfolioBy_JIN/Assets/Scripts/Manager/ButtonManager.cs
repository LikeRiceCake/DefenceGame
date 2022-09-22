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
    #endregion

    #region //property//

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
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;
        firebaseDBManager = FirebaseDBManager.instance;
    }

    #region ///AllScene///
    public void Aplication_Quit() // ���� ���� ��ư
    {
        Application.Quit();
    }
    #endregion

    #region ///MainScene///
    public void MainToStart() // ���� ��ŸƮ(Main)(�̹� �÷����� ���� �ִٸ� �ٷ� ����)(�ƴ϶�� ���� ����� â ��)
    {
        if (gameManager.isAlreadyPlayed)
        {
            MainToInCastle();
        }
        else
        {
            objectManager.createUserFrame.SetActive(true);
        }
    }

    public void CreateUserData()
    {
        firebaseDBManager.CheckUserName(objectManager.userNameInputText.text);

        if(DataManager.instance.myUserInfo != null)
        {

        }
    }

    public void MainToInCastle()
    {
        SceneManager.LoadScene("InCastle");
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

    public void treeWorkFrameOn()
    {
        objectManager.treeWorkFrame.SetActive(true);
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
        objectManager.mainToInCastleButton.onClick.AddListener(MainToStart);
        objectManager.createUserButton.onClick.AddListener(CreateUserData);
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
        objectManager.treeWorkFrameOnButton.onClick.AddListener(treeWorkFrameOn);
        //objectManager.treeHireButton.onClick.AddListener();
    }

    public void DefenceButtonsEvent()
    {

    }

    // -------------------------------------------- private

    #endregion
}
