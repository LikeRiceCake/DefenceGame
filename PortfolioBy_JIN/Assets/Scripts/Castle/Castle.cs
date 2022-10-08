using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    #region //enumeration//
    public enum _ECastleStat_
    {
        ecsHp,
        ecsDefence,
        ecsMax
    }
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //constant//
    //-------------------------------------------- public
    public const float CastleIncreaseHp = 10f;
    public const float CastleIncreaseDefence = 1.5f;
    //-------------------------------------------- private

    #endregion

    #region //struct//
    protected struct _stat
    {
        public int MaxHp;
        public int CurrentHp;
        public int Defence;
    }
    protected _stat stat;
    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    CastleInfo castleStat;

    ButtonManager buttonManager;
    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        buttonManager = ButtonManager.instance;
    }

    void Start()
    {
        DataInit();
    }

    void Update()
    {
        if (buttonManager.isCastleUpgraded)
        {
            buttonManager.isCastleUpgraded = false;
            StatInit();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        castleStat = GetComponent<CastleInfoPocket>().castleStat;

        StatInit();
    }

    public void StatInit()
    {
        stat.MaxHp = castleStat.MaxHp + UpgradeStat(_ECastleStat_.ecsHp);
        stat.CurrentHp = stat.MaxHp;
        stat.Defence = castleStat.Defence + UpgradeStat(_ECastleStat_.ecsDefence);
    }
    
    public int UpgradeStat(_ECastleStat_ select)
    {
        switch (select)
        {
            case _ECastleStat_.ecsHp:
                return (int)(stat.MaxHp * CastleIncreaseHp);
            case _ECastleStat_.ecsDefence:
                return (int)(stat.Defence * CastleIncreaseDefence);
            default:
                return 0;
        }
    }

    public void Attacked(int _damage)
    {
        stat.CurrentHp -= _damage;
        if (stat.CurrentHp <= 0)
        {
            // ���� ����
        }
    }
    //-------------------------------------------- private

    #endregion
}