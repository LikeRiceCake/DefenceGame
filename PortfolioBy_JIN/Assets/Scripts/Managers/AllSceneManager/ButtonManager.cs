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
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }

    void Update()
    {
        if (gameManager.isCompletedCheck) // �г����� �ߺ� üũ�� �Ϸ�Ǿ��� ������ ���ٸ�
        {
            CreateUserData();
        }

        if (gameManager.isCompletedRead) // ������ �ҷ����Ⱑ �Ϸ�ƴٸ�
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
        playerPrefsManager = PlayerPrefsManager.instance;
        dataManager = DataManager.instance;
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;
        firebaseDBManager = FirebaseDBManager.instance;
        timeManager = TimeManager.instance;
        uiManager = UIManager.instance;

        _isSoldierUpgraded = false;
    }

    #region ///AllScene///
    public void Aplication_Quit() // ���� ���� ��ư
    {
        Application.Quit();
    }
    #endregion

    #region ///MainScene///
    public void MainStart() // ���� ��ŸƮ(Main)(�̹� �÷����� ���� �ִٸ� �ٷ� ����)(�ƴ϶�� ���� ����� â ��)
    {
        if (gameManager.isAlreadyPlayed)
            firebaseDBManager.ReadData(playerPrefsManager.myName);
        else
            objectManager.createUserFrame.SetActive(true);
    }

    public void ConfirmName() // �г��� Ȯ�� ��ư
    {
        firebaseDBManager.CheckUserName(objectManager.userNameInputText.text);
    }

    public void MainToInCastle() // InCastle������(Main)
    {
        SceneManager.LoadScene("InCastle");
    }

    public void CreateUserData() // �г����� �ߺ��� �ƴ϶�� ���� ������ ���� ���� ����
    {
        firebaseDBManager.WriteCreateData(dataManager.UserDataInit(objectManager.userNameInputText.text));
        gameManager.isCompletedCheck = false;
        playerPrefsManager.SetPlayerPrefsName(objectManager.userNameInputText.text);
        playerPrefsManager.SetPlayerPrefsPlayed(1);
        MainToInCastle();
    }
    #endregion

    #region ///InCastleScene///
    public void InCastleToDeffence() // Defence������(InCastle)
    {
        SceneManager.LoadScene("DefenceScene");
    }

    public void InCastleToOutCastle() // Defence������(InCastle)
    {
        SceneManager.LoadScene("OutCastle");
    }
    #endregion

    #region ///OutCastleScene///
    public void OutCastleToInCastle() // InCastle������(OutCastle)
    {
        SceneManager.LoadScene("InCastle");
    }

    public void ForestFrameOnOff() // �� �ڿ� ���� ȭ�� On, Off
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

    public void MineFrameOnOff() // ���� �ڿ� ���� ȭ�� On, Off
    {
        if (objectManager.mineFrame.activeSelf)
            objectManager.mineFrame.SetActive(false);
        else
            objectManager.mineFrame.SetActive(true);
    }

    public void TreeWorkFrameOn() // ���� ��ũ ������ On
    {
        objectManager.treeWorkFrame.SetActive(true);
    }

    public void TreeWorkFrameOff() // ���� ��ũ ������ Off
    {
        objectManager.treeWorkFrame.SetActive(false);
    }

    public void TreeHire() // ���� �η� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood])
        {                                                                                                                             
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;                                                      
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehWood);
        }
    }

    public void StoneButtonOn() // �� ��ư On
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emStone].gameObject.SetActive(true);
    }

    public void StoneButtonOff() // �� ��ư Off
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emStone].gameObject.SetActive(false);
    }

    public void IronButtonOn() // ö ��ư On
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emIron].gameObject.SetActive(true);
    }

    public void IronButtonOff() // ö ��ư Off
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emIron].gameObject.SetActive(false);
    }

    public void GoldButtonOn() // �� ��ư On
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emGold].gameObject.SetActive(true);
    }

    public void GoldButtonOff() // �� ��ư Off
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emGold].gameObject.SetActive(false);
    }

    public void DiamondButtonOn() // ���̾� ��ư On
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond].gameObject.SetActive(true);
    }

    public void DiamondButtonOff() // ���̾� ��ư Off
    {
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond].gameObject.SetActive(false);
    }

    public void StoneWorkFrameOn() // �� ��ũ ������ On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emStone].SetActive(true);
    }

    public void StoneWorkFrameOff() // �� ��ũ ������ Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emStone].SetActive(false);
    }

    public void IronWorkFrameOn() // ö ��ũ ������ On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emIron].SetActive(true);
    }

    public void IronWorkFrameOff() // ö ��ũ ������ Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emIron].SetActive(false);
    }

    public void GoldWorkFrameOn() // �� ��ũ ������ On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emGold].SetActive(true);
    }

    public void GoldWorkFrameOff() // �� ��ũ ������ Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emGold].SetActive(false);
    }

    public void DiamondWorkFrameOn() // ���̾� ��ũ ������ On
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emDiamond].SetActive(true);
    }

    public void DiamondWorkFrameOff() // ���̾� ��ũ ������ Off
    {
        objectManager.mineralWorkFrame[(int)DataManager._EMineral_.emDiamond].SetActive(false);
    }

    public void SwitchToNextMineral() // ���� ������ ����
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

    public void MineralObjectSelectedOnOff() // ���� ������ �´� ������ �� ��ư On, Off
    {
        for(int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            if((int)dataManager.currentMineralState == i)
            {
                objectManager.mineralWorkFrameOnButton[i].gameObject.SetActive(true);
                objectManager.mineralWorkFrame[i].SetActive(true);
                objectManager.mineralLeftTimeText[i].gameObject.SetActive(true);
                continue;
            }
            objectManager.mineralWorkFrameOnButton[i].gameObject.SetActive(false);
            objectManager.mineralWorkFrame[i].SetActive(false);
            objectManager.mineralLeftTimeText[i].gameObject.SetActive(false);
        }
    }

    public void SetMineralState(DataManager._EMineral_ newMineralState) // ���� ���� ���� ����
    {
        dataManager.currentMineralState = newMineralState;
    }

    public void StoneHire() // �� �η� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehStone] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehStone]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehStone];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehStone);
        }
    }

    public void IronHire() // ö �η� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehIron] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehIron]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehIron];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehIron);
        }
    }

    public void GoldHire() // �� �η� ���
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] >= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehGold] && DataManager.MaxHire > dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehGold])
        {
            dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood]++;
            dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] -= DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehGold];
            uiManager.SetTextHireCnt(DataManager._EHired_.ehGold);
        }
    }

    public void DiamondHire() // ���̾� �η� ���
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
    public void DefenceToInCastle() // Defence������ InCastle������
    {
        gameManager.SetBattleState(GameManager._EBattleState_.egNotBattle);
        SceneManager.LoadScene("InCastle");
    }

    public void OptionFrameOnOff() // �ɼ� â On, Off
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

    public void RePrepare() // Prepare�� ���ư�
    {
        gameManager.SetBattleState(GameManager._EBattleState_.egNotBattle);
        objectManager.prepareFrame.SetActive(true);
        objectManager.battleFrame.SetActive(false);
        // EnemyManager�� �����ϴ� �ڵ�
    }

    public void SoldierUpgradeFrameOnOff() // ���� ��ȭ ������ On, Off
    {
        if (objectManager.soldierUpgradeFrame.activeSelf)
        {
            objectManager.soldierUpgradeFrame.SetActive(false);
        }
        else
            objectManager.soldierUpgradeFrame.SetActive(true);
    }

    public void SoldierUpgradeConfirmFrameOnOff() // ���� ��ȭ Ȯ�� ������ �� ����
    {
        if (objectManager.soldierUpgradeConfirmFrame.activeSelf)
        {
            objectManager.soldierUpgradeConfirmFrame.SetActive(false);
        }
        else
        {
            objectManager.soldierUpgradeConfirmFrame.SetActive(true);
            SoldierUpgradeObjectSelectedOnOff();
        }
    }

    public void SwitchToNextSoldierUpgrade() // ���׷��̵� �� ���� ���� ����
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

    public void SoldierUpgradeObjectSelectedOnOff() // ���� ��ȭ ������Ʈ ���� �¿���
    {
        for(int i = 0; i < (int)DataManager._ESoldierUpgrade_.esuMax; i++)
        {
            if((int)dataManager.currentSoldierUpgradeState == i)
                objectManager.soldierUpgradeConfirmFrameOnButton[i].gameObject.SetActive(true);

            objectManager.soldierUpgradeConfirmFrameOnButton[i].gameObject.SetActive(false);
        }
        uiManager.SetTextSoldierUpgrade();
    }

    public void SoldierUpgrade() // ���� ��ȭ
    {
        if (dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] <
            DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)]
            && DataManager.MaxSoldierUpgrade > dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState])
        {
            dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState]++;
            dataManager.myUserInfo.m_nSoldierUpgrade[(int)DataManager._EResource_.erMoney] -= DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)];
            uiManager.SetTextSoldierUpgrade();
            _isSoldierUpgraded = true;
        }
    }

    public void BallistaUpgradeFrameOnOff() // �߸���Ÿ ��ȭ ������ On, Off
    {
        if (objectManager.ballistaUpgradeFrame.activeSelf)
            objectManager.ballistaUpgradeFrame.SetActive(false);
        else
            objectManager.ballistaUpgradeFrame.SetActive(true);
    }

    public void BallistaUpgradeConfirmFrameOnOff()
    {
        if (objectManager.ballistaUpgradeConfirmFrame.activeSelf)
            objectManager.ballistaUpgradeConfirmFrame.SetActive(false);
        else
            objectManager.ballistaUpgradeConfirmFrame.SetActive(true);
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
    }

    public void MainButtonsEvent()
    {
        objectManager.mainToInCastleButton.onClick.AddListener(MainStart);
        objectManager.createUserButton.onClick.AddListener(ConfirmName);
    }

    public void InCastleButtonsEvent()
    {
        objectManager.inCastleToDefenceButton.onClick.AddListener(InCastleToDeffence);
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
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emStone].onClick.AddListener(StoneWorkFrameOn);
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emIron].onClick.AddListener(IronWorkFrameOn);
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emGold].onClick.AddListener(GoldWorkFrameOn);
        objectManager.mineralWorkFrameOnButton[(int)DataManager._EMineral_.emDiamond].onClick.AddListener(DiamondWorkFrameOn);
        objectManager.nextMineralButton.onClick.AddListener(SwitchToNextMineral);
        objectManager.mineralHireButton[(int)DataManager._EMineral_.emStone].onClick.AddListener(StoneHire);
        objectManager.mineralHireButton[(int)DataManager._EMineral_.emIron].onClick.AddListener(IronHire);
        objectManager.mineralHireButton[(int)DataManager._EMineral_.emGold].onClick.AddListener(GoldHire);
        objectManager.mineralHireButton[(int)DataManager._EMineral_.emDiamond].onClick.AddListener(DiamondHire);
    }

    public void DefenceButtonsEvent()
    {
        objectManager.defenceToInCastleButton.onClick.AddListener(DefenceToInCastle);
        objectManager.optionFrameOnButton.onClick.AddListener(OptionFrameOnOff);
        objectManager.optionButton[(int)_EOptionButton_.eobToInCastle].onClick.AddListener(DefenceToInCastle);
        objectManager.optionButton[(int)_EOptionButton_.eobRePrepare].onClick.AddListener(RePrepare);
        objectManager.optionButton[(int)_EOptionButton_.eobContinue].onClick.AddListener(OptionFrameOnOff);
        objectManager.soldierUpgradeFrameOnButton.onClick.AddListener(SoldierUpgradeFrameOnOff);
        objectManager.soldierUpgradeFrameOffButton.onClick.AddListener(SoldierUpgradeFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuNormalSoldier].onClick.AddListener(SoldierUpgradeConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuRareSoldier].onClick.AddListener(SoldierUpgradeConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuTankSoldier].onClick.AddListener(SoldierUpgradeConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuUniversalSoldier].onClick.AddListener(SoldierUpgradeConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuAssassinSoldier].onClick.AddListener(SoldierUpgradeConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOnButton[(int)DataManager._ESoldierUpgrade_.esuUnknownSoldier].onClick.AddListener(SoldierUpgradeConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmFrameOffButton.onClick.AddListener(SoldierUpgradeConfirmFrameOnOff);
        objectManager.soldierUpgradeConfirmButton.onClick.AddListener(SoldierUpgrade);

        objectManager.ballistaUpgradeFrameOnButton.onClick.AddListener(BallistaUpgradeFrameOnOff);
        objectManager.ballistaUpgradeFrameOffButton.onClick.AddListener(BallistaUpgradeFrameOnOff);
        objectManager.ballistaUpgradeConfirmFrameOnButton.onClick.AddListener(BallistaUpgradeConfirmFrameOnOff);
        objectManager.ballistaUpgradeConfirmFrameOffButton.onClick.AddListener(BallistaUpgradeConfirmFrameOnOff);
    }

    // -------------------------------------------- private

    #endregion
}
