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

    Button _quitButton;
    #endregion

    #region ///MainScene///
    GameObject _createUserFrame;

    Button _mainToInCastleButton;
    Button _createUserButton;

    InputField _userNameInputText;
    #endregion

    #region ///InCastleScene///
    Button _inCastleToDefenceButton;
    Button _inCastleToOutCastleButton;
    #endregion

    #region ///InCastle, OutCastleScene///
    Text[] _resourcesText;
    #endregion

    #region ///OutCastleScene///
    GameObject _forestFrame;
    GameObject _mineFrame;
    GameObject _treeWorkFrame;
    GameObject[] _mineralWorkFrame;

    Button _outCastleToInCastleButton;
    Button _forestFrameOnButton;
    Button _mineFrameOnButton;
    Button _forestFrameOffButton;
    Button _mineFrameOffButton;
    Button _treeWorkFrameOnButton;
    Button _treeHireButton;
    Button[] _mineralWorkFrameOnButton;
    Button _nextMineralButton;
    Button[] _mineralHireButton;

    Text _treeHiredCntText;
    Text _treeLeftTimeText;
    Text _treeHirePriceText;
    Text[] _mineralHiredCntText;
    Text[] _mineralLeftTimeText;
    Text[] _mineralHirePriceText;
    #endregion

    #region ///DefenceScene///
    GameObject _prepareFrame;
    GameObject _battleFrame;
    GameObject _optionFrame;
    GameObject _soldierUpgradeFrame;
    GameObject _soldierUpgradeConfirmFrame;

    GameObject _ballistaUpgradeFrame;
    GameObject _ballistaUpgradeConfirmFrame;

    Button _defenceToInCastleButton;
    Button _optionFrameOnButton;
    Button[] _optionButton;
    Button _soldierUpgradeFrameOnButton;
    Button _soldierUpgradeFrameOffButton;
    Button[] _soldierUpgradeConfirmFrameOnButton;
    Button _soldierUpgradeConfirmFrameOffButton;
    Button _soldierUpgradeConfirmButton;
    Button _nextSoldierButton;
    Button _ballistaUpgradeFrameOnButton;
    Button _ballistaUpgradeFrameOffButton;
    Button _ballistaUpgradeConfirmFrameOnButton;
    Button _ballistaUpgradeConfirmFrameOffButton;

    Text _moneyText;
    Text _waveText;
    Text _placedSoldierText;
    Text[] _soldierUpgradeInformationText;
    Text _soldierUpgradePriceText;
    #endregion

    GameManager gameManager;
    #endregion

    #region //property//
    #region ///AllScene///
    public GameObject quitFrame { get { return _quitFrame; } }

    public Button quitButton { get { return _quitButton; } }
    #endregion

    #region ///MainScene///
    public GameObject createUserFrame { get { return _createUserFrame; } }

    public Button mainToInCastleButton { get { return _mainToInCastleButton; } }
    public Button createUserButton { get { return _createUserButton; } }

    public InputField userNameInputText { get { return _userNameInputText; } }
    #endregion

    #region ///InCastleScene///
    public Button inCastleToDefenceButton { get { return _inCastleToDefenceButton; } }
    public Button inCastleToOutCastleButton { get { return _inCastleToOutCastleButton; } }
    #endregion

    #region ///InCastleScene, OutCastleScene///
    public Text[] resourceText { get { return _resourcesText; } }
    #endregion

    #region ///OutCastleScene///
    public GameObject forestFrame { get { return _forestFrame; } }
    public GameObject mineFrame { get { return _mineFrame; } }
    public GameObject treeWorkFrame { get { return _treeWorkFrame; } }
    public GameObject[] mineralWorkFrame { get { return _mineralWorkFrame; } }

    public Button outCastleToInCastleButton { get { return _outCastleToInCastleButton; } }
    public Button forestFrameOnButton { get { return _forestFrameOnButton; } }
    public Button mineFrameOnButton { get { return _mineFrameOnButton; } }
    public Button forestFrameOffButton { get { return _forestFrameOffButton; } }
    public Button mineFrameOffButton { get { return _mineFrameOffButton; } }
    public Button treeWorkFrameOnButton { get { return _treeWorkFrameOnButton; } }
    public Button treeHireButton { get { return _treeHireButton; } }
    public Button[] mineralWorkFrameOnButton { get { return _mineralWorkFrameOnButton; } }
    public Button nextMineralButton { get { return _nextMineralButton; } }
    public Button[] mineralHireButton { get { return _mineralHireButton; } }

    public Text treeHiredCntText { get { return _treeHiredCntText; } }
    public Text treeLeftTimeText { get { return _treeLeftTimeText; } }
    public Text treeHirePriceText { get { return _treeHirePriceText; } }
    public Text[] mineralHiredCntText { get { return _mineralHiredCntText; } }
    public Text[] mineralLeftTimeText { get { return _mineralLeftTimeText; } }
    public Text[] mineralHirePriceText { get { return _mineralHirePriceText; } }
    #endregion

    #region ///DefenceScene///
    public GameObject prepareFrame { get { return _prepareFrame; } }
    public GameObject battleFrame { get { return _battleFrame; } }
    public GameObject optionFrame { get { return _optionFrame; } }
    public GameObject soldierUpgradeFrame { get { return _soldierUpgradeFrame; } }
    public GameObject soldierUpgradeConfirmFrame { get { return _soldierUpgradeConfirmFrame; } }

    public GameObject ballistaUpgradeFrame { get { return _ballistaUpgradeFrame; } }
    public GameObject ballistaUpgradeConfirmFrame { get { return _ballistaUpgradeConfirmFrame; } }

    public Button defenceToInCastleButton { get { return _defenceToInCastleButton; } }
    public Button optionFrameOnButton { get { return _optionFrameOnButton; } }
    public Button[] optionButton { get { return _optionButton; } }
    public Button soldierUpgradeFrameOnButton { get { return _soldierUpgradeFrameOnButton; } }
    public Button soldierUpgradeFrameOffButton { get { return _soldierUpgradeFrameOffButton; } }
    public Button[] soldierUpgradeConfirmFrameOnButton { get { return _soldierUpgradeConfirmFrameOnButton; } }
    public Button soldierUpgradeConfirmFrameOffButton { get { return _soldierUpgradeConfirmFrameOffButton; } }
    public Button soldierUpgradeConfirmButton { get { return _soldierUpgradeConfirmButton; } }
    public Button nextSoldierButton { get { return _nextSoldierButton; } }
    public Button ballistaUpgradeFrameOnButton { get { return _ballistaUpgradeFrameOnButton; } }
    public Button ballistaUpgradeFrameOffButton { get { return _ballistaUpgradeFrameOffButton; } }
    public Button ballistaUpgradeConfirmFrameOnButton { get { return _ballistaUpgradeConfirmFrameOnButton; } }
    public Button ballistaUpgradeConfirmFrameOffButton { get { return _ballistaUpgradeConfirmFrameOffButton; } }

    public Text moneyText { get { return _moneyText; } }
    public Text waveText { get { return _waveText; } }
    public Text placedSoldierText { get { return _placedSoldierText; } }
    public Text[] soldierUpgradeInformationText { get { return _soldierUpgradeInformationText; } }
    public Text soldierUpgradePriceText { get { return _soldierUpgradePriceText; } }
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

        _mineralWorkFrame = new GameObject[(int)DataManager._EMineral_.emMax];

        _mineralWorkFrameOnButton = new Button[(int)DataManager._EMineral_.emMax];
        _mineralHireButton = new Button[(int)DataManager._EMineral_.emMax];
        _soldierUpgradeConfirmFrameOnButton = new Button[(int)DataManager._ESoldierUpgrade_.esuMax];

        _resourcesText = new Text[(int)DataManager._EResource_.erMax];
        _mineralHiredCntText = new Text[(int)DataManager._EMineral_.emMax];
        _mineralLeftTimeText = new Text[(int)DataManager._EMineral_.emMax];
        _mineralHirePriceText = new Text[(int)DataManager._EMineral_.emMax];
        _soldierUpgradeInformationText = new Text[(int)DataManager._ESoldierUpgradeInfo_.esuiMax];
    }

    public void SceneLoadedObjects() // 각각의 씬이 로드될 때마다 필요한 오브젝트들을 참조한다
    {
        AllSceneObjectsRef(); // 모든 씬에서 사용하는 오브젝트들은 매 씬마다 참조 => 공통적인 오브젝트들의 이름은 각각의 씬 이름이 담겨있도록

        switch (gameManager.currentSceneState) // 특정한 씬에서만 사용하는 오브젝트들은 해당 씬을 참조 했을 때만 참조
        {
            case GameManager._ESceneState_.esMain:
                MainObjectsRef();
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

    // ~~~ObjectRef : ~~~씬 오브젝트들 참조

    public void AllSceneObjectsRef()
    {
        Profiler.BeginSample("SceneRef");
        _quitFrame = GameObject.Find("Canvas").transform.Find("Quit_Frame").gameObject;

        _quitButton = _quitFrame.transform.Find("Quit_Button").gameObject.GetComponent<Button>();
        Profiler.EndSample();
    }

    public void MainObjectsRef()
    {
        _createUserFrame = GameObject.Find("Canvas").transform.Find("CreateUserFrame").gameObject;

        _mainToInCastleButton = GameObject.Find("Start_Button").GetComponent<Button>();
        _createUserButton = _createUserFrame.transform.Find("Create_Button").GetComponent<Button>();

        _userNameInputText = _createUserFrame.transform.Find("UserName_Input").gameObject.GetComponent<InputField>();
    }

    public void InCastleObjectsRef()
    {
        _inCastleToOutCastleButton = GameObject.Find("InCastleToOutCastle_Button").GetComponent<Button>();
        _inCastleToDefenceButton = GameObject.Find("InCastleToDefence_Button").GetComponent<Button>();

        _resourcesText[(int)DataManager._EResource_.erMoney] = GameObject.Find("Money_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erWood] = GameObject.Find("Wood_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erStone] = GameObject.Find("Stone_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erIron] = GameObject.Find("Iron_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erGold] = GameObject.Find("Gold_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erDiamond] = GameObject.Find("Diamond_Text").GetComponent<Text>();
    }

    public void OutCastleObjectsRef()
    {
        _forestFrame = GameObject.Find("ForestResource").transform.Find("ForestFrame").gameObject;
        _mineFrame = GameObject.Find("MineResource").transform.Find("MineFrame").gameObject;
        _treeWorkFrame = forestFrame.transform.Find("TreeWorkFrame").gameObject;
        _mineralWorkFrame[(int)DataManager._EMineral_.emStone] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("StoneWorkFrame").gameObject;
        _mineralWorkFrame[(int)DataManager._EMineral_.emIron] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("IronWorkFrame").gameObject;
        _mineralWorkFrame[(int)DataManager._EMineral_.emGold] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("GoldWorkFrame").gameObject;
        _mineralWorkFrame[(int)DataManager._EMineral_.emDiamond] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("DiamondWorkFrame").gameObject;

        _outCastleToInCastleButton = GameObject.Find("OutCastleToInCastle_Button").GetComponent<Button>();
        _forestFrameOnButton = GameObject.Find("ForestFrameOn_Button").GetComponent<Button>();
        _mineFrameOnButton = GameObject.Find("MineFrameOn_Button").GetComponent<Button>();
        _forestFrameOffButton = _forestFrame.transform.Find("ForestFrameOff_Button").gameObject.GetComponent<Button>();
        _mineFrameOffButton = _mineFrame.transform.Find("MineFrameOff_Button").gameObject.GetComponent<Button>();
        _treeWorkFrameOnButton = forestFrame.transform.Find("TreeFrame").transform.Find("TreeWorkFrameOn_Button").gameObject.GetComponent<Button>();
        _treeHireButton = _treeWorkFrame.transform.Find("TreeHire_Button").gameObject.GetComponent<Button>();
        _mineralWorkFrameOnButton[(int)DataManager._EMineral_.emStone] = _mineFrame.transform.Find("MineralFrame").transform.Find("StoneWorkFrameOn_Button").GetComponent<Button>();
        _mineralWorkFrameOnButton[(int)DataManager._EMineral_.emIron] = _mineFrame.transform.Find("MineralFrame").transform.Find("IronWorkFrameOn_Button").GetComponent<Button>();
        _mineralWorkFrameOnButton[(int)DataManager._EMineral_.emGold] = _mineFrame.transform.Find("MineralFrame").transform.Find("GoldWorkFrameOn_Button").GetComponent<Button>();
        _mineralWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond] = _mineFrame.transform.Find("MineralFrame").transform.Find("DiamondWorkFrameOn_Button").GetComponent<Button>();
        _nextMineralButton = mineFrame.transform.Find("NextMineral_Button").GetComponent<Button>();
        _mineralHireButton[(int)DataManager._EMineral_.emStone] = _mineralWorkFrame[(int)DataManager._EMineral_.emStone].transform.Find("StoneHire_Button").GetComponent<Button>();
        _mineralHireButton[(int)DataManager._EMineral_.emIron] = _mineralWorkFrame[(int)DataManager._EMineral_.emIron].transform.Find("IronHire_Button").GetComponent<Button>();
        _mineralHireButton[(int)DataManager._EMineral_.emGold] = _mineralWorkFrame[(int)DataManager._EMineral_.emGold].transform.Find("GoldHire_Button").GetComponent<Button>();
        _mineralHireButton[(int)DataManager._EMineral_.emDiamond] = _mineralWorkFrame[(int)DataManager._EMineral_.emDiamond].transform.Find("DiamondHire_Button").GetComponent<Button>();

        _resourcesText[(int)DataManager._EResource_.erMoney] = GameObject.Find("Money_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erWood] = GameObject.Find("Wood_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erStone] = GameObject.Find("Stone_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erIron] = GameObject.Find("Iron_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erGold] = GameObject.Find("Gold_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erDiamond] = GameObject.Find("Diamond_Text").GetComponent<Text>();
        _treeHiredCntText = _treeWorkFrame.transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _treeLeftTimeText = _forestFrame.transform.Find("TreeLeftTime_Text").GetComponent<Text>();
        _treeHirePriceText = _treeHireButton.gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralHiredCntText[(int)DataManager._EMineral_.emStone] = _mineralWorkFrame[(int)DataManager._EMineral_.emStone].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralHiredCntText[(int)DataManager._EMineral_.emIron] = _mineralWorkFrame[(int)DataManager._EMineral_.emIron].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralHiredCntText[(int)DataManager._EMineral_.emGold] = _mineralWorkFrame[(int)DataManager._EMineral_.emGold].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralHiredCntText[(int)DataManager._EMineral_.emDiamond] = _mineralWorkFrame[(int)DataManager._EMineral_.emDiamond].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralLeftTimeText[(int)DataManager._EMineral_.emStone] = _mineFrame.transform.Find("MineralLeftText").transform.Find("StoneLeftTime_Text").GetComponent<Text>();
        _mineralLeftTimeText[(int)DataManager._EMineral_.emIron] = _mineFrame.transform.Find("MineralLeftText").transform.Find("IronLeftTime_Text").GetComponent<Text>();
        _mineralLeftTimeText[(int)DataManager._EMineral_.emGold] = _mineFrame.transform.Find("MineralLeftText").transform.Find("GoldLeftTime_Text").GetComponent<Text>();
        _mineralLeftTimeText[(int)DataManager._EMineral_.emDiamond] = _mineFrame.transform.Find("MineralLeftText").transform.Find("DiamondLeftTime_Text").GetComponent<Text>();
        _mineralHirePriceText[(int)DataManager._EMineral_.emStone] = _mineralHireButton[(int)DataManager._EMineral_.emStone].gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralHirePriceText[(int)DataManager._EMineral_.emIron] = _mineralHireButton[(int)DataManager._EMineral_.emIron].gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralHirePriceText[(int)DataManager._EMineral_.emGold] = _mineralHireButton[(int)DataManager._EMineral_.emGold].gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralHirePriceText[(int)DataManager._EMineral_.emDiamond] = _mineralHireButton[(int)DataManager._EMineral_.emDiamond].gameObject.transform.Find("Price_Text").GetComponent<Text>();
    }

    public void DefenceObjectsRef()
    {
        _prepareFrame = GameObject.Find("PrepareFrame");
        _battleFrame = GameObject.Find("Canvas").transform.Find("BattleFrame").gameObject;
        _optionFrame = GameObject.Find("Option").transform.Find("OptionFrame").gameObject;
        _soldierUpgradeFrame = _prepareFrame.transform.Find("SoldierUpgradeFrame").gameObject;
        _soldierUpgradeConfirmFrame = _soldierUpgradeFrame.transform.Find("SoldierUpgradeConfirmFrame").gameObject;

        _ballistaUpgradeFrame = _prepareFrame.transform.Find("BallistaUpgradeFrame").gameObject;
        _ballistaUpgradeConfirmFrame = _ballistaUpgradeFrame.transform.Find("BallistaUpgradeConfirmFrame").gameObject;

        _defenceToInCastleButton = GameObject.Find("DefenceToInCastle_Button").GetComponent<Button>();
        _optionFrameOnButton = GameObject.Find("OptionFrameOn_Button").GetComponent<Button>();
        _optionButton[(int)ButtonManager._EOptionButton_.eobToInCastle] = _optionFrame.transform.Find("DefenceToInCastle_Button").GetComponent<Button>();
        _optionButton[(int)ButtonManager._EOptionButton_.eobRePrepare] = _optionFrame.transform.Find("RePrepare_Button").GetComponent<Button>();
        _optionButton[(int)ButtonManager._EOptionButton_.eobContinue] = _optionFrame.transform.Find("Continue_Button").GetComponent<Button>();
        _soldierUpgradeFrameOnButton = GameObject.Find("SoldierUpgradeFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeFrameOffButton = _soldierUpgradeFrame.transform.Find("SoldierUpgradeFrameOff_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuNormalSoldier] = _soldierUpgradeFrame.transform.Find("NormalSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuRareSoldier] = _soldierUpgradeFrame.transform.Find("RareSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuTankSoldier] = _soldierUpgradeFrame.transform.Find("TankSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuUniversalSoldier] = _soldierUpgradeFrame.transform.Find("UniversalSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuAssassinSoldier] = _soldierUpgradeFrame.transform.Find("AssassinSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuUnknownSoldier] = _soldierUpgradeFrame.transform.Find("UnknownSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOffButton = _soldierUpgradeConfirmFrame.transform.Find("SoldierUpgradeConfirmFrameOff_Button").GetComponent<Button>();
        _soldierUpgradeConfirmButton = _soldierUpgradeConfirmFrame.transform.Find("SoldierUpgradeConfirm_Button").GetComponent<Button>();
        _nextSoldierButton = _soldierUpgradeFrame.transform.Find("NextSoldier_Button").GetComponent<Button>();

        _ballistaUpgradeFrameOnButton = GameObject.Find("BallistaUpgradeFrameOn_Button").GetComponent<Button>();
        _ballistaUpgradeFrameOffButton = _ballistaUpgradeFrame.transform.Find("BallistaUpgradeFrameOff_Button").GetComponent<Button>();
        _ballistaUpgradeConfirmFrameOnButton = _ballistaUpgradeFrame.transform.Find("BallistaUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _ballistaUpgradeConfirmFrameOffButton = _ballistaUpgradeConfirmFrame.transform.Find("BallistaUpgradeConfirmFrameOff_Button").GetComponent<Button>();

        _moneyText = GameObject.Find("Money_Text").GetComponent<Text>();
        _waveText = GameObject.Find("Wave_Text").GetComponent<Text>();
        _placedSoldierText = GameObject.Find("PlacedSoldier_Text").GetComponent<Text>();
        _soldierUpgradeInformationText[(int)DataManager._ESoldierUpgradeInfo_.esuiCurrentUpgrade] = _soldierUpgradeConfirmFrame.transform.Find("CurrentSoldierUpgrade_Text").GetComponent<Text>();
        _soldierUpgradeInformationText[(int)DataManager._ESoldierUpgradeInfo_.esuiAdditionalStat] = _soldierUpgradeConfirmFrame.transform.Find("AdditionalStat_Text").GetComponent<Text>();
        _soldierUpgradePriceText = _soldierUpgradeConfirmButton.transform.Find("SoldierUpgradePrice_Text").GetComponent<Text>();
    }
    //-------------------------------------------- private

    #endregion
}
