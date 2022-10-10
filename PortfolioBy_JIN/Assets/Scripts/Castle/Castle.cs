using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour, IAttacked
{
    #region //enumeration//
    public enum _ECastleStat_
    {
        ecsMaxHp,
        ecsCurrentHp,
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

    UIManager uiManager;
    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        buttonManager = ButtonManager.instance;
        uiManager = UIManager.instance;
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
        stat.MaxHp = castleStat.MaxHp + UpgradeStat(_ECastleStat_.ecsMaxHp);
        stat.CurrentHp = stat.MaxHp;
        stat.Defence = castleStat.Defence + UpgradeStat(_ECastleStat_.ecsDefence);
    }
    
    public int UpgradeStat(_ECastleStat_ select)
    {
        switch (select)
        {
            case _ECastleStat_.ecsMaxHp:
                return (int)(stat.MaxHp * CastleIncreaseHp);
            case _ECastleStat_.ecsDefence:
                return (int)(stat.Defence * CastleIncreaseDefence);
            default:
                return 0;
        }
    }

    public int GetStat(_ECastleStat_ select)
    {
        switch (select)
        {
            case _ECastleStat_.ecsMaxHp:
                return stat.MaxHp;
            case _ECastleStat_.ecsCurrentHp:
                return stat.CurrentHp;
            case _ECastleStat_.ecsDefence:
                return stat.Defence;
            default:
                return 0;
        }
    }

    public Collider2D GetOpponent()
    {
        return GetComponent<Collider2D>();
    }

    public void Attacked(int _damage)
    {
        _damage = _damage <= stat.Defence ? 0 : _damage - stat.Defence;
        stat.CurrentHp -= _damage;
        uiManager.SetImageCastleHp(stat.CurrentHp, stat.MaxHp);
        if (stat.CurrentHp <= 0)
        {
            // 게임 오버
        }
    }
    //-------------------------------------------- private

    #endregion
}
