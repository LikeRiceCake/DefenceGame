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
    #region ///InCastleScene///
    Button _inCastleToDefenceButton;
    Button _inCastleToOutCastleButton;
    #endregion

    #region ///AllScene///
    GameObject _quitFrame;

    Button _quitButton;
    #endregion

    GameManager gameManager;
    #endregion

    #region //property//
    #region ///OutCastle///

    #endregion

    #region ///InCastleScene///
    public Button inCastleToDefenceButton { get { return _inCastleToDefenceButton; } }
    public Button inCastleToOutCastleButton { get { return _inCastleToOutCastleButton; } }
    #endregion

    #region ///AllScene///
    public GameObject quitFrame { get { return _quitFrame; } }

    public Button quitButton { get { return _quitButton; } }
    #endregion
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
    }

    public void SceneLoadedObjects() // ������ ���� �ε�� ������ �ʿ��� ������Ʈ���� �����Ѵ�
    {
        AllSceneObjectsRef(); // ��� ������ ����ϴ� ������Ʈ���� �� ������ ���� => �������� ������Ʈ���� �̸��� ������ �� �̸��� ����ֵ���

        switch (gameManager.currentSceneState) // Ư���� �������� ����ϴ� ������Ʈ���� �ش� ���� ���� ���� ���� ����
        {
            case GameManager._ESceneState_.esInCastle:
                if (gameManager.isAlreadyInCastle)
                    return;
                InCastleObjectsRef();
                break;
            case GameManager._ESceneState_.esOutCastle:
                if (gameManager.isAlreadyOutCastle)
                    return;
                OutCastleObjectsRef();
                break;
            case GameManager._ESceneState_.esDefence:
                if (gameManager.isAlreadyDefence)
                    return;
                DefenceObjectsRef();
                break;

                // ������ ������ �̹� ��ȯ�߾��ٸ� isAlready�� ���ؼ� �ٽ� �������� �ʵ��� ����

                // ���� ������ ������Ʈ���� ĳ���ؼ� DataManager���� �����ϵ��� �ϴµ�, �켱 PlayerFrabs��
        }
    }

    public void AllSceneObjectsRef()
    {
        _quitFrame = GameObject.Find("Canvas").transform.Find("Quit_Frame").gameObject;

        _quitButton = _quitFrame.transform.Find("Quit_Button").gameObject.GetComponent<Button>();
    }

    public void InCastleObjectsRef()
    {
        _inCastleToDefenceButton = GameObject.Find("InCastleToDefence_Button").gameObject.GetComponent<Button>();
        _inCastleToOutCastleButton = GameObject.Find("InCastleToOutCastle_Button").gameObject.GetComponent<Button>();
    }

    public void OutCastleObjectsRef()
    {

    }

    public void DefenceObjectsRef()
    {

    }
    //-------------------------------------------- private

    #endregion
}
