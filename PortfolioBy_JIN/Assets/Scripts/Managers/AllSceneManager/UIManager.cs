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
        if (Input.GetKeyDown(KeyCode.Escape)) // esc키를 누르면 종료할 수 있는 UI가 뜸
        {
            QuitFrameOnOff();
        }

        if (gameManager.currentSceneState == GameManager._ESceneState_.esOutCastle) // OutCastle에서만 호출
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

    public void SetTextHirePrice() // 인력 고용 가격 설정
    {
        objectManager.treeHirePriceText.text = DataManager.ResourceHirePrice[(int)DataManager._EHired_.ehWood].ToString();
        for (int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            objectManager.mineralHirePriceText[i].text = DataManager.ResourceHirePrice[i + 1].ToString();
        }
    }

    public void QuitFrameOnOff() // 종료 화면 온 오프
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

    public void CutDownTreeLeftTime() // 벌목의 남은 시간
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] >= 360f)
        {
            objectManager.treeLeftTimeText.text = "남은 시간 : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] / 60) + "분";
        }
        else
        {
            objectManager.treeLeftTimeText.text = "남은 시간 : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltWood] + "초";
        }
    }

    public void MiningStoneLeftTime() // 돌 채광의 남은 시간
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] >= 360f)
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emStone].text = "남은 시간 : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] / 60) + "분";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emStone].text = "남은 시간 : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltStone] + "초";
        }
    }

    public void MiningIronLeftTime() // 철 채광의 남은 시간
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] >= 360f)
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emIron].text = "남은 시간 : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] / 60) + "분";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emIron].text = "남은 시간 : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltIron] + "초";
        }
    }

    public void MiningGoldLeftTime() // 금 채광의 남은 시간
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] >= 360f)
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emGold].text = "남은 시간 : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] / 60) + "분";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emGold].text = "남은 시간 : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltGold] + "초";
        }
    }

    public void MiningDiamondLeftTime() // 다이아 채광의 남은 시간
    {
        if (dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] >= 360f)
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emDiamond].text = "남은 시간 : " + (int)(dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] / 60) + "분";
        }
        else
        {
            objectManager.mineralLeftTimeText[(int)DataManager._EMineral_.emDiamond].text = "남은 시간 : " + (int)dataManager.myUserInfo.m_fLeftTime[(int)DataManager._ELeftTime_.eltDiamond] + "초";
        }
    }

    public void SetResourceUI() // 자원UI 세팅
    {
        for (int i = 0; i < (int)DataManager._EResource_.erMax; i++)
        {
            objectManager.resourceText[i].text = dataManager.myUserInfo.m_nResource[i].ToString();
        }
    }

    public void SetResourceUI(DataManager._EResource_ select) // 자원 UI 선택 세팅
    {
        objectManager.resourceText[(int)select].text = dataManager.myUserInfo.m_nResource[(int)select].ToString();
    }

    public void SetTextHireCnt() // 고용된 인력 숫자 세팅
    {
        objectManager.treeHiredCntText.text = dataManager.myUserInfo.m_nHired[(int)DataManager._EHired_.ehWood].ToString();
        for (int i = 0; i < (int)DataManager._EMineral_.emMax; i++)
        {
            objectManager.mineralHiredCntText[i].text = dataManager.myUserInfo.m_nHired[i + 1].ToString();
        }
    }

    public void SetTextHireCnt(DataManager._EHired_ select) // 고용된 인력 숫자 선택 세팅
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
    
    public void SetTextPlacedSoldier() // 배치된 병사 수 세팅
    {
        objectManager.placedSoldierText.text = prepareManager.placedSoldier.ToString();
    }

    public void SetTextSoldierUpgrade() // 솔져 업그레이드 Text 세팅
    {
        objectManager.soldierUpgradePriceText.text = 
            DataManager.SoldierUpgradePrice[(int)dataManager.currentSoldierUpgradeState, dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] / (DataManager.SoldierUpgradePriceCnt - 1)].ToString();

        objectManager.soldierUpgradeInformationText[(int)DataManager._ESoldierUpgradeInfo_.esuiCurrentUpgrade].text =
            "현재 업그레이드 : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState].ToString();

        objectManager.soldierUpgradeInformationText[(int)DataManager._ESoldierUpgradeInfo_.esuiAdditionalStat].text =
            "추가 공격력 / 체력 / 방어력 : " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Character.SoldierIncreaseAttack[(int)dataManager.currentSoldierUpgradeState] +
            " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Character.SoldierIncreaseHp[(int)dataManager.currentSoldierUpgradeState] +
            " / " + dataManager.myUserInfo.m_nSoldierUpgrade[(int)dataManager.currentSoldierUpgradeState] * Character.SoldierIncreaseDefence[(int)dataManager.currentSoldierUpgradeState];
    }

    public void SceneLoadedUIs() // 씬이 로드될 때마다 필요한 UI의 세팅
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

    // ~~~UIsRef : ~~~씬 UI오브젝트 참조

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
