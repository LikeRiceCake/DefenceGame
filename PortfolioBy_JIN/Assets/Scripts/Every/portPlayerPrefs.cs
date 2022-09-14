using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portPlayerPrefs : MonoBehaviour
{
    public Text[] resourceText = new Text[6];
    public Text[] HireText = new Text[5];
    public Text roundText;
    public Text[] UpgradeText;

    string[] resourcesKey;
    [HideInInspector]
    public int[] resources;

    string roundKey;
    [HideInInspector]
    public int round;

    string[] HireKey;
    [HideInInspector]
    public int[] Hire;

    string[] rTimeKey;
    [HideInInspector]
    public float[] rTime;

    string[] SoldierUpKey;
    [HideInInspector]
    public int[] SoldierUp;

    string Quit_TimeKey;
    [HideInInspector]
    public string Quit_Time;

    string CastleUpKey;
    [HideInInspector]
    public int CastleUp;

    string BallistarUpKey;
    [HideInInspector]
    public int BallistarUp;

    string[] SoldierLockKey;
    public int[] SoldierLock;

    void Awake()
    {
        resources = new int[6];
        Hire = new int[5];
        rTime = new float[5];
        SoldierUp = new int[6];
        SoldierLock = new int[5];

        HireKey = new string[5];
        HireKey[0] = "Hire_Tree";
        HireKey[1] = "Hire_Stone";
        HireKey[2] = "Hire_Iron";
        HireKey[3] = "Hire_Gold";
        HireKey[4] = "Hire_Diamond";

        rTimeKey = new string[5];
        rTimeKey[0] = "LeftChoppingTime";
        rTimeKey[1] = "LeftStoneTime";
        rTimeKey[2] = "LeftIronTime";
        rTimeKey[3] = "LeftGoldTime";
        rTimeKey[4] = "LeftDiamondTime";

        resourcesKey = new string[6];
        resourcesKey[0] = "Money";
        resourcesKey[1] = "Wood";
        resourcesKey[2] = "Stone";
        resourcesKey[3] = "Iron";
        resourcesKey[4] = "Gold";
        resourcesKey[5] = "Diamond";

        SoldierUpKey = new string[6];
        SoldierUpKey[0] = "FirstSoldier";
        SoldierUpKey[1] = "SecondSoldier";
        SoldierUpKey[2] = "ThirdSoldier";
        SoldierUpKey[3] = "FourthSoldier";
        SoldierUpKey[4] = "FifthSoldier";
        SoldierUpKey[5] = "SixthSoldier";

        SoldierLockKey = new string[5];
        SoldierLockKey[0] = "FirstSoldierLock";
        SoldierLockKey[1] = "SecondSoldierLock";
        SoldierLockKey[2] = "ThirdSoldierLock";
        SoldierLockKey[3] = "FourthSoldierLock";
        SoldierLockKey[4] = "FifthSoldierLock";

        roundKey = "Round";

        Quit_TimeKey = "QuitTime";

        CastleUpKey = "CastleUpgrade";

        BallistarUpKey = "BallistarUpgrade";

        getData();

        for (int i = 0; i < resources.Length; i++)
        {
            if (resources[i] == 0)
            {
                resources[i] = 0;
            }
        }
        if (round == 0)
        {
            round = 1;
        }
        for (int i = 0; i < Hire.Length; i++)
        {
            if (Hire[i] == 0)
            {
                Hire[i] = 0;
            }
        }
        for (int i = 0; i < rTime.Length; i++)
        {
            if (rTime[i] == 0)
            {
                rTime[i] = 0;
            }
        }
        if (Quit_Time == "")
        {
            Quit_Time = "저장이 안됐습니다";
        }
        if (CastleUp == 0)
        {
            CastleUp = 0;
        }
        for (int i = 0; i < SoldierUp.Length; i++)
        {
            if (SoldierUp[i] == 0)
            {
                SoldierUp[i] = 0;
            }
        }
        if (BallistarUp == 0)
        {
            BallistarUp = 0;
        }
        for (int i = 0; i < SoldierLock.Length; i++)
        {
            if (SoldierLock[i] == 0)
            {
                SoldierLock[i] = 2;
            }
        }

        Rebuildresources();
    }

    public void setResources()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            PlayerPrefs.SetInt(resourcesKey[i], resources[i]);
        }
        for (int i = 0; i < resources.Length; i++)
        {
            resources[i] = PlayerPrefs.GetInt(resourcesKey[i]);
        }
        Rebuildresources();
    }

    public void setRound()
    {
        PlayerPrefs.SetInt(roundKey, round);
        round = PlayerPrefs.GetInt(roundKey);
        Rebuildresources();
    }

    public void setHire()
    {
        for (int i = 0; i < Hire.Length; i++)
        {
            PlayerPrefs.SetInt(HireKey[i], Hire[i]);
            Hire[i] = PlayerPrefs.GetInt(HireKey[i]);
            Rebuildresources();
        }
    }

    public void SetResources_Time()
    {
        for (int i = 0; i < rTime.Length; i++)
        {
            PlayerPrefs.SetFloat(rTimeKey[i], rTime[i]);
            rTime[i] = PlayerPrefs.GetFloat(rTimeKey[i]);
        }
    }

    public void SetQuit_Time()
    {
        PlayerPrefs.SetString(Quit_TimeKey, Quit_Time);
    }

    public void SetCastleUp()
    {
        PlayerPrefs.SetInt(CastleUpKey, CastleUp);
        Rebuildresources();
    }

    public void SetSoldierUp()
    {
        for (int i = 0; i < SoldierUp.Length; i++)
        {
            PlayerPrefs.SetInt(SoldierUpKey[i], SoldierUp[i]);
        }
    }

    public void SetBallistarUp()
    {
        PlayerPrefs.SetInt(BallistarUpKey, BallistarUp);
    }

    public void SetSoldierLock()
    {
        for (int i = 0; i < SoldierLock.Length; i++)
        {
            PlayerPrefs.SetInt(SoldierLockKey[i], SoldierLock[i]);
        }
    }

    void getData()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            resources[i] = PlayerPrefs.GetInt(resourcesKey[i]);
        }
        for (int i = 0; i < Hire.Length; i++)
        {
            Hire[i] = PlayerPrefs.GetInt(HireKey[i]);
        }
        for (int i = 0; i < rTime.Length; i++)
        {
            rTime[i] = PlayerPrefs.GetFloat(rTimeKey[i]);
        }
        for (int i = 0; i < SoldierUp.Length; i++)
        {
            SoldierUp[i] = PlayerPrefs.GetInt(SoldierUpKey[i]);
        }
        for (int i = 0; i < SoldierLock.Length; i++)
        {
            SoldierLock[i] = PlayerPrefs.GetInt(SoldierLockKey[i]);
        }
        round = PlayerPrefs.GetInt(roundKey);
        Quit_Time = PlayerPrefs.GetString(Quit_TimeKey);
        CastleUp = PlayerPrefs.GetInt(CastleUpKey);
        BallistarUp = PlayerPrefs.GetInt(BallistarUpKey);
        Rebuildresources();
    }

    void Rebuildresources()
    {
        for (int i = 0; i < resourceText.Length; i++)
        {
            if (resourceText[i] == null)
                continue;
            else
                resourceText[i].text = resources[i].ToString();
        }
        if (roundText)
        {
            roundText.text = round.ToString();
        }
        for (int i = 0; i < Hire.Length; i++)
        {
            if (HireText[i])
            {
                HireText[i].text = Hire[i].ToString();
            }
        }
        for (int i = 0; i < UpgradeText.Length; i++)
        {
            if (UpgradeText[i])
            {
                if (CastleUp < 10)
                {
                    UpgradeText[0].text = "현재 업그레이드 : " + CastleUp;
                    UpgradeText[1].text = "성 추가 체력 : " + CastleUp * 10;
                    UpgradeText[2].text = 10000.ToString();
                }
                else if (CastleUp >= 10 && CastleUp < 20)
                {
                    UpgradeText[0].text = "현재 업그레이드 : " + CastleUp;
                    UpgradeText[1].text = "성 추가 체력 : " + CastleUp * 10;
                    UpgradeText[2].text = 30000.ToString();
                }
                else if (CastleUp >= 20 && CastleUp < 30)
                {
                    UpgradeText[0].text = "현재 업그레이드 : " + CastleUp;
                    UpgradeText[1].text = "성 추가 체력 : " + CastleUp * 10;
                    UpgradeText[2].text = 50000.ToString();
                }
            }
        }
    }

    public void testReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
