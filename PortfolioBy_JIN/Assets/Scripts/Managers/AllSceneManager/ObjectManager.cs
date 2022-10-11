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

    #region ///InCastle, OutCastleScene, DefenceScene///
    Text[] _resourcesText;
    #endregion

    #region ///OutCastleScene///
    GameObject _forestFrame;
    GameObject _mineFrame;
    GameObject _treeWorkFrame;
    GameObject[] _mineralsWorkFrame;

    Button _outCastleToInCastleButton;
    Button _forestFrameOnButton;
    Button _mineFrameOnButton;
    Button _forestFrameOffButton;
    Button _mineFrameOffButton;
    Button _treeWorkFrameOnButton;
    Button _treeHireButton;
    Button[] _mineralsWorkFrameOnButton;
    Button _nextMineralButton;
    Button[] _mineralsHireButton;

    Text _treeHiredCntText;
    Text _treeLeftTimeText;
    Text _treeHirePriceText;
    Text[] _mineralsHiredCntText;
    Text[] _mineralsLeftTimeText;
    Text[] _mineralsHirePriceText;
    #endregion

    #region ///DefenceScene///
    GameObject _prepareFrame;
    GameObject _battleFrame;
    GameObject _optionFrame;
    GameObject _soldierUpgradeFrame;
    GameObject _soldierUpgradeConfirmFrame;
    GameObject _soldierUnLockFrame;
    GameObject _weaponUpgradeFrame;
    GameObject _weaponUpgradeConfirmFrame;
    GameObject _castleUpgradeFrame;
    GameObject _soldierSummonSelectFrame;
    GameObject _weaponDeploySelectFrame;
    GameObject _endDefenceFrame;

    Button _defenceToInCastleButton;
    Button _optionFrameOnButton;
    Button[] _optionsButton;
    Button _soldierUpgradeFrameOnButton;
    Button _soldierUpgradeFrameOffButton;
    Button[] _soldierUpgradeConfirmFramesOnButton;
    Button _soldierUpgradeConfirmFrameOffButton;
    Button _soldierUpgradeConfirmButton;
    Button _nextSoldierButton;
    Button _soldierUnLockOffButton;
    Button _soldierUnLockConfirmButton;
    Button _weaponUpgradeFrameOnButton;
    Button _weaponUpgradeFrameOffButton;
    Button[] _weaponUpgradeConfirmFramesOnButton;
    Button _weaponUpgradeConfirmFrameOffButton;
    Button _weaponUpgradeConfirmButton;
    Button _nextWeaponButton;
    Button _defenceStartButton;
    Button _castleUpgradeFrameOnButton;
    Button _castleUpgradeFrameOffButton;
    Button _castleUpgradeConfirmButton;
    Button _soldierSummonSelectFrameOnButton;
    Button _soldierSummonSelectFrameOffButton;
    Button[] _soldierSummonsButton;
    Button _weaponDeploySelectFrameOnButton;
    Button _weaponDeploySelectFrameOffButton;
    Button[] _weaponDeploysButton;
    Button _previousRoundButton;
    Button _useMeteorButton;
    Button _gameSpeedControlButton;
    Button _endDefenceBackInCastleButton;
    Button _endDefenceRePrepareButton;

    Text _waveText;
    Text _soldierAndWeaponCntText;
    Text[] _soldierUpgradeInformationsText;
    Text _soldierUpgradePriceText;
    Text _soldierUnLockPriceText;
    Text[] _weaponUpgradeInformationsText;
    Text _weaponUpgradePriceText;
    Text[] _weaponUpgradeResourcesText;
    Text[] _castleUpgradeInformationsText;
    Text _castleUpgradePriceText;
    Text _enemyCntText;
    Text _endDefenceText;

    Image _castleHpFrontImage;
    Image _useMeteorButtonImage;
    Image _gameSpeedControlButtonImage;
    Image _endDefenceImage;

    Castle _castle;
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

    #region ///InCastleScene, OutCastleScene, DefenceScene///
    public Text[] resourceText { get { return _resourcesText; } }
    #endregion

    #region ///OutCastleScene///
    public GameObject forestFrame { get { return _forestFrame; } }
    public GameObject mineFrame { get { return _mineFrame; } }
    public GameObject treeWorkFrame { get { return _treeWorkFrame; } }
    public GameObject[] mineralsWorkFrame { get { return _mineralsWorkFrame; } }

    public Button outCastleToInCastleButton { get { return _outCastleToInCastleButton; } }
    public Button forestFrameOnButton { get { return _forestFrameOnButton; } }
    public Button mineFrameOnButton { get { return _mineFrameOnButton; } }
    public Button forestFrameOffButton { get { return _forestFrameOffButton; } }
    public Button mineFrameOffButton { get { return _mineFrameOffButton; } }
    public Button treeWorkFrameOnButton { get { return _treeWorkFrameOnButton; } }
    public Button treeHireButton { get { return _treeHireButton; } }
    public Button[] mineralsWorkFrameOnButton { get { return _mineralsWorkFrameOnButton; } }
    public Button nextMineralButton { get { return _nextMineralButton; } }
    public Button[] mineralsHireButton { get { return _mineralsHireButton; } }

    public Text treeHiredCntText { get { return _treeHiredCntText; } }
    public Text treeLeftTimeText { get { return _treeLeftTimeText; } }
    public Text treeHirePriceText { get { return _treeHirePriceText; } }
    public Text[] mineralsHiredCntText { get { return _mineralsHiredCntText; } }
    public Text[] mineralsLeftTimeText { get { return _mineralsLeftTimeText; } }
    public Text[] mineralsHirePriceText { get { return _mineralsHirePriceText; } }
    #endregion

    #region ///DefenceScene///
    public GameObject prepareFrame { get { return _prepareFrame; } }
    public GameObject battleFrame { get { return _battleFrame; } }
    public GameObject optionFrame { get { return _optionFrame; } }
    public GameObject soldierUpgradeFrame { get { return _soldierUpgradeFrame; } }
    public GameObject soldierUpgradeConfirmFrame { get { return _soldierUpgradeConfirmFrame; } }
    public GameObject soldierUnLockFrame { get { return _soldierUnLockFrame; } }
    public GameObject weaponUpgradeFrame { get { return _weaponUpgradeFrame; } }
    public GameObject weaponUpgradeConfirmFrame { get { return _weaponUpgradeConfirmFrame; } }
    public GameObject castleUpgradeFrame { get { return _castleUpgradeFrame; } }
    public GameObject soldierSummonSelectFrame { get { return _soldierSummonSelectFrame; } }
    public GameObject weaponDeploySelectFrame { get { return _weaponDeploySelectFrame; } }
    public GameObject endDefenceFrame { get { return _endDefenceFrame; } }

    public Button defenceToInCastleButton { get { return _defenceToInCastleButton; } }
    public Button optionFrameOnButton { get { return _optionFrameOnButton; } }
    public Button[] optionsButton { get { return _optionsButton; } }
    public Button soldierUpgradeFrameOnButton { get { return _soldierUpgradeFrameOnButton; } }
    public Button soldierUpgradeFrameOffButton { get { return _soldierUpgradeFrameOffButton; } }
    public Button[] soldierUpgradeConfirmFramesOnButton { get { return _soldierUpgradeConfirmFramesOnButton; } }
    public Button soldierUpgradeConfirmFrameOffButton { get { return _soldierUpgradeConfirmFrameOffButton; } }
    public Button soldierUpgradeConfirmButton { get { return _soldierUpgradeConfirmButton; } }
    public Button nextSoldierButton { get { return _nextSoldierButton; } }
    public Button soldierUnLockOffButton { get { return _soldierUnLockOffButton; } }
    public Button soldierUnLockConfirmButton { get { return _soldierUnLockConfirmButton; } }
    public Button weaponUpgradeFrameOnButton { get { return _weaponUpgradeFrameOnButton; } }
    public Button weaponUpgradeFrameOffButton { get { return _weaponUpgradeFrameOffButton; } }
    public Button[] weaponUpgradeConfirmFramesOnButton { get { return _weaponUpgradeConfirmFramesOnButton; } }
    public Button weaponUpgradeConfirmFrameOffButton { get { return _weaponUpgradeConfirmFrameOffButton; } }
    public Button weaponUpgradeConfirmButton { get { return _weaponUpgradeConfirmButton; } }
    public Button nextWeaponButton { get { return _nextWeaponButton; } }
    public Button defenceStartButton { get { return _defenceStartButton; } }
    public Button castleUpgradeFrameOnButton { get { return _castleUpgradeFrameOnButton; } }
    public Button castleUpgradeFrameOffButton { get { return _castleUpgradeFrameOffButton; } }
    public Button castleUpgradeConfirmButton { get { return _castleUpgradeConfirmButton; } }
    public Button soldierSummonSelectFrameOnButton { get { return _soldierSummonSelectFrameOnButton; } }
    public Button soldierSummonSelectFrameOffButton { get { return _soldierSummonSelectFrameOffButton; } }
    public Button[] soldierSummonsButton { get { return _soldierSummonsButton; } }
    public Button weaponDeploySelectFrameOnButton { get { return _weaponDeploySelectFrameOnButton; } }
    public Button weaponDeploySelectFrameOffButton { get { return _weaponDeploySelectFrameOffButton; } }
    public Button[] weaponDeploysButton { get { return _weaponDeploysButton; } }
    public Button previousRoundButton { get { return _previousRoundButton; } }
    public Button useMeteorButton { get { return _useMeteorButton; } }
    public Button gameSpeedControlButton { get { return _gameSpeedControlButton; } }
    public Button endDefenceBackInCastleButton { get { return _endDefenceBackInCastleButton; } }
    public Button endDefenceRePrepareButton { get { return _endDefenceRePrepareButton; } }

    public Text waveText { get { return _waveText; } }
    public Text soldierAndWeaponCntText { get { return _soldierAndWeaponCntText; } }
    public Text[] soldierUpgradeInformationsText { get { return _soldierUpgradeInformationsText; } }
    public Text soldierUpgradePriceText { get { return _soldierUpgradePriceText; } }
    public Text soldierUnLockPriceText { get { return _soldierUnLockPriceText; } }
    public Text[] weaponUpgradeInformationsText { get { return _weaponUpgradeInformationsText; } }
    public Text weaponUpgradePriceText { get { return _weaponUpgradePriceText; } }
    public Text[] weaponUpgradeResourcesText { get { return _weaponUpgradeResourcesText; } }
    public Text[] castleUpgradeInformationsText { get { return _castleUpgradeInformationsText; } }
    public Text castleUpgradePriceText { get { return _castleUpgradePriceText; } }
    public Text enemyCntText { get { return _enemyCntText; } }
    public Text endDefenceText { get { return _endDefenceText; } }

    public Image castleHpFrontImage { get { return _castleHpFrontImage; } }
    public Image useMeteorButtonImage { get { return _useMeteorButtonImage; } }
    public Image gameSpeedControlButtonImage { get { return _gameSpeedControlButtonImage; } }
    public Image endDefenceImage { get { return _endDefenceImage; } }

    public Castle castle { get { return _castle; } }
    #endregion
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        gameManager = GameManager.instance;
    }

    private void Start()
    {
        DataInit();
    }

    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        _mineralsWorkFrame = new GameObject[(int)DataManager._EMineral_.emMax];

        _mineralsWorkFrameOnButton = new Button[(int)DataManager._EMineral_.emMax];
        _mineralsHireButton = new Button[(int)DataManager._EMineral_.emMax];
        _optionsButton = new Button[(int)ButtonManager._EOptionButton_.eobMax];
        _soldierUpgradeConfirmFramesOnButton = new Button[(int)DataManager._ESoldierUpgrade_.esuMax];
        _weaponUpgradeConfirmFramesOnButton = new Button[(int)DataManager._EWeaponUpgrade_.ewuMax];
        _soldierSummonsButton = new Button[(int)DataManager._ESoldierLock_.eslMax];
        _weaponDeploysButton = new Button[(int)DataManager._EWeaponLock_.ewlMax];

        _resourcesText = new Text[(int)DataManager._EResource_.erMax];
        _mineralsHiredCntText = new Text[(int)DataManager._EMineral_.emMax];
        _mineralsLeftTimeText = new Text[(int)DataManager._EMineral_.emMax];
        _mineralsHirePriceText = new Text[(int)DataManager._EMineral_.emMax];
        _soldierUpgradeInformationsText = new Text[(int)DataManager._EUpgradeInfo_.euiMax];
        _weaponUpgradeInformationsText = new Text[(int)DataManager._EUpgradeInfo_.euiMax];
        _weaponUpgradeResourcesText = new Text[(int)DataManager._EWeaponResource_.ebrMax];
        _castleUpgradeInformationsText = new Text[(int)DataManager._EUpgradeInfo_.euiMax];
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
        _mineralsWorkFrame[(int)DataManager._EMineral_.emStone] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("StoneWorkFrame").gameObject;
        _mineralsWorkFrame[(int)DataManager._EMineral_.emIron] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("IronWorkFrame").gameObject;
        _mineralsWorkFrame[(int)DataManager._EMineral_.emGold] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("GoldWorkFrame").gameObject;
        _mineralsWorkFrame[(int)DataManager._EMineral_.emDiamond] = _mineFrame.transform.Find("MineralWorkFrame").transform.Find("DiamondWorkFrame").gameObject;

        _outCastleToInCastleButton = GameObject.Find("OutCastleToInCastle_Button").GetComponent<Button>();
        _forestFrameOnButton = GameObject.Find("ForestFrameOn_Button").GetComponent<Button>();
        _mineFrameOnButton = GameObject.Find("MineFrameOn_Button").GetComponent<Button>();
        _forestFrameOffButton = _forestFrame.transform.Find("ForestFrameOff_Button").gameObject.GetComponent<Button>();
        _mineFrameOffButton = _mineFrame.transform.Find("MineFrameOff_Button").gameObject.GetComponent<Button>();
        _treeWorkFrameOnButton = forestFrame.transform.Find("TreeFrame").transform.Find("TreeWorkFrameOn_Button").gameObject.GetComponent<Button>();
        _treeHireButton = _treeWorkFrame.transform.Find("TreeHire_Button").gameObject.GetComponent<Button>();
        _mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emStone] = _mineFrame.transform.Find("MineralFrame").transform.Find("StoneWorkFrameOn_Button").GetComponent<Button>();
        _mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emIron] = _mineFrame.transform.Find("MineralFrame").transform.Find("IronWorkFrameOn_Button").GetComponent<Button>();
        _mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emGold] = _mineFrame.transform.Find("MineralFrame").transform.Find("GoldWorkFrameOn_Button").GetComponent<Button>();
        _mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond] = _mineFrame.transform.Find("MineralFrame").transform.Find("DiamondWorkFrameOn_Button").GetComponent<Button>();
        _nextMineralButton = mineFrame.transform.Find("NextMineral_Button").GetComponent<Button>();
        _mineralsHireButton[(int)DataManager._EMineral_.emStone] = _mineralsWorkFrame[(int)DataManager._EMineral_.emStone].transform.Find("StoneHire_Button").GetComponent<Button>();
        _mineralsHireButton[(int)DataManager._EMineral_.emIron] = _mineralsWorkFrame[(int)DataManager._EMineral_.emIron].transform.Find("IronHire_Button").GetComponent<Button>();
        _mineralsHireButton[(int)DataManager._EMineral_.emGold] = _mineralsWorkFrame[(int)DataManager._EMineral_.emGold].transform.Find("GoldHire_Button").GetComponent<Button>();
        _mineralsHireButton[(int)DataManager._EMineral_.emDiamond] = _mineralsWorkFrame[(int)DataManager._EMineral_.emDiamond].transform.Find("DiamondHire_Button").GetComponent<Button>();

        _resourcesText[(int)DataManager._EResource_.erMoney] = GameObject.Find("Money_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erWood] = GameObject.Find("Wood_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erStone] = GameObject.Find("Stone_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erIron] = GameObject.Find("Iron_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erGold] = GameObject.Find("Gold_Text").GetComponent<Text>();
        _resourcesText[(int)DataManager._EResource_.erDiamond] = GameObject.Find("Diamond_Text").GetComponent<Text>();
        _treeHiredCntText = _treeWorkFrame.transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _treeLeftTimeText = _forestFrame.transform.Find("TreeLeftTime_Text").GetComponent<Text>();
        _treeHirePriceText = _treeHireButton.gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralsHiredCntText[(int)DataManager._EMineral_.emStone] = _mineralsWorkFrame[(int)DataManager._EMineral_.emStone].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralsHiredCntText[(int)DataManager._EMineral_.emIron] = _mineralsWorkFrame[(int)DataManager._EMineral_.emIron].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralsHiredCntText[(int)DataManager._EMineral_.emGold] = _mineralsWorkFrame[(int)DataManager._EMineral_.emGold].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralsHiredCntText[(int)DataManager._EMineral_.emDiamond] = _mineralsWorkFrame[(int)DataManager._EMineral_.emDiamond].transform.Find("AlreadyArrangemented").transform.Find("HiredNumber_Text").GetComponent<Text>();
        _mineralsLeftTimeText[(int)DataManager._EMineral_.emStone] = _mineFrame.transform.Find("MineralLeftText").transform.Find("StoneLeftTime_Text").GetComponent<Text>();
        _mineralsLeftTimeText[(int)DataManager._EMineral_.emIron] = _mineFrame.transform.Find("MineralLeftText").transform.Find("IronLeftTime_Text").GetComponent<Text>();
        _mineralsLeftTimeText[(int)DataManager._EMineral_.emGold] = _mineFrame.transform.Find("MineralLeftText").transform.Find("GoldLeftTime_Text").GetComponent<Text>();
        _mineralsLeftTimeText[(int)DataManager._EMineral_.emDiamond] = _mineFrame.transform.Find("MineralLeftText").transform.Find("DiamondLeftTime_Text").GetComponent<Text>();
        _mineralsHirePriceText[(int)DataManager._EMineral_.emStone] = _mineralsHireButton[(int)DataManager._EMineral_.emStone].gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralsHirePriceText[(int)DataManager._EMineral_.emIron] = _mineralsHireButton[(int)DataManager._EMineral_.emIron].gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralsHirePriceText[(int)DataManager._EMineral_.emGold] = _mineralsHireButton[(int)DataManager._EMineral_.emGold].gameObject.transform.Find("Price_Text").GetComponent<Text>();
        _mineralsHirePriceText[(int)DataManager._EMineral_.emDiamond] = _mineralsHireButton[(int)DataManager._EMineral_.emDiamond].gameObject.transform.Find("Price_Text").GetComponent<Text>();
    }

    public void DefenceObjectsRef()
    {
        _prepareFrame = GameObject.Find("PrepareFrame");
        _battleFrame = GameObject.Find("Canvas").transform.Find("BattleFrame").gameObject;
        _optionFrame = GameObject.Find("Option").transform.Find("OptionFrame").gameObject;
        _soldierUpgradeFrame = _prepareFrame.transform.Find("SoldierUpgradeFrame").gameObject;
        _soldierUpgradeConfirmFrame = _soldierUpgradeFrame.transform.Find("SoldierUpgradeConfirmFrame").gameObject;
        _soldierUnLockFrame = _soldierUpgradeFrame.transform.Find("SoldierUnLockFrame").gameObject;
        _weaponUpgradeFrame = _prepareFrame.transform.Find("WeaponUpgradeFrame").gameObject;
        _weaponUpgradeConfirmFrame = _weaponUpgradeFrame.transform.Find("WeaponUpgradeConfirmFrame").gameObject;
        _castleUpgradeFrame = _prepareFrame.transform.Find("CastleUpgradeFrame").gameObject;
        _soldierSummonSelectFrame = _prepareFrame.transform.Find("SoldierSummonSelectFrame").gameObject;
        _weaponDeploySelectFrame = _prepareFrame.transform.Find("WeaponDeploySelectFrame").gameObject;
        _endDefenceFrame = _battleFrame.transform.Find("EndDefenceFrame").gameObject;

        _defenceToInCastleButton = GameObject.Find("DefenceToInCastle_Button").GetComponent<Button>();
        _optionFrameOnButton = GameObject.Find("OptionFrameOn_Button").GetComponent<Button>();
        _optionsButton[(int)ButtonManager._EOptionButton_.eobToInCastle] = _optionFrame.transform.Find("DefenceToInCastle_Button").GetComponent<Button>();
        _optionsButton[(int)ButtonManager._EOptionButton_.eobRePrepare] = _optionFrame.transform.Find("RePrepare_Button").GetComponent<Button>();
        _optionsButton[(int)ButtonManager._EOptionButton_.eobContinue] = _optionFrame.transform.Find("Continue_Button").GetComponent<Button>();
        _soldierUpgradeFrameOnButton = GameObject.Find("SoldierUpgradeFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeFrameOffButton = _soldierUpgradeFrame.transform.Find("SoldierUpgradeFrameOff_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuNormalSoldier] = _soldierUpgradeFrame.transform.Find("NormalSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuRareSoldier] = _soldierUpgradeFrame.transform.Find("RareSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuTankSoldier] = _soldierUpgradeFrame.transform.Find("TankSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuUniversalSoldier] = _soldierUpgradeFrame.transform.Find("UniversalSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuAssassinSoldier] = _soldierUpgradeFrame.transform.Find("AssassinSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuUnknownSoldier] = _soldierUpgradeFrame.transform.Find("UnknownSoldierUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _soldierUpgradeConfirmFrameOffButton = _soldierUpgradeConfirmFrame.transform.Find("SoldierUpgradeConfirmFrameOff_Button").GetComponent<Button>();
        _soldierUpgradeConfirmButton = _soldierUpgradeConfirmFrame.transform.Find("SoldierUpgradeConfirm_Button").GetComponent<Button>();
        _nextSoldierButton = _soldierUpgradeFrame.transform.Find("NextSoldier_Button").GetComponent<Button>();
        _soldierUnLockOffButton = _soldierUnLockFrame.transform.Find("SoldierUnLockFrameOff_Button").GetComponent<Button>();
        _soldierUnLockConfirmButton = _soldierUnLockFrame.transform.Find("SoldierUnLockConfirm_Button").GetComponent<Button>();
        _weaponUpgradeFrameOnButton = GameObject.Find("WeaponUpgradeFrameOn_Button").GetComponent<Button>();
        _weaponUpgradeFrameOffButton = _weaponUpgradeFrame.transform.Find("WeaponUpgradeFrameOff_Button").GetComponent<Button>();
        _weaponUpgradeConfirmFramesOnButton[(int)DataManager._EWeaponUpgrade_.ewuBallista] = _weaponUpgradeFrame.transform.Find("BallistaUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _weaponUpgradeConfirmFrameOffButton = _weaponUpgradeConfirmFrame.transform.Find("WeaponUpgradeConfirmFrameOff_Button").GetComponent<Button>();
        _weaponUpgradeConfirmButton = _weaponUpgradeConfirmFrame.transform.Find("WeaponUpgradeConfirm_Button").GetComponent<Button>();
        _nextWeaponButton = _weaponUpgradeFrame.transform.Find("NextWeapon_Button").GetComponent<Button>();
        _defenceStartButton = GameObject.Find("DefenceStart_Button").GetComponent<Button>();
        _castleUpgradeFrameOnButton = GameObject.Find("CastleUpgradeFrameOn_Button").GetComponent<Button>();
        _castleUpgradeFrameOffButton = _castleUpgradeFrame.transform.Find("CastleUpgradeFrameOff_Button").GetComponent<Button>();
        _castleUpgradeConfirmButton = _castleUpgradeFrame.transform.Find("CastleUpgradeConfirm_Button").GetComponent<Button>();
        _soldierSummonSelectFrameOnButton = GameObject.Find("SoldierSummonSelectFrameOn_Button").GetComponent<Button>();
        _soldierSummonSelectFrameOffButton = _soldierSummonSelectFrame.transform.Find("SoldierSummonSelectFrameOff_Button").GetComponent<Button>();
        _soldierSummonsButton[(int)DataManager._ESoldierLock_.eslNoramlSoldier] = _soldierSummonSelectFrame.transform.Find("SelectButtons").transform.Find("NormalSoldierFrame").transform.Find("NormalSoldierSummon_Button").GetComponent<Button>();
        _soldierSummonsButton[(int)DataManager._ESoldierLock_.eslRareSoldier] = _soldierSummonSelectFrame.transform.Find("SelectButtons").transform.Find("RareSoldierFrame").transform.Find("RareSoldierSummon_Button").GetComponent<Button>();
        _soldierSummonsButton[(int)DataManager._ESoldierLock_.eslTankSoldier] = _soldierSummonSelectFrame.transform.Find("SelectButtons").transform.Find("TankSoldierFrame").transform.Find("TankSoldierSummon_Button").GetComponent<Button>();
        _soldierSummonsButton[(int)DataManager._ESoldierLock_.eslUniversalSoldier] = _soldierSummonSelectFrame.transform.Find("SelectButtons").transform.Find("UniversalSoldierFrame").transform.Find("UniversalSoldierSummon_Button").GetComponent<Button>();
        _soldierSummonsButton[(int)DataManager._ESoldierLock_.eslAssassinSoldier] = _soldierSummonSelectFrame.transform.Find("SelectButtons").transform.Find("AssassinSoldierFrame").transform.Find("AssassinSoldierSummon_Button").GetComponent<Button>();
        _soldierSummonsButton[(int)DataManager._ESoldierLock_.eslUnknownSoldier] = _soldierSummonSelectFrame.transform.Find("SelectButtons").transform.Find("UnknownSoldierFrame").transform.Find("UnknownSoldierSummon_Button").GetComponent<Button>();
        _weaponDeploySelectFrameOnButton = GameObject.Find("WeaponDeploySelectFrameOn_Button").GetComponent<Button>();
        _weaponDeploySelectFrameOffButton = _weaponDeploySelectFrame.transform.Find("WeaponDeploySelectFrameOff_Button").GetComponent<Button>();
        _weaponDeploysButton[(int)DataManager._EWeaponLock_.ewlBallista] = _weaponDeploySelectFrame.transform.Find("SelectButtons").transform.Find("BallistaFrame").transform.Find("BallistaDeploy_Button").GetComponent<Button>();
        _previousRoundButton = GameObject.Find("PreviousRound_Button").GetComponent<Button>();
        _useMeteorButton = _battleFrame.transform.Find("Skill").transform.Find("Meteor").transform.Find("UseMeteor_Button").GetComponent<Button>();
        _gameSpeedControlButton = _battleFrame.transform.Find("GameSpeed").transform.Find("GameSpeedControl_Button").GetComponent<Button>();
        _endDefenceBackInCastleButton = _endDefenceFrame.transform.Find("EndDefenceBackToInCastle_Button").GetComponent<Button>();
        _endDefenceRePrepareButton = _endDefenceFrame.transform.Find("EndDefenceRePrepare_Button").GetComponent<Button>();

        _resourcesText[(int)DataManager._EResource_.erMoney] = GameObject.Find("Money_Text").GetComponent<Text>();
        _waveText = GameObject.Find("Wave_Text").GetComponent<Text>();
        _soldierAndWeaponCntText = GameObject.Find("SoldierAndWeaponCnt_Text").GetComponent<Text>();
        _soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade] = _soldierUpgradeConfirmFrame.transform.Find("CurrentSoldierUpgrade_Text").GetComponent<Text>();
        _soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat] = _soldierUpgradeConfirmFrame.transform.Find("AdditionalStat_Text").GetComponent<Text>();
        _soldierUpgradePriceText = _soldierUpgradeConfirmButton.gameObject.transform.Find("SoldierUpgradePrice_Text").GetComponent<Text>();
        _soldierUnLockPriceText = _soldierUnLockConfirmButton.gameObject.transform.Find("UnLockPrice_Text").GetComponent<Text>();
        _weaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade] = _weaponUpgradeConfirmFrame.transform.Find("CurrentWeaponUpgrade_Text").GetComponent<Text>();
        _weaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat] = _weaponUpgradeConfirmFrame.transform.Find("AdditionalStat_Text").GetComponent<Text>();
        _weaponUpgradePriceText = _weaponUpgradeConfirmButton.gameObject.transform.Find("WeaponUpgradePrice_Text").GetComponent<Text>();
        _weaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrWood] = _weaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Wood_Image").transform.Find("Wood_Text").GetComponent<Text>();
        _weaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrStone] = _weaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Stone_Image").transform.Find("Stone_Text").GetComponent<Text>();
        _weaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrIron] = _weaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Iron_Image").transform.Find("Iron_Text").GetComponent<Text>();
        _weaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrGold] = _weaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Gold_Image").transform.Find("Gold_Text").GetComponent<Text>();
        _weaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrDiamond] = _weaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Diamond_Image").transform.Find("Diamond_Text").GetComponent<Text>();
        _castleUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade] = _castleUpgradeFrame.transform.Find("CurrentCastleUpgrade_Text").GetComponent<Text>();
        _castleUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat] = _castleUpgradeFrame.transform.Find("AdditionalStat_Text").GetComponent<Text>();
        _castleUpgradePriceText = _castleUpgradeConfirmButton.gameObject.transform.Find("CastleUpgradePrice_Text").GetComponent<Text>();
        _enemyCntText = _battleFrame.transform.Find("EnemyCount").transform.Find("EnemyCount_Text").GetComponent<Text>();
        _endDefenceText = _endDefenceFrame.transform.Find("EndDefence_Text").GetComponent<Text>();

        _castleHpFrontImage = _battleFrame.transform.Find("CastleHpFrame").transform.Find("CastleHpFront_Image").GetComponent<Image>();
        _useMeteorButtonImage = _useMeteorButton.GetComponent<Image>();
        _gameSpeedControlButtonImage = _gameSpeedControlButton.GetComponent<Image>();
        _endDefenceImage = _endDefenceFrame.transform.Find("EndDefence_Image").GetComponent<Image>();

        _castle = _battleFrame.transform.Find("CastleCollider").GetComponent<Castle>();
    }
    //-------------------------------------------- private

    #endregion
}
