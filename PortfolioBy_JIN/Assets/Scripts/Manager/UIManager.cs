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
    Text[] resourcesText;

    int[] resourcesValue;
    #endregion

    GameManager gameManager;

    ObjectManager objectManager;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitFrameOnOff();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;

        resourcesText = new Text[(int)GameManager._EResourceType_.ertMax];
        resourcesValue = new int[(int)GameManager._EResourceType_.ertMax];
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

    public void SceneLoadedUI() // 씬이 로드될 때마다 UI에 관련된 오브젝트들 참조
    {
        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esInCastle:
                InCastleUIsRef();
                if (gameManager.isAlreadyInCastle)
                    return;
                gameManager.isAlreadyInCastle = true;
                break;
            case GameManager._ESceneState_.esOutCastle:
                OutCastleUIsRef();
                if (gameManager.isAlreadyOutCastle)
                    return;
                gameManager.isAlreadyOutCastle = true;
                break;
            case GameManager._ESceneState_.esDefence:
                DefenceUIsRef();
                if (gameManager.isAlreadyDefence)
                    return;
                gameManager.isAlreadyDefence = true;
                break;
            default:
                break;
        }
        SetResourceUI(); // 씬이 로드될 때마다 ResourceUI 세팅
    }

    // ~~~UIsRef : ~~~씬 UI오브젝트 참조

    public void InCastleUIsRef()
    {
        resourcesText[(int)GameManager._EResourceType_.ertMoney] = objectManager.moneyText;
        resourcesText[(int)GameManager._EResourceType_.ertWood] = objectManager.woodText;
        resourcesText[(int)GameManager._EResourceType_.ertStone] = objectManager.stoneText;
        resourcesText[(int)GameManager._EResourceType_.ertIron] = objectManager.ironText;
        resourcesText[(int)GameManager._EResourceType_.ertGold] = objectManager.goldText;
        resourcesText[(int)GameManager._EResourceType_.ertDiamond] = objectManager.diamondText;
    }

    public void OutCastleUIsRef()
    {
        resourcesText[(int)GameManager._EResourceType_.ertMoney] = objectManager.moneyText;
        resourcesText[(int)GameManager._EResourceType_.ertWood] = objectManager.woodText;
        resourcesText[(int)GameManager._EResourceType_.ertStone] = objectManager.stoneText;
        resourcesText[(int)GameManager._EResourceType_.ertIron] = objectManager.ironText;
        resourcesText[(int)GameManager._EResourceType_.ertGold] = objectManager.goldText;
        resourcesText[(int)GameManager._EResourceType_.ertDiamond] = objectManager.diamondText;
    }

    public void DefenceUIsRef()
    {

    }

    public void SetResourceUI() // 리소스UI 세팅
    {
        for(int i = 0; i < (int)GameManager._EResourceType_.ertMax; i++)
        {
            resourcesText[i].text = resourcesValue[i].ToString();
        }
    }
    //-------------------------------------------- private

    #endregion
}
