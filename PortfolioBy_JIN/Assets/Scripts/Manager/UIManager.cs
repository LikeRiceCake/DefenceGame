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
    Text[] _resourcesText;

    int[] _resourcesValue;
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
            QuitFrameSet();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;

        _resourcesText = new Text[(int)GameManager._EResourceType_.ertMax];
        _resourcesValue = new int[(int)GameManager._EResourceType_.ertMax];
    }

    public void QuitFrameSet()
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

    public void SceneLoadedUI()
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
        SetResourceUI();
    }

    public void InCastleUIsRef()
    {
        _resourcesText[(int)GameManager._EResourceType_.ertMoney] = objectManager.moneyText.GetComponent<Text>();
        _resourcesText[(int)GameManager._EResourceType_.ertWood] = objectManager.woodText.GetComponent<Text>();
        _resourcesText[(int)GameManager._EResourceType_.ertStone] = objectManager.stoneText.GetComponent<Text>();
        _resourcesText[(int)GameManager._EResourceType_.ertIron] = objectManager.ironText.GetComponent<Text>();
        _resourcesText[(int)GameManager._EResourceType_.ertGold] = objectManager.goldText.GetComponent<Text>();
        _resourcesText[(int)GameManager._EResourceType_.ertDiamond] = objectManager.diamondText.GetComponent<Text>();
    }

    public void OutCastleUIsRef()
    {

    }

    public void DefenceUIsRef()
    {

    }

    public void SetResourceUI()
    {
        // moneyText.text = dataManager.money;
    }
    //-------------------------------------------- private

    #endregion
}
