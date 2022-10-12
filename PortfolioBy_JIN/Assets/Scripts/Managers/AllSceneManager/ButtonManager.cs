using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    #region //enumeration//
    public enum _EOptionButton_
    {
        eobToInCastle,
        eobRePrepare,
        eobContinue,
        eobMax
    }
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    bool _isSoldierUpgraded;
    bool _isBallistaUpgraded;
    bool _isCastleUpgraded;
    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //struct//
    struct _summonInfo
    {
        public GameObject soldierObj;
        public Vector3 soldierPos;
    }
    _summonInfo soldier;

    struct _deployInfo
    {
        public GameObject weaponObj;
        public Vector3 weaponPos;
    }
    _deployInfo weapon;

    struct _skillInfo
    {
        public GameObject skillObj;
        public Vector3 skillPos;
    }
    _skillInfo skill;
    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #region ///AllScene///

    #endregion

    #region ///MainScene///

    #endregion

    #region ///InCastleScene///

    #endregion

    #region ///OutCastleScene///

    #endregion

    ObjectManager objectManager;

    GameManager gameManager;

    FirebaseDBManager firebaseDBManager;

    DataManager dataManager;

    PlayerPrefsManager playerPrefsManager;

    TimeManager timeManager;

    UIManager uiManager;

    ResourceManager resourceManager;

    PrepareManager prepareManager;

    SoundManager soundManager;

    CharacterFactory<SoldierFactory._ESoldierClass_> soldierFactory;

    WeaponFactory weaponFactory;

    SkillFactory skillFactroy;
    #endregion

    #region //property//
    public bool isSoldierUpgraded { get { return _isSoldierUpgraded; } set { _isSoldierUpgraded = value; } }
    public bool isBallistaUpgraded { get { return _isBallistaUpgraded; } set { _isBallistaUpgraded = value; } }
    public bool isCastleUpgraded { get { return _isCastleUpgraded; } set { _isCastleUpgraded = value; } }
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        playerPrefsManager = PlayerPrefsManager.instance;
        dataManager = DataManager.instance;
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;
        firebaseDBManager = FirebaseDBManager.instance;
        timeManager = TimeManager.instance;
        uiManager = UIManager.instance;
        resourceManager = ResourceManager.instance;
        prepareManager = PrepareManager.instance;
        soundManager = SoundManager.instance;
    }

    private void Start()
    {
        DataInit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // escŰ�� ������ ������ �� �ִ� UI�� ��
        {
            timeManager.GamePause(uiManager.QuitFrameOnOff());
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        soldierFactory = gameObject.AddComponent<SoldierFactory>();
        weaponFactory = gameObject.AddComponent<BallistaFactory>();
        skillFactroy = gameObject.AddComponent<MeteorFactory>();

        _isSoldierUpgraded = false;
        _isBallistaUpgraded = false;
        _isCastleUpgraded = false;
    }

    public void ButtonSound() // ��ư Ŭ����
    {
        soundManager.SetAudioSFX("Audios/SFX/Button");
        soundManager.PlayAudioSFX();
    }

    #region ///AllScene///
    public void Aplication_Quit() // ���� ���� ��ư
    {
        gameManager.QuitGame();
    }
    #endregion

    #region ///MainScene///
    public void MainStart() // ���� ��ŸƮ(Main)(�̹� �÷����� ���� �ִٸ� �ٷ� ����)(�ƴ϶�� ���� ����� â ��)
    {
        if (playerPrefsManager.CheckFirstPlay())
            uiManager.CreateUserFrameOn();
        else
            firebaseDBManager.ReadData(playerPrefsManager.GetPlayerPrefsName());
    }

    public void ConfirmName() // �г��� Ȯ�� ��ư
    {
        firebaseDBManager.CheckUserName(objectManager.userNameInputText.text);
    }

    public void SceneChange(string _scene) // _scene���� �̵�
    {
        SceneManager.LoadScene(_scene);
    }

    public void CreateUserData(bool _result) // �г����� �ߺ��� �ƴ϶�� ���� ������ ���� ���� ����
    {
        if (_result)
            return;

        firebaseDBManager.WriteCreateData(dataManager.UserDataInit(objectManager.userNameInputText.text));
        playerPrefsManager.SetPlayerPrefsName(dataManager.myUserInfo.m_sUserName);
        playerPrefsManager.SetPlayerPrefsPlayed(1);
        SceneChange("InCastle");
    }

    public void CompletedRead() // ������ �ҷ����� �Ϸ�
    {
        timeManager.IdleTimeCalculation();
        timeManager.IdleTimeForLeftTime();
        SceneChange("InCastle");
    }
    #endregion

    #region ///OutCastleScene///
    public void ForestFrameOnOffButton() // �� �ڿ� ���� ȭ�� On, Off
    {
        uiManager.ForestFrameOnOff();
    }

    public void MineFrameOnOffButton() // ���� �ڿ� ���� ȭ�� On, Off
    {
        uiManager.MineFrameOnOff();
    }

    public void TreeWorkFrameOnButton() // ���� ��ũ ������ On
    {
        uiManager.TreeWorkFrameOn();
    }

    public void TreeWorkFrameOffButton() // ���� ��ũ ������ Off
    {
        uiManager.TreeWorkFrameOff();
    }

    public void TreeHire() // ���� �η� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood]
            && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood];
            uiManager.SetTextHireCnt();
        }
    }

    public void MineralWorkFrameOnOffButton() // ���� ��ũ ������ On
    {
        uiManager.MineralWorkFrameOnOff(true);
        uiManager.SetTextHireCnt();
        uiManager.SetTextHirePrice();
    }

    public void SwitchToNextMineralButton() // ���� ������ ����
    {
        switch (dataManager.currentMineralState)
        {
            case DataManager._EMineral_.emStone:
                dataManager.SetMineralState(DataManager._EMineral_.emIron);
                break;
            case DataManager._EMineral_.emIron:
                dataManager.SetMineralState(DataManager._EMineral_.emGold);
                break;
            case DataManager._EMineral_.emGold:
                dataManager.SetMineralState(DataManager._EMineral_.emDiamond);
                break;
            case DataManager._EMineral_.emDiamond:
                dataManager.SetMineralState(DataManager._EMineral_.emStone);
                break;
            default:
                dataManager.SetMineralState(DataManager._EMineral_.emStone);
                break;
        }

        uiManager.MineralImageChange();
        uiManager.SetTextHireCnt();
        uiManager.SetTextHirePrice();
        uiManager.MineralWorkFrameOnOff(false);
    }

    public void MineralHireButton() // ���� �η� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)dataManager.currentMineralState + 1]
            && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)dataManager.currentMineralState + 1])
        {
            dataManager.myUserInfo.m_nHired[(int)dataManager.currentMineralState + 1]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)dataManager.currentMineralState + 1];
            uiManager.SetTextHireCnt();
        }
    }
    #endregion

    #region ///DefenceScene///
    public void DefenceToInCastle() // Defence������ InCastle������
    {
        gameManager.SetBattleState(GameManager._EBattleState_.egNotBattle);
        timeManager.SetGameSpeed(TimeManager._EGameSpeed_.egsNoraml);
        if (SkillManager.instance.coroutineManager != null)
            StopCoroutine(SkillManager.instance.coroutineManager);
        if (EnemyManager.instance.coroutineManager != null)
            StopCoroutine(EnemyManager.instance.coroutineManager);
        EnemyManager.instance.ResetEnemyManager();
        SceneChange("InCastle");
    }

    public void OptionFrameOnOffButton() // �ɼ� â On, Off
    {
        timeManager.GamePause(uiManager.OptionFrameOnOff());
    }

    public void RePrepare() // Prepare�� ���ư�
    {
        gameManager.SetBattleState(GameManager._EBattleState_.egNotBattle);
        timeManager.SetGameSpeed(TimeManager._EGameSpeed_.egsNoraml);
        if (SkillManager.instance.coroutineManager != null)
            StopCoroutine(SkillManager.instance.coroutineManager);
        if (EnemyManager.instance.coroutineManager != null)
            StopCoroutine(EnemyManager.instance.coroutineManager);
        EnemyManager.instance.ResetEnemyManager();
        SceneChange("Defence");
    }

    public void SoldierUpgradeFrameOnOffButton() // ���� ��ȭ ������ On, Off
    {
        uiManager.SoldierUpgradeFrameOnOff();
    }

    public void SoldierUpgradeAndUnLcokConfirmFrameOnOffButton() // ���� ��ȭ Ȯ�� or ��� ������ �� ����
    {
        uiManager.SoldierUpgradeAndUnLcokConfirmFrameOnOff();
    }

    public void SwitchToNextSoldierUpgradeButton() // ���׷��̵� �� ���� ���� ����
    {
        switch (dataManager.currentSoldierUpgradeState)
        {
            case DataManager._ESoldierUpgrade_.esuNormalSoldier:
                dataManager.SetSoldierUpgradeState(DataManager._ESoldierUpgrade_.esuRareSoldier);
                break;
            case DataManager._ESoldierUpgrade_.esuRareSoldier:
                dataManager.SetSoldierUpgradeState(DataManager._ESoldierUpgrade_.esuTankSoldier);
                break;
            case DataManager._ESoldierUpgrade_.esuTankSoldier:
                dataManager.SetSoldierUpgradeState(DataManager._ESoldierUpgrade_.esuUniversalSoldier);
                break;
            case DataManager._ESoldierUpgrade_.esuUniversalSoldier:
                dataManager.SetSoldierUpgradeState(DataManager._ESoldierUpgrade_.esuAssassinSoldier);
                break;
            case DataManager._ESoldierUpgrade_.esuAssassinSoldier:
                dataManager.SetSoldierUpgradeState(DataManager._ESoldierUpgrade_.esuUnknownSoldier);
                break;
            case DataManager._ESoldierUpgrade_.esuUnknownSoldier:
                dataManager.SetSoldierUpgradeState(DataManager._ESoldierUpgrade_.esuNormalSoldier);
                break;
            default:
                dataManager.SetSoldierUpgradeState(DataManager._ESoldierUpgrade_.esuNormalSoldier);
                break;
        }

        uiManager.SoldierImageChange();
        uiManager.SetTextSoldierUpgrade();
        uiManager.SetTextSoldierUnLock();
        uiManager.SoldierUpgradeAndUnLcokConfirmFrameOff();
    }

    public void SoldierUpgradeButton() // ���� ��ȭ
    {
        int shot = dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1);

        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, shot]
            && DataManager.MaxSoldierUpgrade > dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState])
        {
            dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState]++;
            dataManager.myUserInfo.m_nSoldierUpgrade[(int)DataManager._EResource_.erMoney] -= DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, shot];
            uiManager.SetTextSoldierUpgrade();
            _isSoldierUpgraded = true;
        }
    }

    public void SoldierUnLockFrameOffButton() // ���� ��� ������ ����
    {
        uiManager.SoldierUnLockFrameOff();
    }

    public void SoldierUnLcokButton() // ���� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.SoldierUnLockPrice[(int)dataManager.currentSoldierUpgradeState])
        {
            dataManager.myUserInfo.m_bSoldierLock[(int)dataManager.currentSoldierUpgradeState] = true;
            uiManager.SoldierUnLockFrameOff();
        }
    }

    public void WeaponUpgradeFrameOnOff() // ���� ��ȭ ������ On, Off
    {
        if (objectManager.weaponUpgradeFrame.activeSelf)
            objectManager.weaponUpgradeFrame.SetActive(false);
        else
            objectManager.weaponUpgradeFrame.SetActive(true);
    }

    public void SwitchToNextWeaponUpgrade() // ���� ����
    {
        switch (dataManager.currentWeaponUpgradeState)
        {
            case DataManager._EWeaponUpgrade_.ewuBallista:
                dataManager.SetWeaponUpgradeState(DataManager._EWeaponUpgrade_.ewuBallista);
                break;
            default:
                dataManager.SetWeaponUpgradeState(DataManager._EWeaponUpgrade_.ewuBallista);
                break;
        }

        uiManager.WeaponImageChange();
        uiManager.SetTextWeaponUpgrade();
        uiManager.WeaponUpgradeConfirmFrameOff();
    }

    public void WeaponUpgradeConfirmFrameOnOff() // ���� ���׷��̵� Ȯ�� ������ �¿���
    {
        uiManager.WeaponUpgradeConfirmFrameOnOff();
    }

    public void WeaponUpgrade() // ���� ���׷��̵�
    {
        int shot = dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState] / (DataManager.MaxBallistaUpgrade - 1);

        if (DataManager.MaxBallistaUpgrade > dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState]
            && dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.BallistaUpgradePrice[shot])
        {
            for (int j = 0; j < (int)DataManager._EWeaponResource_.ebrMax; j++)
            {
                if (dataManager.myUserInfo.m_nResource[j + 1] >= DataManager.BallistaUpgradeResource[j, shot])
                    continue;
                else
                    return;
            }

            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.BallistaUpgradePrice[shot];

            for (int j = 0; j < (int)DataManager._EWeaponResource_.ebrMax; j++)
                dataManager.myUserInfo.m_nResource[j + 1] -= DataManager.BallistaUpgradeResource[j, shot];

            uiManager.SetTextWeaponUpgrade();
            dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState]++;
        }
    }

    public void DefenceStart() // ���潺 ���̺� ����
    {
        soundManager.SetAudioSFX("Audios/SFX/DefenceStart");
        gameManager.SetBattleState(GameManager._EBattleState_.egBattle);
        uiManager.DefenceStartFrameSet();
        EnemyManager.instance.EnemyActivateCoroutineStart();
    }

    public void CastleUpgradeFrameOnOffButton() // �� ���׷��̵� ������ On, Off
    {
        uiManager.CastleUpgradeFrameOnOff();
    }

    public void CastleUpgradeButton() // �� ���׷��̵�
    {
        int shot = dataManager.myUserInfo.m_nCastleUpgrade / DataManager.CastleUpgradePriceCnt;

        if (DataManager.MaxCastleUpgrade > dataManager.myUserInfo.m_nCastleUpgrade
            && dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.CastleUpgradePrice[shot])
        {
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.CastleUpgradePrice[shot];
            dataManager.myUserInfo.m_nCastleUpgrade++;

            uiManager.SetTextCastleUpgrade();
        }
    }

    public void SoldierSummonSelectFrameOnOffButton() // ���� ��ȯ ���� ������ On,Off
    {
        if(uiManager.SoldierSummonSelectFrameOnOff())
        {
            soldier.soldierPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            soldier.soldierPos -= new Vector3(0, 0, Camera.main.transform.position.z);
        }
    }

    public void SoldierSummonButton(SoldierFactory._ESoldierClass_ select) // ���� ��ȯ
    {
        if (dataManager.myUserInfo.m_bSoldierLock[(int)select] && prepareManager.summonedSoldierMax > prepareManager.currentSummonedSoldier)
        {
            soldier.soldierObj = soldierFactory.Create(select);
            soldier.soldierObj.transform.position = soldier.soldierPos;
            prepareManager.currentSummonedSoldier++;
            uiManager.SetTextSoldierAndWeaponCnt();
        }
    }

    public void WeaponDeploySelectFrameOnOffButton() // ���� ��ġ ���� ������ On,Off
    {
        if (uiManager.WeaponDeploySelectFrameOnOff())
        { 
            weapon.weaponPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            weapon.weaponPos -= new Vector3(0, 0, Camera.main.transform.position.z);
        }
    }

    public void WeaponDeploy(WeaponFactory._EWeaponClass_ select) // ���� ��ġ
    {
        if (dataManager.myUserInfo.m_bWeaponLock[(int)select] && prepareManager.deployedWeaponMax > prepareManager.currentDeployedWeapon)
        {
            weapon.weaponObj = weaponFactory.Create(select);
            weapon.weaponObj.transform.position = weapon.weaponPos;
            prepareManager.currentDeployedWeapon++;
            uiManager.SetTextSoldierAndWeaponCnt();
        }
    }

    public void MeteorSkill() // ���׿� ��ų ���
    {
        if (objectManager.useMeteorButtonImage.fillAmount == 0)
        {
            soundManager.SetAudioSFX("Audios/SFX/Meteor");
            objectManager.useMeteorButtonImage.fillAmount = 1f;
            SkillManager.instance.SkillActivateCoroutineStart(SkillManager._ESkillClass_.escMeteor);
        }
    }

    public void BackToPreviousRound() // ���� ����� �̵�
    {
        if (dataManager.myUserInfo.m_nWave > 1 && !prepareManager.isPreviousRound)
        {
            prepareManager.PreviousRoundSet();
            SceneManager.LoadScene("Defence");
        }
    }

    public void BattleSpeedChange() // ���� �ӵ� ����
    {
        switch (timeManager.currentGameSpeed)
        {
            case TimeManager._EGameSpeed_.egsNoraml:
                timeManager.SetGameSpeed(TimeManager._EGameSpeed_.egsDouble);
                uiManager.SetImageGameSpeed("Image/Arrow_Double");
                break;
            case TimeManager._EGameSpeed_.egsDouble:
                timeManager.SetGameSpeed(TimeManager._EGameSpeed_.egsTriple);
                uiManager.SetImageGameSpeed("Image/Arrow_Triple");
                break;
            case TimeManager._EGameSpeed_.egsTriple:
                timeManager.SetGameSpeed(TimeManager._EGameSpeed_.egsNoraml);
                uiManager.SetImageGameSpeed("Image/Arrow_Normal");
                break;
            default:
                timeManager.SetGameSpeed(TimeManager._EGameSpeed_.egsNoraml);
                uiManager.SetImageGameSpeed("Image/Arrow_Normal");
                break;
        }
    }

    #endregion

    public void SceneLoadedButtons() // ���� �ε�� ������ ��ư�� �̺�Ʈ �Ҵ�
    {
        AllSceneButtonsEvent();

        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                MainButtonsEvent();
                break;
            case GameManager._ESceneState_.esInCastle:
                InCastleButtonsEvent();
                break;
            case GameManager._ESceneState_.esOutCastle:
                OutCastleButtonsEvent();
                break;
            case GameManager._ESceneState_.esDefence:
                DefenceButtonsEvent();
                break;
            default:
                break;
        }
    }

    // ~~~ButtonsEvent : ~~~�� ��ư�� �̺�Ʈ �Ҵ�

    public void AllSceneButtonsEvent()
    {
        objectManager.quitButton.onClick.AddListener(Aplication_Quit);
        objectManager.quitButton.onClick.AddListener(ButtonSound);
    }

    public void MainButtonsEvent()
    {
        objectManager.mainToInCastleButton.onClick.AddListener(MainStart);
        objectManager.mainToInCastleButton.onClick.AddListener(ButtonSound);
        objectManager.createUserButton.onClick.AddListener(ConfirmName);
        objectManager.createUserButton.onClick.AddListener(ButtonSound);
    }

    public void InCastleButtonsEvent()
    {
        objectManager.inCastleToDefenceButton.onClick.AddListener(() => SceneChange("Defence"));
        objectManager.inCastleToDefenceButton.onClick.AddListener(ButtonSound);
        objectManager.inCastleToOutCastleButton.onClick.AddListener(() => SceneChange("OutCastle"));
        objectManager.inCastleToOutCastleButton.onClick.AddListener(ButtonSound);
    }

    public void OutCastleButtonsEvent()
    {
        objectManager.outCastleToInCastleButton.onClick.AddListener(() => SceneChange("InCastle"));
        objectManager.outCastleToInCastleButton.onClick.AddListener(ButtonSound);
        objectManager.forestFrameOnButton.onClick.AddListener(ForestFrameOnOffButton);
        objectManager.forestFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.mineFrameOnButton.onClick.AddListener(MineFrameOnOffButton);
        objectManager.mineFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.forestFrameOffButton.onClick.AddListener(ForestFrameOnOffButton);
        objectManager.forestFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.mineFrameOffButton.onClick.AddListener(MineFrameOnOffButton);
        objectManager.mineFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.treeWorkFrameOnButton.onClick.AddListener(TreeWorkFrameOnButton);
        objectManager.treeWorkFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.treeHireButton.onClick.AddListener(TreeHire);
        objectManager.treeHireButton.onClick.AddListener(ButtonSound);
        objectManager.mineralWorkFrameOnButton.onClick.AddListener(MineralWorkFrameOnOffButton);
        objectManager.mineralWorkFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.nextMineralButton.onClick.AddListener(SwitchToNextMineralButton);
        objectManager.nextMineralButton.onClick.AddListener(ButtonSound);
        objectManager.mineralHireButton.onClick.AddListener(MineralHireButton);
        objectManager.mineralHireButton.onClick.AddListener(ButtonSound);
    }

    public void DefenceButtonsEvent()
    {
        objectManager.defenceToInCastleButton.onClick.AddListener(DefenceToInCastle);
        objectManager.defenceToInCastleButton.onClick.AddListener(ButtonSound);
        objectManager.optionFrameOnButton.onClick.AddListener(OptionFrameOnOffButton);
        objectManager.optionFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.optionsButton[(int)_EOptionButton_.eobToInCastle].onClick.AddListener(DefenceToInCastle);
        objectManager.optionsButton[(int)_EOptionButton_.eobToInCastle].onClick.AddListener(ButtonSound);
        objectManager.optionsButton[(int)_EOptionButton_.eobRePrepare].onClick.AddListener(RePrepare);
        objectManager.optionsButton[(int)_EOptionButton_.eobRePrepare].onClick.AddListener(ButtonSound);
        objectManager.optionsButton[(int)_EOptionButton_.eobContinue].onClick.AddListener(OptionFrameOnOffButton);
        objectManager.optionsButton[(int)_EOptionButton_.eobContinue].onClick.AddListener(ButtonSound);
        objectManager.soldierUpgradeFrameOnButton.onClick.AddListener(SoldierUpgradeFrameOnOffButton);
        objectManager.soldierUpgradeFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.soldierUpgradeFrameOffButton.onClick.AddListener(SoldierUpgradeFrameOnOffButton);
        objectManager.soldierUpgradeFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.soldierUpgradeConfirmFrameOnButton.onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOffButton);
        objectManager.soldierUpgradeConfirmFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.soldierUpgradeConfirmFrameOffButton.onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOffButton);
        objectManager.soldierUpgradeConfirmFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.soldierUpgradeConfirmButton.onClick.AddListener(SoldierUpgradeButton);
        objectManager.soldierUpgradeConfirmButton.onClick.AddListener(ButtonSound);
        objectManager.nextSoldierButton.onClick.AddListener(SwitchToNextSoldierUpgradeButton);
        objectManager.nextSoldierButton.onClick.AddListener(ButtonSound);
        objectManager.soldierUnLockOffButton.onClick.AddListener(SoldierUnLockFrameOffButton);
        objectManager.soldierUnLockOffButton.onClick.AddListener(ButtonSound);
        objectManager.weaponUpgradeFrameOnButton.onClick.AddListener(WeaponUpgradeFrameOnOff);
        objectManager.weaponUpgradeFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.weaponUpgradeFrameOffButton.onClick.AddListener(WeaponUpgradeFrameOnOff);
        objectManager.weaponUpgradeFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.weaponUpgradeConfirmFrameOnButton.onClick.AddListener(WeaponUpgradeConfirmFrameOnOff);
        objectManager.weaponUpgradeConfirmFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.weaponUpgradeConfirmFrameOffButton.onClick.AddListener(WeaponUpgradeConfirmFrameOnOff);
        objectManager.weaponUpgradeConfirmFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.weaponUpgradeConfirmButton.onClick.AddListener(WeaponUpgrade);
        objectManager.weaponUpgradeConfirmButton.onClick.AddListener(ButtonSound);
        objectManager.nextWeaponButton.onClick.AddListener(SwitchToNextWeaponUpgrade);
        objectManager.nextWeaponButton.onClick.AddListener(ButtonSound);
        objectManager.defenceStartButton.onClick.AddListener(DefenceStart);
        objectManager.defenceStartButton.onClick.AddListener(ButtonSound);
        objectManager.castleUpgradeFrameOnButton.onClick.AddListener(CastleUpgradeFrameOnOffButton);
        objectManager.castleUpgradeFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.castleUpgradeFrameOffButton.onClick.AddListener(CastleUpgradeFrameOnOffButton);
        objectManager.castleUpgradeFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.castleUpgradeConfirmButton.onClick.AddListener(CastleUpgradeButton);
        objectManager.castleUpgradeConfirmButton.onClick.AddListener(ButtonSound);
        objectManager.soldierSummonSelectFrameOnButton.onClick.AddListener(SoldierSummonSelectFrameOnOffButton);
        objectManager.soldierSummonSelectFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.soldierSummonSelectFrameOffButton.onClick.AddListener(SoldierSummonSelectFrameOnOffButton);
        objectManager.soldierSummonSelectFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslNoramlSoldier].onClick.AddListener(() => SoldierSummonButton(SoldierFactory._ESoldierClass_.escNormal));
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslNoramlSoldier].onClick.AddListener(ButtonSound);
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslRareSoldier].onClick.AddListener(() => SoldierSummonButton(SoldierFactory._ESoldierClass_.escRare));
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslRareSoldier].onClick.AddListener(ButtonSound);
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslTankSoldier].onClick.AddListener(() => SoldierSummonButton(SoldierFactory._ESoldierClass_.escTank));
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslTankSoldier].onClick.AddListener(ButtonSound);
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslUniversalSoldier].onClick.AddListener(() => SoldierSummonButton(SoldierFactory._ESoldierClass_.escUniversal));
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslUniversalSoldier].onClick.AddListener(ButtonSound);
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslAssassinSoldier].onClick.AddListener(() => SoldierSummonButton(SoldierFactory._ESoldierClass_.escAssassin));
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslAssassinSoldier].onClick.AddListener(ButtonSound);
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslUnknownSoldier].onClick.AddListener(() => SoldierSummonButton(SoldierFactory._ESoldierClass_.escUnknown));
        objectManager.soldierSummonsButton[(int)DataManager._ESoldierLock_.eslUnknownSoldier].onClick.AddListener(ButtonSound);
        objectManager.weaponDeploySelectFrameOnButton.onClick.AddListener(WeaponDeploySelectFrameOnOffButton);
        objectManager.weaponDeploySelectFrameOnButton.onClick.AddListener(ButtonSound);
        objectManager.weaponDeploySelectFrameOffButton.onClick.AddListener(WeaponDeploySelectFrameOnOffButton);
        objectManager.weaponDeploySelectFrameOffButton.onClick.AddListener(ButtonSound);
        objectManager.weaponDeploysButton[(int)DataManager._EWeaponLock_.ewlBallista].onClick.AddListener(() => WeaponDeploy(WeaponFactory._EWeaponClass_.ewcBallista));
        objectManager.weaponDeploysButton[(int)DataManager._EWeaponLock_.ewlBallista].onClick.AddListener(ButtonSound);
        objectManager.previousRoundButton.onClick.AddListener(BackToPreviousRound);
        objectManager.previousRoundButton.onClick.AddListener(ButtonSound);
        objectManager.useMeteorButton.onClick.AddListener(MeteorSkill);
        objectManager.useMeteorButton.onClick.AddListener(ButtonSound);
        objectManager.battleSpeedControlButton.onClick.AddListener(BattleSpeedChange);
        objectManager.battleSpeedControlButton.onClick.AddListener(ButtonSound);
        objectManager.endDefenceBackInCastleButton.onClick.AddListener(DefenceToInCastle);
        objectManager.endDefenceBackInCastleButton.onClick.AddListener(ButtonSound);
        objectManager.endDefenceRePrepareButton.onClick.AddListener(RePrepare);
        objectManager.endDefenceRePrepareButton.onClick.AddListener(ButtonSound);
    }
    // -------------------------------------------- private

    #endregion
}
