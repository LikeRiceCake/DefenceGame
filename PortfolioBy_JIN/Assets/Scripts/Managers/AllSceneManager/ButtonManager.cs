using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    #region //enumeration//
    IEnumerator _coroutineManager;
    #endregion

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
    #endregion

    #region //property//
    public IEnumerator coroutineManager { get { return _coroutineManager; } }

    public bool isSoldierUpgraded { get { return _isSoldierUpgraded; } set { _isSoldierUpgraded = value; } }
    public bool isBallistaUpgraded { get { return _isBallistaUpgraded; } set { _isBallistaUpgraded = value; } }
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
    }

    private void Start()
    {
        DataInit();
    }

    void Update()
    {
        if (gameManager.isCompletedCheck) // 닉네임의 중복 체크가 완료되었고 문제가 없다면
        {
            CreateUserData();
        }

        if (gameManager.isCompletedRead) // 데이터 불러오기가 완료됐다면
        {
            gameManager.isCompletedRead = false;
            timeManager.IdleTimeCalculation();
            timeManager.IdleTimeForLeftTime();
            MainToInCastle();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        _isSoldierUpgraded = false;
        _isBallistaUpgraded = false;
    }

    #region ///AllScene///
    public void Aplication_Quit() // 게임 종료 버튼
    {
        Application.Quit();
    }
    #endregion

    #region ///MainScene///
    public void MainStart() // 게임 스타트(Main)(이미 플레이한 적이 있다면 바로 시작)(아니라면 유저 만들기 창 온)
    {
        if (gameManager.isAlreadyPlayed)
            firebaseDBManager.ReadData(playerPrefsManager.myName);
        else
            objectManager.createUserFrame.SetActive(true);
    }

    public void ConfirmName() // 닉네임 확인 버튼
    {
        firebaseDBManager.CheckUserName(objectManager.userNameInputText.text);
    }

    public void MainToInCastle() // InCastle씬으로(Main)
    {
        SceneManager.LoadScene("InCastle");
    }

    public void CreateUserData() // 닉네임이 중복이 아니라면 유저 데이터 생성 과정 실행
    {
        firebaseDBManager.WriteCreateData(dataManager.UserDataInit(objectManager.userNameInputText.text));
        gameManager.isCompletedCheck = false;
        playerPrefsManager.SetPlayerPrefsName(objectManager.userNameInputText.text);
        playerPrefsManager.SetPlayerPrefsPlayed(1);
        MainToInCastle();
    }
    #endregion

    #region ///InCastleScene///
    public void InCastleToDefence() // Defence씬으로(InCastle)
    {
        SceneManager.LoadScene("Defence");
    }

    public void InCastleToOutCastle() // Defence씬으로(InCastle)
    {
        SceneManager.LoadScene("OutCastle");
    }
    #endregion

    #region ///OutCastleScene///
    public void OutCastleToInCastle() // InCastle씬으로(OutCastle)
    {
        SceneManager.LoadScene("InCastle");
    }

    public void ForestFrameOnOff() // 숲 자원 수급 화면 On, Off
    {
        if (objectManager.forestFrame.activeSelf)
        {
            objectManager.forestFrame.SetActive(false);
        }
        else
        {
            objectManager.forestFrame.SetActive(true);
        }
    }

    public void MineFrameOnOff() // 광산 자원 수급 화면 On, Off
    {
        if (objectManager.mineFrame.activeSelf)
            objectManager.mineFrame.SetActive(false);
        else
            objectManager.mineFrame.SetActive(true);
    }

    public void TreeWorkFrameOn() // 나무 워크 프레임 On
    {
        objectManager.treeWorkFrame.SetActive(true);
    }

    public void TreeWorkFrameOff() // 나무 워크 프레임 Off
    {
        objectManager.treeWorkFrame.SetActive(false);
    }

    public void TreeHire() // 나무 인력 고용
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood])
        {                                                                                                                             
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;                                                      
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehWood);
        }
    }

    public void StoneButtonOn() // 돌 버튼 On
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emStone].gameObject.SetActive(true);
    }

    public void StoneButtonOff() // 돌 버튼 Off
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emStone].gameObject.SetActive(false);
    }

    public void IronButtonOn() // 철 버튼 On
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emIron].gameObject.SetActive(true);
    }

    public void IronButtonOff() // 철 버튼 Off
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emIron].gameObject.SetActive(false);
    }

    public void GoldButtonOn() // 금 버튼 On
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emGold].gameObject.SetActive(true);
    }

    public void GoldButtonOff() // 금 버튼 Off
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emGold].gameObject.SetActive(false);
    }

    public void DiamondButtonOn() // 다이아 버튼 On
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond].gameObject.SetActive(true);
    }

    public void DiamondButtonOff() // 다이아 버튼 Off
    {
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond].gameObject.SetActive(false);
    }

    public void StoneWorkFrameOn() // 돌 워크 프레임 On
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emStone].SetActive(true);
    }

    public void StoneWorkFrameOff() // 돌 워크 프레임 Off
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emStone].SetActive(false);
    }

    public void IronWorkFrameOn() // 철 워크 프레임 On
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emIron].SetActive(true);
    }

    public void IronWorkFrameOff() // 철 워크 프레임 Off
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emIron].SetActive(false);
    }

    public void GoldWorkFrameOn() // 금 워크 프레임 On
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emGold].SetActive(true);
    }

    public void GoldWorkFrameOff() // 금 워크 프레임 Off
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emGold].SetActive(false);
    }

    public void DiamondWorkFrameOn() // 다이아 워크 프레임 On
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emDiamond].SetActive(true);
    }

    public void DiamondWorkFrameOff() // 다이아 워크 프레임 Off
    {
        objectManager.mineralsWorkFrame[(int)DataManager._EMineral_.emDiamond].SetActive(false);
    }

    public void SwitchToNextMineral() // 다음 광물로 변경
    {
        switch (dataManager.currentMineralState)
        {
            case DataManager._EMineral_.emStone:
                SetMineralState(DataManager._EMineral_.emIron);
                break;
            case DataManager._EMineral_.emIron:
                SetMineralState(DataManager._EMineral_.emGold);
                break;
            case DataManager._EMineral_.emGold:
                SetMineralState(DataManager._EMineral_.emDiamond);
                break;
            case DataManager._EMineral_.emDiamond:
                SetMineralState(DataManager._EMineral_.emStone);
                break;
            default:
                SetMineralState(DataManager._EMineral_.emStone);
                break;
        }

        MineralObjectSelectedOnOff();
    }

    public void MineralObjectSelectedOnOff() // 현재 광물에 맞는 프레임 및 버튼 On, Off
    {
        for(int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            if((int)dataManager.currentMineralState == i)
            {
                objectManager.mineralsWorkFrameOnButton[i].gameObject.SetActive(true);
                objectManager.mineralsWorkFrame[i].SetActive(true);
                objectManager.mineralsLeftTimeText[i].gameObject.SetActive(true);
                continue;
            }
            objectManager.mineralsWorkFrameOnButton[i].gameObject.SetActive(false);
            objectManager.mineralsWorkFrame[i].SetActive(false);
            objectManager.mineralsLeftTimeText[i].gameObject.SetActive(false);
        }
    }

    public void SetMineralState(DataManager._EMineral_ newMineralState) // 현재 선택 광물 변경
    {
        dataManager.currentMineralState = newMineralState;
    }

    public void StoneHire() // 돌 인력 고용
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehStone] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehStone];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehStone);
        }
    }

    public void IronHire() // 철 인력 고용
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehIron] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehIron];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehIron);
        }
    }

    public void GoldHire() // 금 인력 고용
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehGold] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehGold])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehGold];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehGold);
        }
    }

    public void DiamondHire() // 다이아 인력 고용
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehDiamond] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehDiamond])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehDiamond]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehDiamond];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehDiamond);
        }
    }

    #endregion

    #region ///DefenceScene///
    public void DefenceToInCastle() // Defence씬에서 InCastle씬으로
    {
        gameManager.SetBattleState(GameManager._EBattleState_.egNotBattle);
        SceneManager.LoadScene("InCastle");
    }

    public void OptionFrameOnOff() // 옵션 창 On, Off
    {
        if(objectManager.optionFrame.activeSelf)
        {
            objectManager.optionFrame.SetActive(false);
            timeManager.TimeControl(TimeManager._ETimeFast_.etfNormal);
        }
        else
        {
            objectManager.optionFrame.SetActive(true);
            timeManager.TimeControl(TimeManager._ETimeFast_.etfStop);
        }
    }

    public void RePrepare() // Prepare로 돌아감
    {
        gameManager.SetBattleState(GameManager._EBattleState_.egNotBattle);
        objectManager.prepareFrame.SetActive(true);
        objectManager.battleFrame.SetActive(false);
        // EnemyManager를 리셋하는 코드
    }

    public void SoldierUpgradeFrameOnOff() // 병사 강화 프레임 On, Off
    {
        if (objectManager.soldierUpgradeFrame.activeSelf)
            objectManager.soldierUpgradeFrame.SetActive(false);
        else
            objectManager.soldierUpgradeFrame.SetActive(true);
    }

    public void SoldierUpgradeAndUnLcokConfirmFrameOnOff() // 병사 강화 확인 프레임 온 오프
    {
        if (objectManager.soldierUpgradeConfirmFrame.activeSelf)
        {
            if(dataManager.myUserInfo.m_nSoldierLock[(int)dataManager.currentSoldierUpgradeState])
                objectManager.soldierUpgradeConfirmFrame.SetActive(false);
            else
                objectManager.soldierUnLockFrame.SetActive(false);
        }
        else
        {
            if (dataManager.myUserInfo.m_nSoldierLock[(int)dataManager.currentSoldierUpgradeState])
                objectManager.soldierUpgradeConfirmFrame.SetActive(true);
            else
            {
                objectManager.soldierUnLockFrame.SetActive(true);
                uiManager.SetTextSoldierUnLock();
            }
        }
    }

    public void SwitchToNextSoldierUpgrade() // 업그레이드 할 다음 병사 선택
    {
        switch (dataManager.currentSoldierUpgradeState)
        {
            case DataManager._ESoldierUpgrade_.esuNormalSoldier:
                dataManager.currentSoldierUpgradeState = DataManager._ESoldierUpgrade_.esuRareSoldier;
                break;
            case DataManager._ESoldierUpgrade_.esuRareSoldier:
                dataManager.currentSoldierUpgradeState = DataManager._ESoldierUpgrade_.esuTankSoldier;
                break;
            case DataManager._ESoldierUpgrade_.esuTankSoldier:
                dataManager.currentSoldierUpgradeState = DataManager._ESoldierUpgrade_.esuUniversalSoldier;
                break;
            case DataManager._ESoldierUpgrade_.esuUniversalSoldier:
                dataManager.currentSoldierUpgradeState = DataManager._ESoldierUpgrade_.esuAssassinSoldier;
                break;
            case DataManager._ESoldierUpgrade_.esuAssassinSoldier:
                dataManager.currentSoldierUpgradeState = DataManager._ESoldierUpgrade_.esuUnknownSoldier;
                break;
            case DataManager._ESoldierUpgrade_.esuUnknownSoldier:
                dataManager.currentSoldierUpgradeState = DataManager._ESoldierUpgrade_.esuNormalSoldier;
                break;
            default:
                dataManager.currentSoldierUpgradeState = DataManager._ESoldierUpgrade_.esuNormalSoldier;
                break;
        }

        SoldierUpgradeObjectSelectedOnOff();
    }

    public void SoldierUpgradeObjectSelectedOnOff() // 병사 강화 오브젝트 선택 온오프
    {
        for(int i = 0; i < (int)DataManager._ESoldierUpgrade_.esuMax; i++)
        {
            if((int)dataManager.currentSoldierUpgradeState == i)
            {
                objectManager.soldierUpgradeConfirmFramesOnButton[i].gameObject.SetActive(true);
                continue;
            }

            objectManager.soldierUpgradeConfirmFramesOnButton[i].gameObject.SetActive(false);
            objectManager.soldierUpgradeConfirmFrame.SetActive(false);
            objectManager.soldierUnLockFrame.SetActive(false);
        }
        uiManager.SetTextSoldierUpgrade();
    }

    public void SoldierUpgrade() // 병사 강화
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >=
            DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)]
            && DataManager.MaxSoldierUpgrade > dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState])
        {
            dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState]++;
            dataManager.myUserInfo.m_nSoldierUpgrade[(int)DataManager._EResource_.erMoney] -=
                DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)];
            uiManager.SetTextSoldierUpgrade();
            _isSoldierUpgraded = true;
        }
    }

    public void SoldierUnLockFrameOff() // 병사 언락 프레임 온오프
    {
        if(objectManager.soldierUnLockFrame.activeSelf)
            objectManager.soldierUnLockFrame.SetActive(false);
    }

    public void SoldierUnLcok() // 병사 언락
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.SoldierUnLockPrice[(int)dataManager.currentSoldierUpgradeState])
        {
            dataManager.myUserInfo.m_nSoldierLock[(int)dataManager.currentSoldierUpgradeState] = true;
            SoldierUnLockFrameOff();
        }
    }

    public void BallistaUpgradeFrameOnOff() // 발리스타 강화 프레임 On, Off
    {
        if (objectManager.ballistaUpgradeFrame.activeSelf)
            objectManager.ballistaUpgradeFrame.SetActive(false);
        else
            objectManager.ballistaUpgradeFrame.SetActive(true);
    }

    public void BallistaUpgradeConfirmFrameOnOff() // 발리스타 업그레이드 확인 프레임 온오프
    {
        if (objectManager.ballistaUpgradeConfirmFrame.activeSelf)
            objectManager.ballistaUpgradeConfirmFrame.SetActive(false);
        else
        {
            objectManager.ballistaUpgradeConfirmFrame.SetActive(true);
            uiManager.SetTextBallistaUpgrade();
        }
    }

    public void BallistaUpgrade() // 발리스타 업그레이드
    {
        if(DataManager.MaxBallistaUpgrade > dataManager.myUserInfo.m_nBallistaUpgrade 
            && dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.BallistaUpgradePrice[dataManager.myUserInfo.m_nBallistaUpgrade / (DataManager.MaxBallistaUpgrade - 1)])
        {
            int i = dataManager.myUserInfo.m_nBallistaUpgrade / (DataManager.MaxBallistaUpgrade - 1);

            for(int j = 0; j < (int)DataManager._EBallistaResource_.ebrMax; j++)
            {
                if (dataManager.myUserInfo.m_nResource[j + 1] >= DataManager.BallistaUpgradeResource[j, i])
                    continue;
                else
                    return;
            }

            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.BallistaUpgradePrice[i];

            for (int j = 0; j < (int)DataManager._EBallistaResource_.ebrMax; j++)
                dataManager.myUserInfo.m_nResource[j + 1] -= DataManager.BallistaUpgradeResource[j, i];

            uiManager.SetTextBallistaUpgrade();
            
        }
    }
    #endregion

    public void SceneLoadedButtons() // 씬이 로드될 때마다 버튼들 이벤트 할당
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

    // ~~~ButtonsEvent : ~~~씬 버튼의 이벤트 할당

    public void AllSceneButtonsEvent()
    {
        objectManager.quitButton.onClick.AddListener(Aplication_Quit);
    }

    public void MainButtonsEvent()
    {
        objectManager.mainToInCastleButton.onClick.AddListener(MainStart);
        objectManager.createUserButton.onClick.AddListener(ConfirmName);
    }

    public void InCastleButtonsEvent()
    {
        objectManager.inCastleToDefenceButton.onClick.AddListener(InCastleToDefence);
        objectManager.inCastleToOutCastleButton.onClick.AddListener(InCastleToOutCastle);
    }

    public void OutCastleButtonsEvent()
    {
        objectManager.outCastleToInCastleButton.onClick.AddListener(OutCastleToInCastle);
        objectManager.forestFrameOnButton.onClick.AddListener(ForestFrameOnOff);
        objectManager.mineFrameOnButton.onClick.AddListener(MineFrameOnOff);
        objectManager.forestFrameOffButton.onClick.AddListener(ForestFrameOnOff);
        objectManager.mineFrameOffButton.onClick.AddListener(MineFrameOnOff);
        objectManager.treeWorkFrameOnButton.onClick.AddListener(TreeWorkFrameOn);
        objectManager.treeHireButton.onClick.AddListener(TreeHire);
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emStone].onClick.AddListener(StoneWorkFrameOn);
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emIron].onClick.AddListener(IronWorkFrameOn);
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emGold].onClick.AddListener(GoldWorkFrameOn);
        objectManager.mineralsWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond].onClick.AddListener(DiamondWorkFrameOn);
        objectManager.nextMineralButton.onClick.AddListener(SwitchToNextMineral);
        objectManager.mineralsHireButton[(int)DataManager._EMineral_.emStone].onClick.AddListener(StoneHire);
        objectManager.mineralsHireButton[(int)DataManager._EMineral_.emIron].onClick.AddListener(IronHire);
        objectManager.mineralsHireButton[(int)DataManager._EMineral_.emGold].onClick.AddListener(GoldHire);
        objectManager.mineralsHireButton[(int)DataManager._EMineral_.emDiamond].onClick.AddListener(DiamondHire);
    }

    public void DefenceButtonsEvent()
    {
        objectManager.defenceToInCastleButton.onClick.AddListener(DefenceToInCastle);
        objectManager.optionFrameOnButton.onClick.AddListener(OptionFrameOnOff);
        objectManager.optionsButton[(int)_EOptionButton_.eobToInCastle].onClick.AddListener(DefenceToInCastle);
        objectManager.optionsButton[(int)_EOptionButton_.eobRePrepare].onClick.AddListener(RePrepare);
        objectManager.optionsButton[(int)_EOptionButton_.eobContinue].onClick.AddListener(OptionFrameOnOff);
        objectManager.soldierUpgradeFrameOnButton.onClick.AddListener(SoldierUpgradeFrameOnOff);
        objectManager.soldierUpgradeFrameOffButton.onClick.AddListener(SoldierUpgradeFrameOnOff);
        objectManager.soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuNormalSoldier].onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuRareSoldier].onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuTankSoldier].onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuUniversalSoldier].onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuAssassinSoldier].onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFramesOnButton[(int)DataManager._ESoldierUpgrade_.esuUnknownSoldier].onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOffButton.onClick.AddListener(SoldierUpgradeAndUnLcokConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmButton.onClick.AddListener(SoldierUpgrade);
        objectManager.nextSoldierButton.onClick.AddListener(SwitchToNextSoldierUpgrade);
        objectManager.soldierUnLockOffButton.onClick.AddListener(SoldierUnLockFrameOff);
        objectManager.ballistaUpgradeFrameOnButton.onClick.AddListener(BallistaUpgradeFrameOnOff);
        objectManager.ballistaUpgradeFrameOffButton.onClick.AddListener(BallistaUpgradeFrameOnOff);
        objectManager.ballistaUpgradeConfirmFrameOnButton.onClick.AddListener(BallistaUpgradeConfirmFrameOnOff);
        objectManager.ballistaUpgradeConfirmFrameOffButton.onClick.AddListener(BallistaUpgradeConfirmFrameOnOff);
        objectManager.ballistaUpgradeConfirmButton.onClick.AddListener(BallistaUpgrade);
    }

    // -------------------------------------------- private

    #endregion
}
