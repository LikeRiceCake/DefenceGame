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

    EnemyManager enemyManager;

    ButtonManager buttonManager;

    ResourceManager resourceManager;

    TimeManager timeManager;
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
        enemyManager = EnemyManager.instance;
        buttonManager = ButtonManager.instance;
        resourceManager = ResourceManager.instance;
        timeManager = TimeManager.instance;
    }

    private void Update()
    {
        GatherResource();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    #region //AllScene//
    public bool QuitFrameOnOff() // ���� ȭ�� �� ����
    {
        if (objectManager.quitFrame.activeSelf)
            objectManager.quitFrame.gameObject.SetActive(false);
        else
            objectManager.quitFrame.gameObject.SetActive(true);

        return objectManager.quitFrame.gameObject.activeSelf;
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
    #endregion

    #region //MainScene//
    public void CreateUserFrameOn() // ���� ���� â On
    {
        objectManager.createUserFrame.SetActive(true);
    }
    #endregion

    #region //OutCastle//
    public void GatherResource()
    {
        if (gameManager.currentSceneState == GameManager._ESceneState_.esOutCastle) // OutCastle������ ȣ��
        {
            SetTextCutDownTreeLeftTime();
            SetTextMiningMineralLeftTime();
        }
    }

    public void SetTextCutDownTreeLeftTime() // ������ ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] >= 360f)
            objectManager.treeLeftTimeText.text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] / 60) + "��";
        else
            objectManager.treeLeftTimeText.text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] + "��";
    }

    public void SetTextMiningMineralLeftTime() // ���� ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)dataManager.currentMineralState + 1] >= 360f)
            objectManager.mineralLeftTimeText.text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)dataManager.currentMineralState + 1] / 60) + "��";
        else
            objectManager.mineralLeftTimeText.text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)dataManager.currentMineralState + 1] + "��";
    }

    public void ForestFrameOnOff()
    {
        if (objectManager.forestFrame.activeSelf)
            objectManager.forestFrame.SetActive(false);
        else
            objectManager.forestFrame.SetActive(true);
    }

    public void MineFrameOnOff()
    {
        if (objectManager.mineFrame.activeSelf)
            objectManager.mineFrame.SetActive(false);
        else
            objectManager.mineFrame.SetActive(true);
    }

    public void TreeWorkFrameOn()
    {
        objectManager.treeWorkFrame.SetActive(true);
    }

    public void TreeWorkFrameOff()
    {
        objectManager.treeWorkFrame.SetActive(false);
    }

    public void MineralImageChange()
    {
        string path;

        switch (dataManager.currentMineralState)
        {
            case DataManager._EMineral_.emStone:
                path = "Image/Stone";
                break;
            case DataManager._EMineral_.emIron:
                path = "Image/Iron";
                break;
            case DataManager._EMineral_.emGold:
                path = "Image/Gold";
                break;
            case DataManager._EMineral_.emDiamond:
                path = "Image/Diamond";
                break;
            default:
                path = "Image/Stone";
                break;
        }

        objectManager.mineralWorkFrameOnButtonImage.sprite = resourceManager.LoadSpriteResource(path);
    }

    public void SetTextHirePrice() // �η� ��� ���� ����
    {
        objectManager.treeHirePriceText.text = DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood].ToString();
        objectManager.mineralHirePriceText.text = DataManager.ResourceHirePrice[(int)dataManager.currentMineralState + 1].ToString();
    }

    public void SetTextHireCnt() // ���� �η� ���� ����
    {
        objectManager.treeHiredCntText.text = dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood].ToString();
        objectManager.mineralHiredCntText.text = dataManager.myUserInfo.m_nHired[(int)dataManager.currentMineralState + 1].ToString();
    }

    public void MineralWorkFrameOnOff(bool _active)
    {
        objectManager.mineralWorkFrame.SetActive(_active);
    }
    #endregion

    #region //DefenceScene//
    public void SetImageGameSpeed(string _key) // ���� �ӵ� ��ư �̹��� ����
    {
        objectManager.gameSpeedControlButtonImage.sprite = resourceManager.LoadSpriteResource(_key);
    }

    public void SoldierUpgradeFrameOnOff() // ���� ��ȭ ������ OnOff
    {
        if (objectManager.soldierUpgradeFrame.activeSelf)
            objectManager.soldierUpgradeFrame.SetActive(false);
        else
            objectManager.soldierUpgradeFrame.SetActive(true);
    }

    public void SoldierUpgradeAndUnLcokConfirmFrameOnOff() // ���� ��ȭ Ȯ�� ������ �� ����
    {
        if (objectManager.soldierUpgradeConfirmFrame.activeSelf)
            SoldierUpgradeAndUnLcokConfirmFrameOff();
        else
            SoldierUpgradeAndUnLcokConfirmFrameOn();
    }

    public void SoldierUpgradeAndUnLcokConfirmFrameOn()
    {
        if (dataManager.myUserInfo.m_bSoldierLock[(int)dataManager.currentSoldierUpgradeState])
        {
            objectManager.soldierUpgradeConfirmFrame.SetActive(true);
            SetTextSoldierUpgrade();
        }
        else
        {
            objectManager.soldierUnLockFrame.SetActive(true);
            SetTextSoldierUnLock();
        }
    }

    public void SoldierUpgradeAndUnLcokConfirmFrameOff()
    {
        if (dataManager.myUserInfo.m_bSoldierLock[(int)dataManager.currentSoldierUpgradeState])
            objectManager.soldierUpgradeConfirmFrame.SetActive(false);
        else
            objectManager.soldierUnLockFrame.SetActive(false);
    }

    public void SoldierImageChange()
    {
        string path;

        switch (dataManager.currentSoldierUpgradeState)
        {
            case DataManager._ESoldierUpgrade_.esuNormalSoldier:
                path = "Image/NormalSoldier";
                break;
            case DataManager._ESoldierUpgrade_.esuRareSoldier:
                path = "Image/RareSoldier";
                break;
            case DataManager._ESoldierUpgrade_.esuTankSoldier:
                path = "Image/TankSoldier";
                break;
            case DataManager._ESoldierUpgrade_.esuUniversalSoldier:
                path = "Image/UniversalSoldier";
                break;
            case DataManager._ESoldierUpgrade_.esuAssassinSoldier:
                path = "Image/AssassinSoldier";
                break;
            case DataManager._ESoldierUpgrade_.esuUnknownSoldier:
                path = "Image/UnknownSoldier";
                break;
            default:
                path = "Image/NormalSoldier";
                break;
        }

        objectManager.soldierUpgradeConfirmFrameOnButtonImage.sprite = resourceManager.LoadSpriteResource(path);
    }

    public void SetTextSoldierUpgrade() // ���� ���׷��̵� Text ����
    {
        objectManager.soldierUpgradePriceText.text =
            DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)].ToString();

        objectManager.soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade].text =
            "���� ���׷��̵� : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState].ToString();

        objectManager.soldierUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat].text =
            "�߰� ���ݷ� / ü�� / ���� : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Soldier.SoldierIncreaseAttack[(int)dataManager.currentSoldierUpgradeState]
            + " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Soldier.SoldierIncreaseHp[(int)dataManager.currentSoldierUpgradeState]
            + " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Soldier.SoldierIncreaseDefence[(int)dataManager.currentSoldierUpgradeState];
    }

    public void SetTextSoldierUnLock() // ���� ��� Text ����
    {
        objectManager.soldierUnLockPriceText.text = DataManager.SoldierUnLockPrice[(int)dataManager.currentSoldierUpgradeState].ToString();
    }

    public void SetTextWeaponUpgrade() // ���� ���׷��̵� Text ����
    {
        objectManager.weaponUpgradePriceText.text =
            DataManager.BallistaUpgradePrice[dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState] / (DataManager.WeaponUpgradePriceCnt - 1)].ToString();

        objectManager.weaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiCurrentUpgrade].text =
            "���� ���׷��̵� : " + dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState].ToString();

        objectManager.weaponUpgradeInformationsText[(int)DataManager._EUpgradeInfo_.euiAdditionalStat].text =
            "�߰� ���ݷ� : " + dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState] * Weapon.WeaponIncreaseAttack[(int)Weapon._EWeaponClass_.ewcBallista];

        for (int j = 0; j < (int)DataManager._EWeaponResource_.ebrMax; j++)
            objectManager.weaponUpgradeResourcesText[j].text =
                DataManager.BallistaUpgradeResource[j, dataManager.myUserInfo.m_nWeaponUpgrade[(int)dataManager.currentWeaponUpgradeState] / (DataManager.WeaponUpgradeResourceCnt - 1)].ToString();
    }

    public bool OptionFrameOnOff() // �ɼ� ������ OnOff
    {
        if (objectManager.optionFrame.activeSelf)
            objectManager.optionFrame.SetActive(false);
        else
            objectManager.optionFrame.SetActive(true);

        return objectManager.optionFrame.activeSelf;
    }

    public void SoldierUnLockFrameOff() // ���� ��� ������ Off
    {
        objectManager.soldierUnLockFrame.SetActive(false);
    }

    public void WeaponUpgradeConfirmFrameOnOff() // ���� ���׷��̵� Ȯ�� ������ OnOff
    {
        if (objectManager.weaponUpgradeConfirmFrame.activeSelf)
            objectManager.weaponUpgradeConfirmFrame.SetActive(false);
        else
        {
            objectManager.weaponUpgradeConfirmFrame.SetActive(true);
            SetTextWeaponUpgrade();
        }
    }

    public void WeaponImageChange() // ���׷��̵� ���� �̹��� ����
    {
        string path;

        switch (dataManager.currentWeaponUpgradeState)
        {
            case DataManager._EWeaponUpgrade_.ewuBallista:
                path = "Image/Ballista";
                break;
            default:
                path = "Image/Ballista";
                break;
        }

        objectManager.weaponUpgradeConfirmFrameOnButtonImage.sprite = resourceManager.LoadSpriteResource(path);
    }

    public void WeaponUpgradeConfirmFrameOff() // ���� ���׷��̵� Ȯ�� ������ Off
    {
        objectManager.weaponUpgradeConfirmFrame.SetActive(false);
    }

    public void DefenceStartFrameSet() // ���潺 ���۽� Frame On, Off
    {
        objectManager.prepareFrame.SetActive(false);
        objectManager.battleFrame.SetActive(true);
    }

    public void CastleUpgradeFrameOnOff()
    {
        if (objectManager.castleUpgradeFrame.activeSelf)
            objectManager.castleUpgradeFrame.SetActive(false);
        else
        {
            objectManager.castleUpgradeFrame.SetActive(true);
            SetTextCastleUpgrade();
        }
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

    public bool SoldierSummonSelectFrameOnOff()
    {
        if (objectManager.soldierSummonSelectFrame.activeSelf)
            objectManager.soldierSummonSelectFrame.SetActive(false);
        else
            objectManager.soldierSummonSelectFrame.SetActive(true);

        return objectManager.soldierSummonSelectFrame.activeSelf;
    }

    public void SetTextSoldierAndWeaponCnt() // ��ġ�� ����, ���� �� ����
    {
        objectManager.soldierAndWeaponCntText.text =
            "���� " + prepareManager.currentSummonedSoldier + " / " + prepareManager.summonedSoldierMax
            + "\n"
            + "���� " + prepareManager.currentDeployedWeapon + " / " + prepareManager.deployedWeaponMax;
    }

    public bool WeaponDeploySelectFrameOnOff()
    {
        if (objectManager.weaponDeploySelectFrame.activeSelf)
            objectManager.weaponDeploySelectFrame.SetActive(false);
        else
            objectManager.weaponDeploySelectFrame.SetActive(true);

        return objectManager.weaponDeploySelectFrame.activeSelf;
    }

    public void SetTextWave() // Wave ����
    {
        objectManager.waveText.text = dataManager.myUserInfo.m_nWave.ToString();
    }

    

    public void SetTextEnemyCount() // �� �� ����
    {
        objectManager.enemyCntText.text = enemyManager.currentEnemyCnt.ToString();
    }

    public void SetFrameEndDefence(BattleManager._EDefenceResult_ select) // EndDefenceFrame UI����
    {
        switch (select)
        {
            case BattleManager._EDefenceResult_.edrVictory:
                objectManager.endDefenceImage.sprite = resourceManager.LoadSpriteResource("Image/SuccessDefenceStar");
                objectManager.endDefenceText.text = "�� �����߽��ϴ�!";
                break;
            case BattleManager._EDefenceResult_.edrDefeat:
                objectManager.endDefenceImage.sprite = resourceManager.LoadSpriteResource("Image/FailedDefenceCrown");
                objectManager.endDefenceText.text = "�� �����߽��ϴ�...";
                break;
            default:
                break;
        }
    }

    public void SetSFXEndDefence(BattleManager._EDefenceResult_ select) // ���潺�� ������ �� SFX ����
    {
        switch (select)
        {
            case BattleManager._EDefenceResult_.edrVictory:
                SoundManager.instance.SetAudioSFX("Audios/SFX/Victory");
                break;
            case BattleManager._EDefenceResult_.edrDefeat:
                SoundManager.instance.SetAudioSFX("Audios/SFX/Defeat");
                break;
            default:
                break;
        }
    }

    public void EndDefenceFrameOn() // EndDefenceFrame On
    {
        objectManager.endDefenceFrame.SetActive(true);
        timeManager.SetGameSpeed(TimeManager._EGameSpeed_.egsStop);
        timeManager.TimeControl(timeManager.currentGameSpeed);
    }
    #endregion


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

    public void SetImageCastleHp(int _current, int _max) // �� ü�� ����
    {
        objectManager.castleHpFrontImage.fillAmount = (float)_current / _max;
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
        SetTextEnemyCount();
        SetTextSoldierAndWeaponCnt();
    }
    //-------------------------------------------- private

    #endregion
}