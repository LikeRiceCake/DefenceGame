using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
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

    #region ///InCastle, OutCastleScene///

    #endregion

    GameManager gameManager;

    ObjectManager objectManager;

    DataManager dataManager;
    #endregion

    #region //property//
    #region ///AllScene///

    #endregion

    #region ///InCastle///

    #endregion

    #region ///OutCastle///

    #endregion
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // escŰ�� ������ ������ �� �ִ� UI�� ��
        {
            QuitFrameOnOff();
        }

        if (gameManager.currentSceneState == GameManager._ESceneState_.esOutCastle) // OutCastle������ ȣ��
        {
            CutDownTreeTime();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;
        dataManager = DataManager.instance;
    }

    public void QuitFrameOnOff() // ���� ȭ�� �� ����
    {
        if (objectManager.quitFrame.activeSelf)
        {
            Time.timeScale = 1f;
            objectManager.quitFrame.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            objectManager.quitFrame.gameObject.SetActive(true);
        }
    }

    public void CutDownTreeTime() // ������ ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] >= 360f)
        {
            objectManager.treeLeftTimeText.text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] / 60) + "��";
        }
        else
        {
            objectManager.treeLeftTimeText.text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] + "��";
        }
    }

    public void SceneLoadedUIs() // ���� �ε�� ������ UI�� ���õ� ������Ʈ�� ����
    {
        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esInCastle:
                InCastleUIsRef();
                SetResourceUI();
                break;
            case GameManager._ESceneState_.esOutCastle:
                OutCastleUIsRef();
                SetResourceUI();
                break;
            case GameManager._ESceneState_.esDefence:
                DefenceUIsRef();
                break;
            default:
                break;
        }
        // ���� �ε�� ������ ResourceUI ����
    }

    // ~~~UIsRef : ~~~�� UI������Ʈ ����

    public void InCastleUIsRef()
    {

    }

    public void OutCastleUIsRef()
    {



    }

    public void DefenceUIsRef()
    {

    }

    public void SetResourceUI() // ���ҽ�UI ����
    {
        for (int i = 0; i < (int)DataManager._EResource_.erMax; i++)
        {
            objectManager.resourceText[i].text = dataManager.myUserInfo.m_nResource[i].ToString();
        }
    }
    //-------------------------------------------- private

    #endregion
}
