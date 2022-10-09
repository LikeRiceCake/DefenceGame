using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : Weapon
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

    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    void Start()
    {
        DataInit();
    }

    public override void Update()
    {
        FindOpponent();

        if (buttonManager.isBallistaUpgraded)
        {
            buttonManager.isBallistaUpgraded = false;
            StatInit();
        }

    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public override void DataInit()
    {
        projectileFactory = gameObject.AddComponent<BallistaArrowFactory>();
        base.DataInit();
    }

    public override int UpgradeStat(_EWeaponStat_ select)
    {
        switch (select)
        {
            case _EWeaponStat_.ewsAttack:
                return (int)(dataManager.myUserInfo.m_nWeaponUpgrade[(int)weaponStat.myClass] * WeaponIncreaseAttack[(int)_EWeaponClass_.ewcBallista]);
            default:
                return 0;
        }
    }

    public override IEnumerator ShootTheWeapon()
    {
        print("코루틴 진입");
        while (opponent.gameObject.activeSelf)
        {
            GameObject projectileObj = projectileFactory.Create(ProjectileFactory._EProjectileClass_.epcBallistaArrow);
            projectileObj.transform.position = transform.position;
            projectileObj.GetComponent<BallistaArrow>().target = opponent.GetComponent<Enemy>();
            projectileObj.GetComponent<BallistaArrow>().sAttack = stat.Attack;
            projectileObj.GetComponent<BallistaArrow>().sSpeed = stat.Speed;
            yield return new WaitForSeconds(stat.RateOfFire);
        }

        OpponentRemove();
        print("코루틴 퇴출");
    }
    //-------------------------------------------- private

    #endregion
}
