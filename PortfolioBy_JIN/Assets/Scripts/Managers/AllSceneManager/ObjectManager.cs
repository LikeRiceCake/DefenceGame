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
    GameObject _WeaponUpgradeFrame;
    GameObject _WeaponUpgradeConfirmFrame;

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
    Button _WeaponUpgradeFrameOnButton;
    Button _WeaponUpgradeFrameOffButton;
    Button _WeaponUpgradeConfirmFrameOnButton;
    Button _WeaponUpgradeConfirmFrameOffButton;
    Button _WeaponUpgradeConfirmButton;

    Text _moneyText;
    Text _waveText;
    Text _placedSoldierText;
    Text[] _soldierUpgradeInformationsText;
    Text _soldierUpgradePriceText;
    Text _soldierUnLockPriceText;
    Text[] _WeaponUpgradeInformationsText;
    Text _WeaponUpgradePriceText;
    Text[] _WeaponUpgradeResourcesText;
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
    public GameObject WeaponUpgradeFrame { get { return _WeaponUpgradeFrame; } }
    public GameObject WeaponUpgradeConfirmFrame { get { return _WeaponUpgradeConfirmFrame; } }

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
    public Button WeaponUpgradeFrameOnButton { get { return _WeaponUpgradeFrameOnButton; } }
    public Button WeaponUpgradeFrameOffButton { get { return _WeaponUpgradeFrameOffButton; } }
    public Button WeaponUpgradeConfirmFrameOnButton { get { return _WeaponUpgradeConfirmFrameOnButton; } }
    public Button WeaponUpgradeConfirmFrameOffButton { get { return _WeaponUpgradeConfirmFrameOffButton; } }
    public Button WeaponUpgradeConfirmButton { get { return _WeaponUpgradeConfirmButton; } }

    public Text moneyText { get { return _moneyText; } }
    public Text waveText { get { return _waveText; } }
    public Text placedSoldierText { get { return _placedSoldierText; } }
    public Text[] soldierUpgradeInformationsText { get { return _soldierUpgradeInformationsText; } }
    public Text soldierUpgradePriceText { get { return _soldierUpgradePriceText; } }
    public Text soldierUnLockPriceText { get { return _soldierUnLockPriceText; } }
    public Text[] WeaponUpgradeInformationsText { get { return _WeaponUpgradeInformationsText; } }
    public Text WeaponUpgradePriceText { get { return _WeaponUpgradePriceText; } }
    public Text[] WeaponUpgradeResourcesText { get { return _WeaponUpgradeResourcesText; } }
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

        _resourcesText = new Text[(int)DataManager._EResource_.erMax];
        _mineralsHiredCntText = new Text[(int)DataManager._EMineral_.emMax];
        _mineralsLeftTimeText = new Text[(int)DataManager._EMineral_.emMax];
        _mineralsHirePriceText = new Text[(int)DataManager._EMineral_.emMax];
        _soldierUpgradeInformationsText = new Text[(int)DataManager._EUpgradeInfo_.euiMax];
        _WeaponUpgradeInformationsText = new Text[(int)DataManager._EUpgradeInfo_.euiMax];
        _WeaponUpgradeResourcesText = new Text[(int)DataManager._EWeaponResource_.ebrMax];
    }

    public void SceneLoadedObjects() // ������ ���� �ε�� ������ �ʿ��� ������Ʈ���� �����Ѵ�
    {
        AllSceneObjectsRef(); // ��� ������ ����ϴ� ������Ʈ���� �� ������ ���� => �������� ������Ʈ���� �̸��� ������ �� �̸��� ����ֵ���

        switch (gameManager.currentSceneState) // Ư���� �������� ����ϴ� ������Ʈ���� �ش� ���� ���� ���� ���� ����
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

    // ~~~ObjectRef : ~~~�� ������Ʈ�� ����

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
        _WeaponUpgradeFrame = _prepareFrame.transform.Find("WeaponUpgradeFrame").gameObject;
        _WeaponUpgradeConfirmFrame = _WeaponUpgradeFrame.transform.Find("WeaponUpgradeConfirmFrame").gameObject;

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
        _WeaponUpgradeFrameOnButton = GameObject.Find("WeaponUpgradeFrameOn_Button").GetComponent<Button>();
        _WeaponUpgradeFrameOffButton = _WeaponUpgradeFrame.transform.Find("WeaponUpgradeFrameOff_Button").GetComponent<Button>();
        _WeaponUpgradeConfirmFrameOnButton = _WeaponUpgradeFrame.transform.Find("BallistaUpgradeConfirmFrameOn_Button").GetComponent<Button>();
        _WeaponUpgradeConfirmFrameOffButton = _WeaponUpgradeConfirmFrame.transform.Find("WeaponUpgradeConfirmFrameOff_Button").GetComponent<Button>();
        _WeaponUpgradeConfirmButton = _WeaponUpgradeConfirmFrame.transform.Find("WeaponUpgradeConfirm_Button").GetComponent<Button>();

        _moneyText = GameObject.Find("Money_Text").GetComponent<Text>();
        _waveText = GameObject.Find("Wave_Text").GetComponent<Text>();
        _placedSoldierText = GameObject.Find("PlacedSoldier_Text").GetComponent<Text>();
        _soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade] = _soldierUpgradeConfirmFrame.transform.Find("CurrentSoldierUpgrade_Text").GetComponent<Text>();
        _soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat] = _soldierUpgradeConfirmFrame.transform.Find("AdditionalStat_Text").GetComponent<Text>();
        _soldierUpgradePriceText = _soldierUpgradeConfirmButton.gameObject.transform.Find("SoldierUpgradePrice_Text").GetComponent<Text>();
        _soldierUnLockPriceText = _soldierUnLockConfirmButton.gameObject.transform.Find("UnLockPrice_Text").GetComponent<Text>();
        _WeaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade] = _WeaponUpgradeConfirmFrame.transform.Find("CurrentWeaponUpgrade_Text").GetComponent<Text>();
        _WeaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat] = _WeaponUpgradeConfirmFrame.transform.Find("AdditionalStat_Text").GetComponent<Text>();
        _WeaponUpgradePriceText = _WeaponUpgradeConfirmButton.gameObject.transform.Find("WeaponUpgradePrice_Text").GetComponent<Text>();
        _WeaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrWood] = _WeaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Wood_Image").transform.Find("Wood_Text").GetComponent<Text>();
        _WeaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrStone] = _WeaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Stone_Image").transform.Find("Stone_Text").GetComponent<Text>();
        _WeaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrIron] = _WeaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Iron_Image").transform.Find("Iron_Text").GetComponent<Text>();
        _WeaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrGold] = _WeaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Gold_Image").transform.Find("Gold_Text").GetComponent<Text>();
        _WeaponUpgradeResourcesText[(int)DataManager._EWeaponResource_.ebrDiamond] = _WeaponUpgradeConfirmFrame.transform.Find("NeedResourceFrame").transform.Find("Diamond_Image").transform.Find("Diamond_Text").GetComponent<Text>();
    }
    //-------------------------------------------- private

    #endregion
}
