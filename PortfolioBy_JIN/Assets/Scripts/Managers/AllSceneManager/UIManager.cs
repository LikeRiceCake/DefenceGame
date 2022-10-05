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
    void Awake()
    {
        DataInit();
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
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        gameManager = GameManager.instance;
        objectManager = ObjectManager.instance;
        dataManager = DataManager.instance;
        prepareManager = PrepareManager.instance;
    }

    public void SetTextHirePrice() // �η� ��� ���� ����
    {
        objectManager.treeHirePriceText.text = DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood].ToString();
        for (int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            objectManager.mineralHirePriceText[i].text = DataManager.ResourceHirePrice[i + 1].ToString();
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
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emStone].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] / 60) + "��";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emStone].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] + "��";
        }
    }

    public void MiningIronLeftTime() // ö ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] >= 360f)
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emIron].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] / 60) + "��";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emIron].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] + "��";
        }
    }

    public void MiningGoldLeftTime() // �� ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] >= 360f)
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emGold].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] / 60) + "��";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emGold].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] + "��";
        }
    }

    public void MiningDiamondLeftTime() // ���̾� ä���� ���� �ð�
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] >= 360f)
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emDiamond].text = "���� �ð� : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] / 60) + "��";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emDiamond].text = "���� �ð� : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] + "��";
        }
    }

    public void SetResourceUI() // �ڿ�UI ����
    {
        for (int i = 0; i < (int)DataManager._EResource_.erMax; i++)
        {
            objectManager.resourceText[i].text = dataManager.myUserInfo.m_nResource[i].ToString();
        }
    }

    public void SetResourceUI(DataManager._EResource_ select) // �ڿ� UI ���� ����
    {
        objectManager.resourceText[(int)select].text = dataManager.myUserInfo.m_nResource[(int)select].ToString();
    }

    public void SetTextHireCnt() // ���� �η� ���� ����
    {
        objectManager.treeHiredCntText.text = dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood].ToString();
        for (int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            objectManager.mineralHiredCntText[i].text = dataManager.myUserInfo.m_nHired[i + 1].ToString();
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
                objectManager.mineralHiredCntText[(int)select].text = dataManager.myUserInfo.m_nHired[(int)select].ToString();
                break;
            default:
                break;
        }
    }
    
    public void SetTextPlacedSoldier() // ��ġ�� ���� �� ����
    {
        objectManager.placedSoldierText.text = prepareManager.placedSoldier.ToString();
    }

    public void SetTextSoldierUpgrade() // ���� ���׷��̵� Text ����
    {
        objectManager.soldierUpgradePriceText.text = 
            DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)].ToString();

        objectManager.soldierUpgradeInformationText[(int)DataManager._ESoldierUpgradeInfo_.esuiCurrentUpgrade].text =
            "���� ���׷��̵� : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState].ToString();

        objectManager.soldierUpgradeInformationText[(int)DataManager._ESoldierUpgradeInfo_.esuiAdditionalStat].text =
            "�߰� ���ݷ� / ü�� / ���� : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Character.SoldierIncreaseAttack[(int)dataManager.currentSoldierUpgradeState] +
            " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Character.SoldierIncreaseHp[(int)dataManager.currentSoldierUpgradeState] +
            " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Character.SoldierIncreaseDefence[(int)dataManager.currentSoldierUpgradeState];
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
        SetResourceUI();
    }

    public void OutCastleUIsRef()
    {
        SetResourceUI();
        SetTextHirePrice();
        SetTextHireCnt();
    }

    public void DefenceUIsRef()
    {

    }
    //-------------------------------------------- private

    #endregion
}
