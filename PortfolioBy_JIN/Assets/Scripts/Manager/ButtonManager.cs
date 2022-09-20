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
    Button quitButton;
    #endregion

    #region ///Main///
    Button mainToInCastleButton;
    #endregion

    #region ///InCastle///
    Button inCastleToDefenceButton;
    Button inCastleToOutCastleButton;
    #endregion

    #region ///OutCastle///
    #endregion

    ObjectManager objectManager;

    GameManager gameManager;
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
    }

    #region ///AllScene///
    public void Aplication_Quit()
    {
        Application.Quit();
    }
    #endregion

    #region ///Main///
    public void MainToStart_Button()
    {
        SceneManager.LoadScene("InCastle");
    }
    #endregion

    #region ///InCastle///
    public void InCastleToDeffence()
    {
        SceneManager.LoadScene("DefenceScene");
    }

    public void InCastleToOutCastle()
    {
        SceneManager.LoadScene("OutCastle");
    }
    #endregion

    public void SceneLoadedButtons()
    {
        AllSceneButtonsRef();

        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                if (gameManager.isAlreadyInMain)
                    return;
                MainButtonRef();
                MainButtonsEvent();
                gameManager.isAlreadyInMain = true;
                break;
            case GameManager._ESceneState_.esInCastle:
                InCastleButtonsRef();
                if (gameManager.isAlreadyInCastle)
                    return;
                InCastleButtonsEvent();
                gameManager.isAlreadyInCastle = true;
                break;
            case GameManager._ESceneState_.esOutCastle:
                OutCastleButtonsRef();
                if (gameManager.isAlreadyOutCastle)
                    return;
                OutCastleButtonsEvent();
                gameManager.isAlreadyOutCastle = true;
                break;
            case GameManager._ESceneState_.esDefence:
                DefenceButtonsRef();
                if (gameManager.isAlreadyDefence)
                    return;
                DefenceButtonsEvent();
                gameManager.isAlreadyDefence = true;
                break;
            default:
                break;
        }
    }

    public void AllSceneButtonsRef()
    {
        quitButton = objectManager.quitButton.GetComponent<Button>();

        quitButton.onClick.AddListener(Aplication_Quit);
    }

    public void MainButtonRef()
    {
        mainToInCastleButton = objectManager.mainToInCastleButton.GetComponent<Button>();

        mainToInCastleButton.onClick.AddListener(MainToStart_Button);
    }

    public void InCastleButtonsRef()
    {
        inCastleToOutCastleButton = objectManager.inCastleToOutCastleButton.GetComponent<Button>();
        inCastleToDefenceButton = objectManager.inCastleToDefenceButton.GetComponent<Button>();

        inCastleToDefenceButton.onClick.AddListener(InCastleToDeffence);
        inCastleToOutCastleButton.onClick.AddListener(InCastleToOutCastle);
    }

    public void OutCastleButtonsRef()
    {
        throw new NotImplementedException();
    }

    public void DefenceButtonsRef()
    {
        throw new NotImplementedException();
    }

    public void MainButtonsEvent()
    {

    }

    public void InCastleButtonsEvent()
    {

    }
    public void OutCastleButtonsEvent()
    {

    }

    public void DefenceButtonsEvent()
    {

    }

    // -------------------------------------------- private

    #endregion
}
