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
        if (Input.GetKeyDown(KeyCode.Escape)) // esc키를 누르면 종료할 수 있는 UI가 뜸
        {
            QuitFrameOnOff();
        }

        if (gameManager.currentSceneState == GameManager._ESceneState_.esOutCastle) // OutCastle에서만 호출
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

    public void QuitFrameOnOff() // 종료 화면 온 오프
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

    public void CutDownTreeTime() // 벌목의 남은 시간
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] >= 360f)
        {
            objectManager.treeLeftTimeText.text = "남은 시간 : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] / 60) + "분";
        }
        else
        {
            objectManager.treeLeftTimeText.text = "남은 시간 : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] + "초";
        }
    }

    public void SceneLoadedUIs() // 씬이 로드될 때마다 UI에 관련된 오브젝트들 참조
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
        // 씬이 로드될 때마다 ResourceUI 세팅
    }

    // ~~~UIsRef : ~~~씬 UI오브젝트 참조

    public void InCastleUIsRef()
    {

    }

    public void OutCastleUIsRef()
    {



    }

    public void DefenceUIsRef()
    {

    }

    public void SetResourceUI() // 리소스UI 세팅
    {
        for (int i = 0; i < (int)DataManager._EResource_.erMax; i++)
        {
            objectManager.resourceText[i].text = dataManager.myUserInfo.m_nResource[i].ToString();
        }
    }
    //-------------------------------------------- private

    #endregion
}
