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
    #region ///AllScene///

    #endregion

    #region ///InCastle, OutCastleScene///

    #endregion

    GameManager gameManager;

    ObjectManager objectManager;

    DataManager dataManager;

    PrepareManager prepareManager;
    #endregion

    #region //property//
    #region ///AllScene///

    #endregion

    #region ///InCastle///

    #endregion

    #region ///OutCastle///

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
        objectManager = ObjectManager.instance;
        dataManager = DataManager.instance;
        prepareManager = PrepareManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // escŰ�� ������ ������ �� �ִ� UI�� ��
        {
            QuitFrameOnOff();
        }

        if (gameManager.currentSceneState == GameManager._ESceneState_.esOutCastle) // OutCastle������ ȣ��
        {
            CutDownTreeLeftTime();
            MiningStoneLeftTime();
            MiningIronLeftTime();
            MiningGoldLeftTime();
            MiningDiamondLeftTime();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void SetTextHirePrice() // �η� ��� ���� ����
    {
        objectManager.treeHirePriceText.text = DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood].ToString();
        for (int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            objectManager.mineralsHirePriceText[i].text = DataManager.ResourceHirePrice[i + 1].ToString();
        }
    }

    public void QuitFrameOnOff() // ���� ȭ�� �� ����
    {
        if (objectManager.quitFrame.activeSelf)
        {
            Time.timeScale = 1f;
            objectManager.quitFrame.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            objectManager.quitFrame.gameObject.SetActive(true);
        }
    }

    public void CutDownTreeLeftTime() // ������ ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] >= 360f)
        {
            objectManager.treeLeftTimeText.text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] / 60) + "��";
        }
        else
        {
            objectManager.treeLeftTimeText.text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] + "��";
        }
    }

    public void MiningStoneLeftTime() // �� ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] >= 360f)
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emStone].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] / 60) + "��";
        }
        else
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emStone].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] + "��";
        }
    }

    public void MiningIronLeftTime() // ö ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] >= 360f)
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emIron].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] / 60) + "��";
        }
        else
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emIron].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] + "��";
        }
    }

    public void MiningGoldLeftTime() // �� ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] >= 360f)
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emGold].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] / 60) + "��";
        }
        else
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emGold].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] + "��";
        }
    }

    public void MiningDiamondLeftTime() // ���̾� ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] >= 360f)
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emDiamond].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] / 60) + "��";
        }
        else
        {
            objectManager.mineralsLeftTimeText[(int)DataManager._EMineral_.emDiamond].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] + "��";
        }
    }

    public void SetTextResourceUI() // �ڿ�UI ����
    {
        for (int i = 0; i < (int)DataManager._EResource_.erMax; i++)
        {
            objectManager.resourceText[i].text = dataManager.myUserInfo.m_nResource[i].ToString();
        }
    }

    public void SetTextResourceUI(DataManager._EResource_ select) // �ڿ� UI ���� ����
    {
        objectManager.resourceText[(int)select].text = dataManager.myUserInfo.m_nResource[(int)select].ToString();
    }

    public void SetTextHireCnt() // ���� �η� ���� ����
    {
        objectManager.treeHiredCntText.text = dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood].ToString();
        for (int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            objectManager.mineralsHiredCntText[i].text = dataManager.myUserInfo.m_nHired[i + 1].ToString();
        }
    }

    public void SetTextHireCnt(DataManager._EHired_ select) // ���� �η� ���� ���� ����
    {
        switch (select)
        {
            case DataManager._EHired_.ehWood:
                objectManager.treeHiredCntText.text = dataManager.myUserInfo.m_nHired[(int)select].ToString();
                break;
            case DataManager._EHired_.ehStone:
            case DataManager._EHired_.ehIron:
            case DataManager._EHired_.ehGold:
            case DataManager._EHired_.ehDiamond:
                objectManager.mineralsHiredCntText[(int)select].text = dataManager.myUserInfo.m_nHired[(int)select].ToString();
                break;
            default:
                break;
        }
    }
    
    public void SetTextPlacedSoldier() // ��ġ�� ���� �� ����
    {
        objectManager.placedSoldierText.text = prepareManager.placedSoldier + " / " + prepareManager.placedSoldierMax; ;
    }

    public void SetTextWave()
    {
        objectManager.waveText.text = dataManager.myUserInfo.m_nWave.ToString();
    }

    public void SetTextSoldierUpgrade() // ���� ���׷��̵� Text ����
    {
        objectManager.soldierUpgradePriceText.text = 
            DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)].ToString();

        objectManager.soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade].text =
            "���� ���׷��̵� : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState].ToString();

        objectManager.soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat].text =
            "�߰� ���ݷ� / ü�� / ���� : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Soldier.SoldierIncreaseAttack[(int)dataManager.currentSoldierUpgradeState] +
            " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Soldier.SoldierIncreaseHp[(int)dataManager.currentSoldierUpgradeState] +
            " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Soldier.SoldierIncreaseDefence[(int)dataManager.currentSoldierUpgradeState];
    }

    public void SetTextSoldierUnLock() // ���� ��� Text ����
    {
        objectManager.soldierUnLockPriceText.text = DataManager.SoldierUnLockPrice[(int)dataManager.currentSoldierUpgradeState].ToString();
    }

    public void SetTextWeaponUpgrade() // ���� ���׷��̵� Text ����
    {
        objectManager.weaponUpgradePriceText.text =
            DataManager.BallistaUpgradePrice[dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)].ToString();

        objectManager.weaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade].text =
            "���� ���׷��̵� : " + dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState].ToString();

        objectManager.weaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat].text =
            "�߰� ���ݷ� : " + dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState] * Weapon.WeaponIncreaseAttack[(int)Weapon._EWeaponClass_.ewcBallista];

        int i = dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState] / (DataManager.MaxBallistaUpgrade - 1);

        for (int j = 0; j < (int)DataManager._EWeaponResource_.ebrMax; j++)
            objectManager.weaponUpgradeResourcesText[j].text = DataManager.BallistaUpgradeResource[j, i].ToString();
    }

    public void SetTextCastleUpgrade() // �� ���׷��̵� Text ����
    {
        objectManager.castleUpgradePriceText.text = DataManager.CastleUpgradePrice[(int)dataManager.myUserInfo.m_nCastleUpgrade / DataManager.CastleUpgradePriceCnt].ToString();

        objectManager.castleUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade].text =
            "���� ���׷��̵� : " + dataManager.myUserInfo.m_nCastleUpgrade.ToString();

        objectManager.castleUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat].text =
            "�߰� ü�� / ���� : " + dataManager.myUserInfo.m_nCastleUpgrade * Castle.CastleIncreaseHp +
            " / " + dataManager.myUserInfo.m_nCastleUpgrade * Castle.CastleIncreaseDefence;
    }

    public void SceneLoadedUIs() // ���� �ε�� ������ �ʿ��� UI�� ����
    {
        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esInCastle:
                InCastleUIsRef();
                break;
            case GameManager._ESceneState_.esOutCastle:
                OutCastleUIsRef();
                break;
            case GameManager._ESceneState_.esDefence:
                DefenceUIsRef();
                break;
            default:
                break;
        }
    }

    // ~~~UIsRef : ~~~�� UI������Ʈ ����

    public void InCastleUIsRef()
    {
        SetTextResourceUI();
    }

    public void OutCastleUIsRef()
    {
        SetTextResourceUI();
        SetTextHirePrice();
        SetTextHireCnt();
    }

    public void DefenceUIsRef()
    {
        SetTextResourceUI(DataManager._EResource_.erMoney);
        SetTextWave();
        SetTextPlacedSoldier();
    }
    //-------------------------------------------- private

    #endregion
}
