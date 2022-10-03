using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons_Deffnece : MonoBehaviour
{
    enum SoldierNum { First, Second, Third, Fourth, Fifth, Sixth }

    SoldierNum soldiernum;

    public GameObject enemyManager;
    public GameObject normal;
    public GameObject battle;
    public GameObject pause;
    public GameObject Arrangement;
    public GameObject[] speedButtons;
    public Transform[] ArrangementPos;
    public GameObject SelectSoldier;
    public GameObject[] Soldiers;
    public GameObject[] CreatePos;
    public Image[] TouchButtonImage;
    public IsCreate[] iscreate;
    public IsCreate_Baliistar[] iscreate_Ballistar;
    public Buttons_Deffnece bd;
    public portPlayerPrefs resources;
    public Text soldierText;
    public GameObject CastleUpFrame;
    public Castle castle;
    public FirstSoldier Firsts;
    public SecondSoldier Seconds;
    public ThirdSoldier Thirds;
    public FourthSoldier Fours;
    public FifthSoldier Fifths;
    public SixthSoldier Sixths;
    public GameObject SoldierupFrame;
    public GameObject[] SoldierClick_Up;
    public GameObject[] SoldierUpB;
    public Text[] SoldierUpText;
    public GameObject Ballistar;
    public GameObject[] CreatePos_Ballistar;
    public Transform[] ArrangementPos_Ballistar;
    public GameObject SelectBallistar;
    public Image[] TouchButtonImage_Ballistar;
    public GameObject Ballistar_Bullet;
    public Transform firePos;
    public GameObject Click_arrangement_weapon;
    public GameObject Click_Ballistar_up;
    public Text[] BallistarUpText;
    public Text[] BallistarUp_ResourcesText;
    public Image Meteor_delay;
    public GameObject Meteorobj;
    public GameObject UnLockSoldierFrame;
    public Text[] UnLockSoldierText;
    public GameObject[] UnLockSoldierButton;
    Transform ButtonPos;
    Transform ButtonPos_Ballistar;
    Image CloseTouchButton;
    Image CloseTouchButton_Ballistar;
    int cntis;
    int cntis_Ballistar;
    public bool isBattle;
    public bool isBackRound;
    public bool[] isLock;
    bool canArrangement;
    int canArrangementcnt;
    int canArrangementMax;
    int canArrangementMaxcnt;
    int MaxUpgrade;
    int MaxSoldierUpgrade;



    private void Awake()
    {
        isLock = new bool[5];
        cntis_Ballistar = 0;
        soldiernum = SoldierNum.First;
        isBackRound = false;
        MaxUpgrade = 30;
        MaxSoldierUpgrade = 10;
        canArrangementcnt = 0;
        canArrangement = true;
        bd = this;
        cntis = 0;
        isBattle = false;
        normal.gameObject.SetActive(true);
        battle.gameObject.SetActive(false);
    }

    private void Start()
    {
        for (int i = 0; i < isLock.Length; i++)
        {
            if (resources.SoldierLock[i] == 2)
            {
                isLock[i] = true;
            }
            else if (resources.SoldierLock[i] == 1)
            {
                isLock[i] = false;
            }
        }
        canArrangementMaxcnt = resources.round / 5;
        canArrangementMax = 4 + canArrangementMaxcnt;
        canArrangementMax = Mathf.Clamp(canArrangementMax, 4, 12);
        soldierText.text = 0 + " / " + canArrangementMax;
    }

    private void Update()
    {
        if (Meteor_delay.fillAmount >= 0)
        {
            Meteor_delay.fillAmount -= Time.deltaTime * 0.05f;
        }
    }

    public void startGame()
    {
        enemyManager.gameObject.SetActive(true);
        normal.gameObject.SetActive(false);
        battle.gameObject.SetActive(true);
        isBattle = true;
    }

    public void backCastle()
    {
        if (isBackRound)
        {
            isBackRound = false;
            resources.round++;
            resources.setRound();
        }
        SceneManager.LoadScene("InCastle");
    }

    public void timeControl(int num)
    {
        switch (num)
        {
            case 0:
                Time.timeScale = 2f;
                speedButtons[0].gameObject.SetActive(false);
                speedButtons[1].gameObject.SetActive(true);
                break;
            case 1:
                Time.timeScale = 3.5f;
                speedButtons[1].gameObject.SetActive(false);
                speedButtons[2].gameObject.SetActive(true);
                break;
            case 2:
                Time.timeScale = 1f;
                speedButtons[2].gameObject.SetActive(false);
                speedButtons[0].gameObject.SetActive(true);
                break;
        }

    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pause.gameObject.SetActive(true);
    }

    public void backCastle_Pause()
    {
        enemyManager.gameObject.SetActive(false);
        if (isBackRound)
        {
            isBackRound = false;
            resources.round++;
            resources.setRound();
        }
        SceneManager.LoadScene("InCastle");
    }

    public void continueGame()
    {
        Time.timeScale = 1f;
        pause.gameObject.SetActive(false);
    }

    public void redoGame()
    {
        Time.timeScale = 1f;
        enemyManager.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
        isBattle = false;
        if (isBackRound)
        {
            isBackRound = false;
            resources.round++;
            resources.setRound();
        }
        SceneManager.LoadScene("DeffenceScene");
    }

    public void backCastle_Failed()
    {
        if (isBackRound)
        {
            isBackRound = false;
            resources.round++;
            resources.setRound();
        }
        enemyManager.gameObject.SetActive(false);
        SceneManager.LoadScene("InCastle");
    }

    public void redoGame_Failed()
    {
        Time.timeScale = 1f;
        enemyManager.gameObject.SetActive(false);
        isBattle = false;
        if (isBackRound)
        {
            isBackRound = false;
            resources.round++;
            resources.setRound();
        }
        SceneManager.LoadScene("DeffenceScene");
    }

    public void Close_Arrangement()
    {
        Arrangement.gameObject.SetActive(false);
    }

    public void Open_Arrangement()
    {
        Arrangement.gameObject.SetActive(true);
        for (int i = 0; i < SoldierClick_Up.Length; i++)
        {
            if (i == 0)
            {
                SoldierClick_Up[i].gameObject.SetActive(true);
                continue;
            }
            SoldierClick_Up[i].gameObject.SetActive(false);
        }
    }

    public void Touch_ArrangementPos00(int num)
    {
        switch (num)
        {
            case 0:
                if (!iscreate[0].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[0].position;
                    ButtonPos = CreatePos[0].transform;
                    CloseTouchButton = TouchButtonImage[0];
                    cntis = 0;
                }
                break;
            case 1:
                if (!iscreate[1].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[1].position;
                    ButtonPos = CreatePos[1].transform;
                    CloseTouchButton = TouchButtonImage[1];
                    cntis = 1;
                }
                break;
            case 2:
                if (!iscreate[2].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[2].position;
                    ButtonPos = CreatePos[2].transform;
                    CloseTouchButton = TouchButtonImage[2];
                    cntis = 2;
                }
                break;
            case 3:
                if (!iscreate[3].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[3].position;
                    ButtonPos = CreatePos[3].transform;
                    CloseTouchButton = TouchButtonImage[3];
                    cntis = 3;
                }
                break;
            case 4:
                if (!iscreate[4].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[4].position;
                    ButtonPos = CreatePos[4].transform;
                    CloseTouchButton = TouchButtonImage[4];
                    cntis = 4;
                }
                break;
            case 5:
                if (!iscreate[5].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[5].position;
                    ButtonPos = CreatePos[5].transform;
                    CloseTouchButton = TouchButtonImage[5];
                    cntis = 5;
                }
                break;
            case 6:
                if (!iscreate[6].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[6].position;
                    ButtonPos = CreatePos[6].transform;
                    CloseTouchButton = TouchButtonImage[6];
                    cntis = 6;
                }
                break;
            case 7:
                if (!iscreate[7].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[7].position;
                    ButtonPos = CreatePos[7].transform;
                    CloseTouchButton = TouchButtonImage[7];
                    cntis = 7;
                }
                break;
            case 8:
                if (!iscreate[8].isCreate)
                {
                    SelectSoldier.gameObject.SetActive(true);
                    SelectSoldier.gameObject.transform.position = ArrangementPos[8].position;
                    ButtonPos = CreatePos[8].transform;
                    CloseTouchButton = TouchButtonImage[8];
                    cntis = 8;
                }
                break;
        }
    }

    public void Close_Select()
    {
        SelectSoldier.gameObject.SetActive(false);
    }

    public void Soldier00(int num)
    {
        switch (num)
        {
            case 0:
                if (canArrangement)
                {
                    GameObject obj = Instantiate(Soldiers[0], ButtonPos.position, Quaternion.identity);
                    obj.GetComponent<Soldier>().enemyPos = enemyManager.GetComponent<EnemyManager>().EnemyPool;
                    obj.GetComponent<Soldier>().BD = bd;
                    obj.GetComponent<Soldier>().em = enemyManager.GetComponent<EnemyManager>();
                    obj.GetComponent<Soldier>().resources = resources;
                    obj.GetComponent<Soldier>().Hp = Firsts.Hp + resources.SoldierUp[0];
                    obj.GetComponent<Soldier>().Damage = Firsts.Damage + resources.SoldierUp[0];
                    obj.GetComponent<Soldier>().Speed = Firsts.Speed;
                    SelectSoldier.gameObject.SetActive(false);
                    CloseTouchButton.color = new Color(CloseTouchButton.color.r, CloseTouchButton.color.g, CloseTouchButton.color.b, 0f);
                    iscreate[cntis].isCreate = true;
                    canArrangementcnt++;
                    soldierText.text = canArrangementcnt + " / " + canArrangementMax;
                    if (canArrangementcnt == canArrangementMax)
                    {
                        canArrangement = false;
                    }
                }
                break;
            case 1:
                if (canArrangement && !isLock[0])
                {
                    GameObject obj = Instantiate(Soldiers[1], ButtonPos.position, Quaternion.identity);
                    obj.GetComponent<Soldier>().enemyPos = enemyManager.GetComponent<EnemyManager>().EnemyPool;
                    obj.GetComponent<Soldier>().BD = bd;
                    obj.GetComponent<Soldier>().em = enemyManager.GetComponent<EnemyManager>();
                    obj.GetComponent<Soldier>().resources = resources;
                    obj.GetComponent<Soldier>().Hp = Seconds.Hp + (int)(resources.SoldierUp[1] * 1.2);
                    obj.GetComponent<Soldier>().Damage = Seconds.Damage + (int)(resources.SoldierUp[1] * 1.2);
                    obj.GetComponent<Soldier>().Speed = Seconds.Speed;
                    SelectSoldier.gameObject.SetActive(false);
                    CloseTouchButton.color = new Color(CloseTouchButton.color.r, CloseTouchButton.color.g, CloseTouchButton.color.b, 0f);
                    iscreate[cntis].isCreate = true;
                    canArrangementcnt++;
                    soldierText.text = canArrangementcnt + " / " + canArrangementMax;
                    if (canArrangementcnt == canArrangementMax)
                    {
                        canArrangement = false;
                    }
                }
                break;
            case 2:
                if (canArrangement && !isLock[1])
                {
                    GameObject obj = Instantiate(Soldiers[2], ButtonPos.position, Quaternion.identity);
                    obj.GetComponent<Soldier>().enemyPos = enemyManager.GetComponent<EnemyManager>().EnemyPool;
                    obj.GetComponent<Soldier>().BD = bd;
                    obj.GetComponent<Soldier>().em = enemyManager.GetComponent<EnemyManager>();
                    obj.GetComponent<Soldier>().resources = resources;
                    obj.GetComponent<Soldier>().Hp = Thirds.Hp + (int)(resources.SoldierUp[2] * 1.7);
                    obj.GetComponent<Soldier>().Damage = Thirds.Damage + (int)(resources.SoldierUp[2] * 1.2);
                    obj.GetComponent<Soldier>().Speed = Thirds.Speed;
                    SelectSoldier.gameObject.SetActive(false);
                    CloseTouchButton.color = new Color(CloseTouchButton.color.r, CloseTouchButton.color.g, CloseTouchButton.color.b, 0f);
                    iscreate[cntis].isCreate = true;
                    canArrangementcnt++;
                    soldierText.text = canArrangementcnt + " / " + canArrangementMax;
                    if (canArrangementcnt == canArrangementMax)
                    {
                        canArrangement = false;
                    }
                }
                break;
            case 3:
                if (canArrangement && !isLock[2])
                {
                    GameObject obj = Instantiate(Soldiers[3], ButtonPos.position, Quaternion.identity);
                    obj.GetComponent<Soldier>().enemyPos = enemyManager.GetComponent<EnemyManager>().EnemyPool;
                    obj.GetComponent<Soldier>().BD = bd;
                    obj.GetComponent<Soldier>().em = enemyManager.GetComponent<EnemyManager>();
                    obj.GetComponent<Soldier>().resources = resources;
                    obj.GetComponent<Soldier>().Hp = Fours.Hp + (int)(resources.SoldierUp[3] * 1.4);
                    obj.GetComponent<Soldier>().Damage = Fours.Damage + (int)(resources.SoldierUp[3] * 1.6);
                    obj.GetComponent<Soldier>().Speed = Fours.Speed;
                    SelectSoldier.gameObject.SetActive(false);
                    CloseTouchButton.color = new Color(CloseTouchButton.color.r, CloseTouchButton.color.g, CloseTouchButton.color.b, 0f);
                    iscreate[cntis].isCreate = true;
                    canArrangementcnt++;
                    soldierText.text = canArrangementcnt + " / " + canArrangementMax;
                    if (canArrangementcnt == canArrangementMax)
                    {
                        canArrangement = false;
                    }
                }
                break;
            case 4:
                if (canArrangement && !isLock[3])
                {
                    GameObject obj = Instantiate(Soldiers[4], ButtonPos.position, Quaternion.identity);
                    obj.GetComponent<Soldier>().enemyPos = enemyManager.GetComponent<EnemyManager>().EnemyPool;
                    obj.GetComponent<Soldier>().BD = bd;
                    obj.GetComponent<Soldier>().em = enemyManager.GetComponent<EnemyManager>();
                    obj.GetComponent<Soldier>().resources = resources;
                    obj.GetComponent<Soldier>().Hp = Fifths.Hp + (int)(resources.SoldierUp[4] * 1.1);
                    obj.GetComponent<Soldier>().Damage = Fifths.Damage + (int)(resources.SoldierUp[4] * 2);
                    obj.GetComponent<Soldier>().Speed = Fifths.Speed;
                    SelectSoldier.gameObject.SetActive(false);
                    CloseTouchButton.color = new Color(CloseTouchButton.color.r, CloseTouchButton.color.g, CloseTouchButton.color.b, 0f);
                    iscreate[cntis].isCreate = true;
                    canArrangementcnt++;
                    soldierText.text = canArrangementcnt + " / " + canArrangementMax;
                    if (canArrangementcnt == canArrangementMax)
                    {
                        canArrangement = false;
                    }
                }
                break;
            case 5:
                if (canArrangement && !isLock[4])
                {
                    GameObject obj = Instantiate(Soldiers[5], ButtonPos.position, Quaternion.identity);
                    obj.GetComponent<Soldier>().enemyPos = enemyManager.GetComponent<EnemyManager>().EnemyPool;
                    obj.GetComponent<Soldier>().BD = bd;
                    obj.GetComponent<Soldier>().em = enemyManager.GetComponent<EnemyManager>();
                    obj.GetComponent<Soldier>().resources = resources;
                    obj.GetComponent<Soldier>().Hp = Sixths.Hp + (int)(resources.SoldierUp[5] * 2);
                    obj.GetComponent<Soldier>().Damage = Sixths.Damage + (int)(resources.SoldierUp[5] * 2);
                    obj.GetComponent<Soldier>().Speed = Sixths.Speed;
                    SelectSoldier.gameObject.SetActive(false);
                    CloseTouchButton.color = new Color(CloseTouchButton.color.r, CloseTouchButton.color.g, CloseTouchButton.color.b, 0f);
                    iscreate[cntis].isCreate = true;
                    canArrangementcnt++;
                    soldierText.text = canArrangementcnt + " / " + canArrangementMax;
                    if (canArrangementcnt == canArrangementMax)
                    {
                        canArrangement = false;
                    }
                }
                break;
        }
    }

    public void CastleUpgrade()
    {
        if (resources.CastleUp < MaxUpgrade)
        {
            if (resources.CastleUp < 10)
            {
                if (resources.resources[0] >= 10000)
                {
                    resources.resources[0] -= 10000;
                    resources.setResources();
                    resources.CastleUp++;
                    resources.SetCastleUp();
                    castle.MaxCastleHP = 100 + (resources.CastleUp * 10);
                    castle.CurrentCastleHP = castle.MaxCastleHP;
                }
            }
            else if (resources.CastleUp >= 10 && resources.CastleUp < 20)
            {
                if (resources.resources[0] >= 30000)
                {
                    resources.resources[0] -= 30000;
                    resources.setResources();
                    resources.CastleUp++;
                    resources.SetCastleUp();
                    castle.MaxCastleHP = 100 + (resources.CastleUp * 10);
                    castle.CurrentCastleHP = castle.MaxCastleHP;
                }
            }
            else if (resources.CastleUp >= 20 && resources.CastleUp < 30)
            {
                if (resources.resources[0] >= 50000)
                {
                    resources.resources[0] -= 50000;
                    resources.setResources();
                    resources.CastleUp++;
                    resources.SetCastleUp();
                    castle.MaxCastleHP = 100 + (resources.CastleUp * 10);
                    castle.CurrentCastleHP = castle.MaxCastleHP;
                }
            }
        }
    }

    public void CastleUp_Open()
    {
        CastleUpFrame.gameObject.SetActive(true);
    }

    public void CastleUp_Close()
    {
        CastleUpFrame.gameObject.SetActive(false);
    }

    public void BackRound()
    {
        if (resources.round > 1)
        {
            if (!isBackRound)
            {
                resources.round--;
                resources.setRound();
                isBackRound = true;
            }
        }
    }

    public void ClickSoldier_Up(int num)
    {
        switch (num)
        {
            case 0:
                SoldierupFrame.gameObject.SetActive(true);
                for (int i = 0; i < SoldierUpB.Length; i++)
                {
                    if (i == 0)
                    {
                        SoldierUpB[i].gameObject.SetActive(true);
                        continue;
                    }
                    SoldierUpB[i].gameObject.SetActive(false);
                }
                for (int i = 2; i < SoldierUpText.Length; i++)
                {
                    if (i == 2)
                    {
                        SoldierUpText[i].gameObject.SetActive(true);
                        continue;
                    }
                    SoldierUpText[i].gameObject.SetActive(false);
                }
                SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[0];
                SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)resources.SoldierUp[0] + " / " + (int)resources.SoldierUp[0];
                if (resources.SoldierUp[0] < 3)
                {
                    SoldierUpText[2].text = 10000.ToString();
                }
                else if (resources.SoldierUp[0] >= 3 && resources.SoldierUp[0] < 7)
                {
                    SoldierUpText[2].text = 35000.ToString();
                }
                else if (resources.SoldierUp[0] >= 7 && resources.SoldierUp[0] < 10)
                {
                    SoldierUpText[2].text = 70000.ToString();
                }
                else if (resources.SoldierUp[0] == 10)
                {
                    SoldierUpText[2].text = "한계 도달";
                }
                break;
            case 1:
                if (!isLock[0])
                {
                    SoldierupFrame.gameObject.SetActive(true);
                    for (int i = 0; i < SoldierUpB.Length; i++)
                    {
                        if (i == 1)
                        {
                            SoldierUpB[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpB[i].gameObject.SetActive(false);
                    }
                    for (int i = 2; i < SoldierUpText.Length; i++)
                    {
                        if (i == 3)
                        {
                            SoldierUpText[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpText[i].gameObject.SetActive(false);
                    }
                    SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[1];
                    SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[1] * 1.2) + " / " + (int)(resources.SoldierUp[1] * 1.2);
                    if (resources.SoldierUp[1] < 3)
                    {
                        SoldierUpText[3].text = 12000.ToString();
                    }
                    else if (resources.SoldierUp[1] >= 3 && resources.SoldierUp[1] < 7)
                    {
                        SoldierUpText[3].text = 40000.ToString();
                    }
                    else if (resources.SoldierUp[1] >= 7 && resources.SoldierUp[1] < 10)
                    {
                        SoldierUpText[3].text = 80000.ToString();
                    }
                    else if (resources.SoldierUp[1] == 10)
                    {
                        SoldierUpText[3].text = "한계 도달";
                    }
                }
                break;
            case 2:
                if (!isLock[1])
                {
                    SoldierupFrame.gameObject.SetActive(true);
                    for (int i = 0; i < SoldierUpB.Length; i++)
                    {
                        if (i == 2)
                        {
                            SoldierUpB[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpB[i].gameObject.SetActive(false);
                    }
                    for (int i = 2; i < SoldierUpText.Length; i++)
                    {
                        if (i == 4)
                        {
                            SoldierUpText[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpText[i].gameObject.SetActive(false);
                    }
                    SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[2];
                    SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[2] * 1.2) + " / " + (int)(resources.SoldierUp[2] * 1.7);
                    if (resources.SoldierUp[2] < 3)
                    {
                        SoldierUpText[4].text = 20000.ToString();
                    }
                    else if (resources.SoldierUp[2] >= 3 && resources.SoldierUp[2] < 7)
                    {
                        SoldierUpText[4].text = 56000.ToString();
                    }
                    else if (resources.SoldierUp[2] >= 7 && resources.SoldierUp[2] < 10)
                    {
                        SoldierUpText[4].text = 89000.ToString();
                    }
                    else if (resources.SoldierUp[2] == 10)
                    {
                        SoldierUpText[4].text = "한계 도달";
                    }
                }
                break;
            case 3:
                if (!isLock[2])
                {
                    SoldierupFrame.gameObject.SetActive(true);
                    for (int i = 0; i < SoldierUpB.Length; i++)
                    {
                        if (i == 3)
                        {
                            SoldierUpB[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpB[i].gameObject.SetActive(false);
                    }
                    for (int i = 2; i < SoldierUpText.Length; i++)
                    {
                        if (i == 5)
                        {
                            SoldierUpText[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpText[i].gameObject.SetActive(false);
                    }
                    SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[3];
                    SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[3] * 1.6) + " / " + (int)(resources.SoldierUp[3] * 1.4);
                    if (resources.SoldierUp[3] < 3)
                    {
                        SoldierUpText[5].text = 30000.ToString();
                    }
                    else if (resources.SoldierUp[3] >= 3 && resources.SoldierUp[3] < 7)
                    {
                        SoldierUpText[5].text = 67000.ToString();
                    }
                    else if (resources.SoldierUp[3] >= 7 && resources.SoldierUp[3] < 10)
                    {
                        SoldierUpText[5].text = 95000.ToString();
                    }
                    else if (resources.SoldierUp[3] == 10)
                    {
                        SoldierUpText[5].text = "한계 도달";
                    }
                }
                break;
            case 4:
                if (!isLock[3])
                {
                    SoldierupFrame.gameObject.SetActive(true);
                    for (int i = 0; i < SoldierUpB.Length; i++)
                    {
                        if (i == 4)
                        {
                            SoldierUpB[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpB[i].gameObject.SetActive(false);
                    }
                    for (int i = 2; i < SoldierUpText.Length; i++)
                    {
                        if (i == 6)
                        {
                            SoldierUpText[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpText[i].gameObject.SetActive(false);
                    }
                    SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[4];
                    SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[4] * 2) + " / " + (int)(resources.SoldierUp[4] * 1.1);
                    if (resources.SoldierUp[4] < 3)
                    {
                        SoldierUpText[6].text = 45000.ToString();
                    }
                    else if (resources.SoldierUp[4] >= 3 && resources.SoldierUp[4] < 7)
                    {
                        SoldierUpText[6].text = 80000.ToString();
                    }
                    else if (resources.SoldierUp[4] >= 7 && resources.SoldierUp[4] < 10)
                    {
                        SoldierUpText[6].text = 120000.ToString();
                    }
                    else if (resources.SoldierUp[4] == 10)
                    {
                        SoldierUpText[6].text = "한계 도달";
                    }
                }
                break;
            case 5:
                if (!isLock[4])
                {
                    SoldierupFrame.gameObject.SetActive(true);
                    for (int i = 0; i < SoldierUpB.Length; i++)
                    {
                        if (i == 5)
                        {
                            SoldierUpB[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpB[i].gameObject.SetActive(false);
                    }
                    for (int i = 2; i < SoldierUpText.Length; i++)
                    {
                        if (i == 7)
                        {
                            SoldierUpText[i].gameObject.SetActive(true);
                            continue;
                        }
                        SoldierUpText[i].gameObject.SetActive(false);
                    }
                    SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[5];
                    SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[5] * 2) + " / " + (int)(resources.SoldierUp[5] * 2);
                    if (resources.SoldierUp[5] < 3)
                    {
                        SoldierUpText[7].text = 66000.ToString();
                    }
                    else if (resources.SoldierUp[5] >= 3 && resources.SoldierUp[5] < 7)
                    {
                        SoldierUpText[7].text = 130000.ToString();
                    }
                    else if (resources.SoldierUp[5] >= 7 && resources.SoldierUp[5] < 10)
                    {
                        SoldierUpText[7].text = 180000.ToString();
                    }
                    else if (resources.SoldierUp[5] == 10)
                    {
                        SoldierUpText[7].text = "한계 도달";
                    }
                }
                break;
        }
    }

    public void NextSoldier()
    {
        switch (soldiernum)
        {
            case SoldierNum.First:
                soldiernum = SoldierNum.Second;
                SoldierupFrame.gameObject.SetActive(false);
                UnLockSoldierFrame.gameObject.SetActive(false);
                for (int i = 0; i < SoldierClick_Up.Length; i++)
                {
                    SoldierClick_Up[i].gameObject.SetActive(false);
                    if (!(i == 1))
                    {
                        SoldierClick_Up[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        SoldierClick_Up[i].gameObject.SetActive(true);
                    }
                }
                break;
            case SoldierNum.Second:
                soldiernum = SoldierNum.Third;
                SoldierupFrame.gameObject.SetActive(false);
                UnLockSoldierFrame.gameObject.SetActive(false);
                for (int i = 0; i < SoldierClick_Up.Length; i++)
                {
                    SoldierClick_Up[i].gameObject.SetActive(false);
                    if (!(i == 2))
                    {
                        SoldierClick_Up[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        SoldierClick_Up[i].gameObject.SetActive(true);

                    }
                }
                break;
            case SoldierNum.Third:
                soldiernum = SoldierNum.Fourth;
                SoldierupFrame.gameObject.SetActive(false);
                UnLockSoldierFrame.gameObject.SetActive(false);
                for (int i = 0; i < SoldierClick_Up.Length; i++)
                {
                    SoldierClick_Up[i].gameObject.SetActive(false);
                    if (!(i == 3))
                    {
                        SoldierClick_Up[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        SoldierClick_Up[i].gameObject.SetActive(true);
                    }
                }
                break;
            case SoldierNum.Fourth:
                soldiernum = SoldierNum.Fifth;
                SoldierupFrame.gameObject.SetActive(false);
                UnLockSoldierFrame.gameObject.SetActive(false);
                for (int i = 0; i < SoldierClick_Up.Length; i++)
                {
                    SoldierClick_Up[i].gameObject.SetActive(false);
                    if (!(i == 4))
                    {
                        SoldierClick_Up[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        SoldierClick_Up[i].gameObject.SetActive(true);
                    }
                }
                break;
            case SoldierNum.Fifth:
                soldiernum = SoldierNum.Sixth;
                SoldierupFrame.gameObject.SetActive(false);
                UnLockSoldierFrame.gameObject.SetActive(false);
                for (int i = 0; i < SoldierClick_Up.Length; i++)
                {
                    SoldierClick_Up[i].gameObject.SetActive(false);
                    if (!(i == 5))
                    {
                        SoldierClick_Up[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        SoldierClick_Up[i].gameObject.SetActive(true);
                    }
                }
                break;
            case SoldierNum.Sixth:
                soldiernum = SoldierNum.First;
                SoldierupFrame.gameObject.SetActive(false);
                UnLockSoldierFrame.gameObject.SetActive(false);
                for (int i = 0; i < SoldierClick_Up.Length; i++)
                {
                    SoldierClick_Up[i].gameObject.SetActive(false);
                    if (!(i == 0))
                    {
                        SoldierClick_Up[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        SoldierClick_Up[i].gameObject.SetActive(true);
                    }
                }
                break;
        }
    }

    public void SoldierUpClose()
    {
        SoldierupFrame.gameObject.SetActive(false);
    }

    public void UpgradeSoldier(int num)
    {
        switch (num)
        {
            case 0:
                if (resources.SoldierUp[0] < 3)
                {
                    if (resources.resources[0] >= 10000)
                    {
                        resources.resources[0] -= 10000;
                        resources.setResources();
                        resources.SoldierUp[0]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[0] >= 3 && resources.SoldierUp[0] < 7)
                {
                    if (resources.resources[0] >= 35000)
                    {
                        resources.resources[0] -= 35000;
                        resources.setResources();
                        resources.SoldierUp[0]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[0] >= 7 && resources.SoldierUp[0] < 10)
                {
                    if (resources.resources[0] >= 70000)
                    {
                        resources.resources[0] -= 70000;
                        resources.setResources();
                        resources.SoldierUp[0]++;
                        resources.SetSoldierUp();
                    }
                }
                SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[0];
                SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)resources.SoldierUp[0] + " / " + (int)resources.SoldierUp[0];
                if (resources.SoldierUp[0] < 3)
                {
                    SoldierUpText[2].text = 10000.ToString();
                }
                else if (resources.SoldierUp[0] >= 3 && resources.SoldierUp[0] < 7)
                {
                    SoldierUpText[2].text = 35000.ToString();
                }
                else if (resources.SoldierUp[0] >= 7 && resources.SoldierUp[0] < 10)
                {
                    SoldierUpText[2].text = 70000.ToString();
                }
                else if (resources.SoldierUp[0] == 10)
                {
                    SoldierUpText[2].text = "한계 도달";
                }
                break;
            case 1:
                if (resources.SoldierUp[1] < 3)
                {
                    if (resources.resources[0] >= 12000)
                    {
                        resources.resources[0] -= 12000;
                        resources.setResources();
                        resources.SoldierUp[1]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[1] >= 3 && resources.SoldierUp[1] < 7)
                {
                    if (resources.resources[0] >= 40000)
                    {
                        resources.resources[0] -= 40000;
                        resources.setResources();
                        resources.SoldierUp[1]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[1] >= 7 && resources.SoldierUp[1] < 10)
                {
                    if (resources.resources[0] >= 80000)
                    {
                        resources.resources[0] -= 80000;
                        resources.setResources();
                        resources.SoldierUp[1]++;
                        resources.SetSoldierUp();
                    }
                }
                SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[1];
                SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[1] * 1.2) + " / " + (int)(resources.SoldierUp[1] * 1.2);
                if (resources.SoldierUp[1] < 3)
                {
                    SoldierUpText[3].text = 12000.ToString();
                }
                else if (resources.SoldierUp[1] >= 3 && resources.SoldierUp[1] < 7)
                {
                    SoldierUpText[3].text = 40000.ToString();
                }
                else if (resources.SoldierUp[1] >= 7 && resources.SoldierUp[1] < 10)
                {
                    SoldierUpText[3].text = 80000.ToString();
                }
                else if (resources.SoldierUp[1] == 10)
                {
                    SoldierUpText[3].text = "한계 도달";
                }
                break;
            case 2:
                if (resources.SoldierUp[2] < 3)
                {
                    if (resources.resources[0] >= 10000)
                    {
                        resources.resources[0] -= 10000;
                        resources.setResources();
                        resources.SoldierUp[2]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[2] >= 3 && resources.SoldierUp[2] < 7)
                {
                    if (resources.resources[0] >= 35000)
                    {
                        resources.resources[0] -= 35000;
                        resources.setResources();
                        resources.SoldierUp[2]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[2] >= 7 && resources.SoldierUp[2] < 10)
                {
                    if (resources.resources[0] >= 70000)
                    {
                        resources.resources[0] -= 70000;
                        resources.setResources();
                        resources.SoldierUp[2]++;
                        resources.SetSoldierUp();
                    }
                }
                SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[2];
                SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[2] * 1.2) + " / " + (int)(resources.SoldierUp[2] * 1.7);
                if (resources.SoldierUp[2] < 3)
                {
                    SoldierUpText[4].text = 20000.ToString();
                }
                else if (resources.SoldierUp[2] >= 3 && resources.SoldierUp[2] < 7)
                {
                    SoldierUpText[4].text = 56000.ToString();
                }
                else if (resources.SoldierUp[2] >= 7 && resources.SoldierUp[2] < 10)
                {
                    SoldierUpText[4].text = 89000.ToString();
                }
                else if (resources.SoldierUp[2] == 10)
                {
                    SoldierUpText[4].text = "한계 도달";
                }
                break;
            case 3:
                if (resources.SoldierUp[3] < 3)
                {
                    if (resources.resources[0] >= 10000)
                    {
                        resources.resources[0] -= 10000;
                        resources.setResources();
                        resources.SoldierUp[3]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[3] >= 3 && resources.SoldierUp[3] < 7)
                {
                    if (resources.resources[0] >= 35000)
                    {
                        resources.resources[0] -= 35000;
                        resources.setResources();
                        resources.SoldierUp[3]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[3] >= 7 && resources.SoldierUp[3] < 10)
                {
                    if (resources.resources[0] >= 70000)
                    {
                        resources.resources[0] -= 70000;
                        resources.setResources();
                        resources.SoldierUp[3]++;
                        resources.SetSoldierUp();
                    }
                }
                SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[3];
                SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[3] * 1.6) + " / " + (int)(resources.SoldierUp[3] * 1.4);
                if (resources.SoldierUp[3] < 3)
                {
                    SoldierUpText[5].text = 30000.ToString();
                }
                else if (resources.SoldierUp[3] >= 3 && resources.SoldierUp[3] < 7)
                {
                    SoldierUpText[5].text = 67000.ToString();
                }
                else if (resources.SoldierUp[3] >= 7 && resources.SoldierUp[3] < 10)
                {
                    SoldierUpText[5].text = 95000.ToString();
                }
                else if (resources.SoldierUp[3] == 10)
                {
                    SoldierUpText[5].text = "한계 도달";
                }
                break;
            case 4:
                if (resources.SoldierUp[4] < 3)
                {
                    if (resources.resources[0] >= 10000)
                    {
                        resources.resources[0] -= 10000;
                        resources.setResources();
                        resources.SoldierUp[4]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[4] >= 3 && resources.SoldierUp[4] < 7)
                {
                    if (resources.resources[0] >= 35000)
                    {
                        resources.resources[0] -= 35000;
                        resources.setResources();
                        resources.SoldierUp[4]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[4] >= 7 && resources.SoldierUp[4] < 10)
                {
                    if (resources.resources[0] >= 70000)
                    {
                        resources.resources[0] -= 70000;
                        resources.setResources();
                        resources.SoldierUp[4]++;
                        resources.SetSoldierUp();
                    }
                }
                SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[4];
                SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[4] * 2) + " / " + (int)(resources.SoldierUp[4] * 1.1);
                if (resources.SoldierUp[4] < 3)
                {
                    SoldierUpText[6].text = 45000.ToString();
                }
                else if (resources.SoldierUp[4] >= 3 && resources.SoldierUp[4] < 7)
                {
                    SoldierUpText[6].text = 80000.ToString();
                }
                else if (resources.SoldierUp[4] >= 7 && resources.SoldierUp[4] < 10)
                {
                    SoldierUpText[6].text = 120000.ToString();
                }
                else if (resources.SoldierUp[4] == 10)
                {
                    SoldierUpText[6].text = "한계 도달";
                }
                break;
            case 5:
                if (resources.SoldierUp[5] < 3)
                {
                    if (resources.resources[0] >= 10000)
                    {
                        resources.resources[0] -= 10000;
                        resources.setResources();
                        resources.SoldierUp[5]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[5] >= 3 && resources.SoldierUp[5] < 7)
                {
                    if (resources.resources[0] >= 35000)
                    {
                        resources.resources[0] -= 35000;
                        resources.setResources();
                        resources.SoldierUp[5]++;
                        resources.SetSoldierUp();
                    }
                }
                else if (resources.SoldierUp[5] >= 7 && resources.SoldierUp[5] < 10)
                {
                    if (resources.resources[0] >= 70000)
                    {
                        resources.resources[0] -= 70000;
                        resources.setResources();
                        resources.SoldierUp[5]++;
                        resources.SetSoldierUp();
                    }
                }
                SoldierUpText[0].text = "현재 업그레이드 : " + resources.SoldierUp[5];
                SoldierUpText[1].text = "추가 공격력 / 체력 : " + (int)(resources.SoldierUp[5] * 2) + " / " + (int)(resources.SoldierUp[5] * 2);
                if (resources.SoldierUp[5] < 3)
                {
                    SoldierUpText[7].text = 66000.ToString();
                }
                else if (resources.SoldierUp[5] >= 3 && resources.SoldierUp[5] < 7)
                {
                    SoldierUpText[7].text = 130000.ToString();
                }
                else if (resources.SoldierUp[5] >= 7 && resources.SoldierUp[5] < 10)
                {
                    SoldierUpText[7].text = 180000.ToString();
                }
                else if (resources.SoldierUp[5] == 10)
                {
                    SoldierUpText[7].text = "한계 도달";
                }
                break;
        }
    }

    public void Touch_ArrangementPos_Ballistar(int num)
    {
        switch (num)
        {
            case 0:
                if (!iscreate_Ballistar[0].isCreate_Ballistar)
                {
                    SelectBallistar.gameObject.SetActive(true);
                    SelectBallistar.gameObject.transform.position = ArrangementPos_Ballistar[0].position;
                    ButtonPos_Ballistar = CreatePos_Ballistar[0].transform;
                    CloseTouchButton_Ballistar = TouchButtonImage_Ballistar[0];
                    cntis_Ballistar = num;
                }
                break;
            case 1:
                if (!iscreate_Ballistar[1].isCreate_Ballistar)
                {
                    SelectBallistar.gameObject.SetActive(true);
                    SelectBallistar.gameObject.transform.position = ArrangementPos_Ballistar[1].position;
                    ButtonPos_Ballistar = CreatePos_Ballistar[1].transform;
                    CloseTouchButton_Ballistar = TouchButtonImage_Ballistar[1];
                    cntis_Ballistar = num;
                }
                break;
            case 2:
                if (!iscreate_Ballistar[2].isCreate_Ballistar)
                {
                    SelectBallistar.gameObject.SetActive(true);
                    SelectBallistar.gameObject.transform.position = ArrangementPos_Ballistar[2].position;
                    ButtonPos_Ballistar = CreatePos_Ballistar[2].transform;
                    CloseTouchButton_Ballistar = TouchButtonImage_Ballistar[2];
                    cntis_Ballistar = num;
                }
                break;
        }
    }
    public void Close_SelectBallistar()
    {
        SelectBallistar.gameObject.SetActive(false);
    }

    public void SelectBallistar_Button()
    {
        if (canArrangement)
        {
            GameObject obj = Instantiate(Ballistar, ButtonPos_Ballistar.position, Quaternion.identity);
            obj.GetComponent<Ballistar>().enemyPos = enemyManager.GetComponent<EnemyManager>().EnemyPool;
            obj.GetComponent<Ballistar>().bd = bd;
            obj.GetComponent<Ballistar>().firepos = obj.transform.GetChild(0);
            SelectBallistar.gameObject.SetActive(false);
            CloseTouchButton_Ballistar.color = new Color(CloseTouchButton_Ballistar.color.r, CloseTouchButton_Ballistar.color.g, CloseTouchButton_Ballistar.color.b, 0f);
            iscreate_Ballistar[cntis_Ballistar].isCreate_Ballistar = true;
            canArrangementcnt++;
            soldierText.text = canArrangementcnt + " / " + canArrangementMax;
            if (canArrangementcnt == canArrangementMax)
            {
                canArrangement = false;
            }
        }
    }

    public void Click_Arrangement_Weapon()
    {
        Click_arrangement_weapon.gameObject.SetActive(true);
    }

    public void Close_Arrangement_Weapon()
    {
        Click_arrangement_weapon.gameObject.SetActive(false);
    }

    public void Click_Ballistar_Up()
    {
        Click_Ballistar_up.gameObject.SetActive(true);
        BallistarUpText[0].text = "현재 업그레이드 : " + resources.BallistarUp;
        BallistarUpText[1].text = "추가 공격력 : " + (int)(resources.BallistarUp * 2.5);
        if (resources.BallistarUp < 3)
        {
            BallistarUpText[2].text = 50000.ToString();
            BallistarUp_ResourcesText[0].text = "X " + 5;
            BallistarUp_ResourcesText[1].text = "X " + 3;
        }
        else if (resources.BallistarUp >= 3 && resources.BallistarUp < 7)
        {
            BallistarUpText[2].text = 80000.ToString();
            BallistarUp_ResourcesText[0].text = "X " + 15;
            BallistarUp_ResourcesText[1].text = "X " + 8;
            BallistarUp_ResourcesText[2].text = "X " + 5;
            BallistarUp_ResourcesText[3].text = "X " + 3;
        }
        else if (resources.BallistarUp >= 7 && resources.BallistarUp < 10)
        {
            BallistarUpText[2].text = 120000.ToString();
            BallistarUp_ResourcesText[0].text = "X " + 50;
            BallistarUp_ResourcesText[1].text = "X " + 30;
            BallistarUp_ResourcesText[2].text = "X " + 20;
            BallistarUp_ResourcesText[3].text = "X " + 15;
            BallistarUp_ResourcesText[4].text = "X " + 5;

        }
        else if (resources.BallistarUp == 10)
        {
            BallistarUpText[2].text = "한계 도달";
            BallistarUp_ResourcesText[0].text = "X OO";
            BallistarUp_ResourcesText[1].text = "X OO";
            BallistarUp_ResourcesText[2].text = "X OO";
            BallistarUp_ResourcesText[3].text = "X OO";
            BallistarUp_ResourcesText[4].text = "X OO";
        }
    }

    public void Close_Ballistar_Up()
    {
        Click_Ballistar_up.gameObject.SetActive(false);
    }

    public void Ballistar_Upgrade()
    {
        if (resources.BallistarUp < 3)
        {
            if (resources.resources[0] >= 50000 && resources.resources[1] >= 5 && resources.resources[2] >= 3)
            {
                resources.resources[0] -= 50000;
                resources.resources[1] -= 5;
                resources.resources[2] -= 3;
                resources.setResources();
                resources.BallistarUp++;
                resources.SetBallistarUp();
            }
        }
        else if ((resources.BallistarUp >= 3 && resources.BallistarUp < 7) && resources.resources[1] >= 15 && resources.resources[2] >= 8 && resources.resources[3] >= 5 && resources.resources[4] >= 3)
        {
            if (resources.resources[0] >= 80000)
            {
                resources.resources[0] -= 80000;
                resources.resources[1] -= 15;
                resources.resources[2] -= 8;
                resources.resources[3] -= 5;
                resources.resources[4] -= 3;
                resources.setResources();
                resources.BallistarUp++;
                resources.SetBallistarUp();
            }
        }
        else if ((resources.BallistarUp >= 7 && resources.BallistarUp < 10) && resources.resources[1] >= 50 && resources.resources[2] >= 30 && resources.resources[3] >= 20 && resources.resources[4] >= 15 && resources.resources[5] >= 5)
        {
            if (resources.resources[0] >= 120000)
            {
                resources.resources[0] -= 120000;
                resources.resources[1] -= 50;
                resources.resources[2] -= 30;
                resources.resources[3] -= 20;
                resources.resources[4] -= 15;
                resources.resources[5] -= 5;
                resources.setResources();
                resources.BallistarUp++;
                resources.SetBallistarUp();
            }
        }
        BallistarUpText[0].text = "현재 업그레이드 : " + resources.BallistarUp;
        BallistarUpText[1].text = "추가 공격력 : " + (int)(resources.BallistarUp * 2.5);
        if (resources.BallistarUp < 3)
        {
            BallistarUpText[2].text = 50000.ToString();
            BallistarUp_ResourcesText[0].text = "X " + 5;
            BallistarUp_ResourcesText[1].text = "X " + 3;
        }
        else if (resources.BallistarUp >= 3 && resources.BallistarUp < 7)
        {
            BallistarUpText[2].text = 80000.ToString();
            BallistarUp_ResourcesText[0].text = "X " + 15;
            BallistarUp_ResourcesText[1].text = "X " + 8;
            BallistarUp_ResourcesText[2].text = "X " + 5;
            BallistarUp_ResourcesText[3].text = "X " + 3;
        }
        else if (resources.BallistarUp >= 7 && resources.BallistarUp < 10)
        {
            BallistarUpText[2].text = 120000.ToString();
            BallistarUp_ResourcesText[0].text = "X " + 50;
            BallistarUp_ResourcesText[1].text = "X " + 30;
            BallistarUp_ResourcesText[2].text = "X " + 20;
            BallistarUp_ResourcesText[3].text = "X " + 15;
            BallistarUp_ResourcesText[4].text = "X " + 5;
        }
        else if (resources.BallistarUp == 10)
        {
            BallistarUpText[2].text = "한계 도달";
            BallistarUp_ResourcesText[0].text = "X OO";
            BallistarUp_ResourcesText[1].text = "X OO";
            BallistarUp_ResourcesText[2].text = "X OO";
            BallistarUp_ResourcesText[3].text = "X OO";
            BallistarUp_ResourcesText[4].text = "X OO";
        }
    }

    public void Click_Meteor()
    {
        if (Meteor_delay.fillAmount <= 0)
        {
            int cnt = 6;
            Meteor_delay.fillAmount = 1f;
            StartCoroutine(MakeMeteor(cnt));
        }
    }

    IEnumerator MakeMeteor(int cnt)
    {
        if (cnt <= 0)
        {
            yield break;
        }
        cnt--;
        Instantiate(Meteorobj, new Vector3(Random.Range(-12f, 4f), 8f, 0f), Meteorobj.transform.rotation);
        yield return new WaitForSeconds(0.2f);

        StartCoroutine(MakeMeteor(cnt));
    }

    public void UnLockSoldier(int num)
    {
        switch (num)
        {
            case 0:
                if (isLock[0])
                {
                    UnLockSoldierFrame.gameObject.SetActive(true);
                    for (int i = 0; i < UnLockSoldierButton.Length; i++)
                    {
                        if (i == 0)
                        {
                            UnLockSoldierButton[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierButton[i].gameObject.SetActive(false);
                    }
                    for (int i = 0; i < UnLockSoldierText.Length; i++)
                    {
                        if (i == 0)
                        {
                            UnLockSoldierText[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierText[i].gameObject.SetActive(false);
                    }
                    UnLockSoldierText[0].text = "25000";
                }
                break;
            case 1:
                if (isLock[1])
                {
                    UnLockSoldierFrame.gameObject.SetActive(true);
                    for (int i = 0; i < UnLockSoldierButton.Length; i++)
                    {
                        if (i == 1)
                        {
                            UnLockSoldierButton[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierButton[i].gameObject.SetActive(false);
                    }
                    for (int i = 0; i < UnLockSoldierText.Length; i++)
                    {
                        if (i == 1)
                        {
                            UnLockSoldierText[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierText[i].gameObject.SetActive(false);
                    }
                    UnLockSoldierText[1].text = "50000";
                }
                break;
            case 2:
                if (isLock[2])
                {
                    UnLockSoldierFrame.gameObject.SetActive(true);
                    for (int i = 0; i < UnLockSoldierButton.Length; i++)
                    {
                        if (i == 2)
                        {
                            UnLockSoldierButton[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierButton[i].gameObject.SetActive(false);
                    }
                    for (int i = 0; i < UnLockSoldierText.Length; i++)
                    {
                        if (i == 2)
                        {
                            UnLockSoldierText[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierText[i].gameObject.SetActive(false);
                    }
                    UnLockSoldierText[2].text = "80000";
                }
                break;
            case 3:
                if (isLock[3])
                {
                    UnLockSoldierFrame.gameObject.SetActive(true);
                    for (int i = 0; i < UnLockSoldierButton.Length; i++)
                    {
                        if (i == 3)
                        {
                            UnLockSoldierButton[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierButton[i].gameObject.SetActive(false);
                    }
                    for (int i = 0; i < UnLockSoldierText.Length; i++)
                    {
                        if (i == 3)
                        {
                            UnLockSoldierText[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierText[i].gameObject.SetActive(false);
                    }
                    UnLockSoldierText[3].text = "150000";
                }
                break;
            case 4:
                if (isLock[4])
                {
                    UnLockSoldierFrame.gameObject.SetActive(true);
                    for (int i = 0; i < UnLockSoldierButton.Length; i++)
                    {
                        if (i == 4)
                        {
                            UnLockSoldierButton[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierButton[i].gameObject.SetActive(false);
                    }
                    for (int i = 0; i < UnLockSoldierText.Length; i++)
                    {
                        if (i == 4)
                        {
                            UnLockSoldierText[i].gameObject.SetActive(true);
                            continue;
                        }
                        UnLockSoldierText[i].gameObject.SetActive(false);
                    }
                    UnLockSoldierText[4].text = "300000";
                }
                break;
        }
    }

    public void Close_UnLockSoldier()
    {
        UnLockSoldierFrame.gameObject.SetActive(false);
    }

    public void UnLockSoldierButtons(int num)
    {
        switch (num)
        {
            case 0:
                if (resources.resources[0] >= 25000)
                {
                    UnLockSoldierFrame.gameObject.SetActive(false);
                    resources.resources[0] -= 25000;
                    resources.setResources();
                    resources.SoldierLock[0] = 1;
                    resources.SetSoldierLock();
                    isLock[0] = false;
                }
                break;
            case 1:
                if (resources.resources[0] >= 50000)
                {
                    UnLockSoldierFrame.gameObject.SetActive(false);
                    resources.resources[0] -= 50000;
                    resources.setResources();
                    resources.SoldierLock[1] = 1;
                    resources.SetSoldierLock();
                    isLock[1] = false;
                }
                break;
            case 2:
                if (resources.resources[0] >= 80000)
                {
                    UnLockSoldierFrame.gameObject.SetActive(false);
                    resources.resources[0] -= 80000;
                    resources.setResources();
                    resources.SoldierLock[2] = 1;
                    resources.SetSoldierLock();
                    isLock[2] = false;
                }
                break;
            case 3:
                if (resources.resources[0] >= 150000)
                {
                    UnLockSoldierFrame.gameObject.SetActive(false);
                    resources.resources[0] -= 150000;
                    resources.setResources();
                    resources.SoldierLock[3] = 1;
                    resources.SetSoldierLock();
                    isLock[3] = false;
                }
                break;
            case 4:
                if (resources.resources[0] >= 300000)
                {
                    UnLockSoldierFrame.gameObject.SetActive(false);
                    resources.resources[0] -= 300000;
                    resources.setResources();
                    resources.SoldierLock[4] = 1;
                    resources.SetSoldierLock();
                    isLock[4] = false;
                }
                break;
        }
    }
}
