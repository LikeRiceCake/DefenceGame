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

    public void SceneLoadedObjects() // 각각의 씬이 로드될 때마다 필요한 오브젝트들을 참조한다
    {
        AllSceneObjectsRef(); // 모든 씬에서 사용하는 오브젝트들은 매 씬마다 참조 => 공통적인 오브젝트들의 이름은 각각의 씬 이름이 담겨있도록

        switch (gameManager.currentSceneState) // 특정한 씬에서만 사용하는 오브젝트들은 해당 씬을 참조 했을 때만 참조
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

                // 각각의 씬들을 이미 전환했었다면 isAlready를 통해서 다시 참조하지 않도록 설정

                // 이후 참조된 오브젝트들은 캐싱해서 DataManager에서 저장하도록 하는데, 우선 PlayerFrabs로
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
