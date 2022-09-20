using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;

public class ObjectManager : Singleton<ObjectManager>
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
    GameObject _quitFrame;

    GameObject _quitButton;
    #endregion

    #region ///MainScene///
    GameObject _mainToInCastleButton;
    #endregion

    #region ///InCastleScene///
    GameObject _inCastleToDefenceButton;
    GameObject _inCastleToOutCastleButton;
    GameObject[] _resourcesText;
    #endregion

    GameManager gameManager;
    #endregion

    #region //property//
    #region ///AllScene///
    public GameObject quitFrame { get { return _quitFrame; } }

    public GameObject quitButton { get { return _quitButton; } }
    #endregion

    #region ///Main///
    public GameObject mainToInCastleButton { get { return _mainToInCastleButton; } }
    #endregion

    #region ///InCastle///
    public GameObject inCastleToDefenceButton { get { return _inCastleToDefenceButton; } }
    public GameObject inCastleToOutCastleButton { get { return _inCastleToOutCastleButton; } }
    public GameObject moneyText { get { return _resourcesText[(int)GameManager._EResourceType_.ertMoney]; } }
    public GameObject woodText { get {return _resourcesText[(int)GameManager._EResourceType_.ertWood]; } }
    public GameObject stoneText { get {return _resourcesText[(int)GameManager._EResourceType_.ertStone]; } }
    public GameObject ironText { get {return _resourcesText[(int)GameManager._EResourceType_.ertIron]; } }
    public GameObject goldText { get {return _resourcesText[(int)GameManager._EResourceType_.ertGold]; } }
    public GameObject diamondText { get { return _resourcesText[(int)GameManager._EResourceType_.ertDiamond]; } }
    #endregion

    #region ///OutCastle///

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
        _resourcesText = new GameObject[(int)GameManager._EResourceType_.ertMax];
    }

    public void SceneLoadedObjects() // ������ ���� �ε�� ������ �ʿ��� ������Ʈ���� �����Ѵ�
    {
        AllSceneObjectsRef(); // ��� ������ ����ϴ� ������Ʈ���� �� ������ ���� => �������� ������Ʈ���� �̸��� ������ �� �̸��� ����ֵ���

        switch (gameManager.currentSceneState) // Ư���� �������� ����ϴ� ������Ʈ���� �ش� ���� ���� ���� ���� ����
        {
            case GameManager._ESceneState_.esMain:
                MainObjectRef();
                break;
            case GameManager._ESceneState_.esInCastle:
                InCastleObjectsRef();
                break;
            case GameManager._ESceneState_.esOutCastle:
                OutCastleObjectsRef();
                break;
            case GameManager._ESceneState_.esDefence:
                DefenceObjectsRef();
                break;
            default:
                break;
        }
    }

    public void AllSceneObjectsRef()
    {
        Profiler.BeginSample("SceneRef");
        _quitFrame = GameObject.Find("Canvas").transform.Find("Quit_Frame").gameObject;

        _quitButton = _quitFrame.transform.Find("Quit_Button").gameObject;
        Profiler.EndSample();
    }

    public void MainObjectRef()
    {
        _mainToInCastleButton = GameObject.Find("Start_Button");
    }

    public void InCastleObjectsRef()
    {
        _inCastleToOutCastleButton = GameObject.Find("InCastleToOutCastle_Button");
        _inCastleToDefenceButton = GameObject.Find("InCastleToDefence_Button");
        _resourcesText[(int)GameManager._EResourceType_.ertMoney] = GameObject.Find("Money_Text");
        _resourcesText[(int)GameManager._EResourceType_.ertWood] = GameObject.Find("Wodd_Text");
        _resourcesText[(int)GameManager._EResourceType_.ertStone] = GameObject.Find("Stone_Text");
        _resourcesText[(int)GameManager._EResourceType_.ertIron] = GameObject.Find("Iron_Text");
        _resourcesText[(int)GameManager._EResourceType_.ertGold] = GameObject.Find("Gold_Text");
        _resourcesText[(int)GameManager._EResourceType_.ertDiamond] = GameObject.Find("Diamond_Text");
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
