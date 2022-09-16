using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    GameManager gameManager;
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
    }

    #region ///MainScene///
    public void MainToStart_Button()
    {
        SceneManager.LoadScene("InCastle");
    }
    #endregion

    #region ///AllScene///
    public void QuitFrameSet()
    {
        if (gameManager.uiManager.quitFrame.activeSelf)
        {
            Time.timeScale = 1f;
            gameManager.uiManager.quitFrame.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            gameManager.uiManager.quitFrame.gameObject.SetActive(true);
        }
    }

    public void Aplication_Quit()
    {
        Application.Quit();
    }
    #endregion

    #region ///InCastleScene///
    public void InCastleToDeffence()
    {
        SceneManager.LoadScene("DeffenceScene");
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
            case GameManager._ESceneState_.esInCastle:
                if (gameManager.isAlreadyInCastle)
                    return;
                InCastleButtonsRef();
                gameManager.isAlreadyInCastle = true;
                break;
            case GameManager._ESceneState_.esOutCastle:
                if (gameManager.isAlreadyOutCastle)
                    return;
                OutCastleButtonsRef();
                gameManager.isAlreadyOutCastle = true;
                break;
            case GameManager._ESceneState_.esDefence:
                if (gameManager.isAlreadyDefence)
                    return;
                DefenceButtonsRef();
                gameManager.isAlreadyDefence = true;
                break;
        }
    }

    public void AllSceneButtonsRef()
    {
        gameManager.uiManager.quitButton.onClick.AddListener(Aplication_Quit);
    }

    public void InCastleButtonsRef()
    {
        gameManager.uiManager.inCastleToDefenceButton.onClick.AddListener(InCastleToDeffence);
        gameManager.uiManager.inCastleToOutCastleButton.onClick.AddListener(InCastleToOutCastle);
    }

    public void OutCastleButtonsRef()
    {
        throw new NotImplementedException();
    }

    public void DefenceButtonsRef()
    {
        throw new NotImplementedException();
    }
    // -------------------------------------------- private

    #endregion
}
