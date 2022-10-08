using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    #region //enumeration//
    public enum _EWeaponClass_
    {
        ewcBallista,
        ewcMax
    }

    public enum _EWeaponStat_
    {
        ewsAttack,
        ewsMax
    }

    protected IEnumerator coroutine;
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //constant//
    //-------------------------------------------- public
    public const int EnemyLayerMask = 6;

    public static readonly float[] WeaponIncreaseAttack = { 1.5f };

    public const float EyeSight = 10f;
    //-------------------------------------------- private

    #endregion

    #region //struct//
    protected struct _stat
    {
        public int Attack;
        public float Speed;
        public float RateOfFire;
    }
    protected _stat stat;
    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    protected WeaponInfo weaponStat;

    protected Collider2D opponent;

    protected GameObject projectile;

    protected LayerMask layerMask;

    protected ButtonManager buttonManager;

    protected ResourceManager resourceManager;

    protected DataManager dataManager;
    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        buttonManager = ButtonManager.instance;
        resourceManager = ResourceManager.instance;
        dataManager = DataManager.instance;
    }

    void Start()
    {
        DataInit();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public virtual void DataInit()
    {
        weaponStat = GetComponent<WeaponInfoPocket>().weaponStat;

        coroutine = ShootTheWeapon();

        layerMask = EnemyLayerMask;

        StatInit();
    }

    public void StatInit()
    {
        stat.Attack = weaponStat.Attack + UpgradeStat(_EWeaponStat_.ewsAttack);
        stat.Speed = weaponStat.Speed;
        stat.RateOfFire = weaponStat.RateOfFire;
    }

    public void FindOpponent()
    {
        if (opponent == null)
        {
            opponent = Physics2D.OverlapCircle(transform.position, EyeSight, layerMask);
            if (opponent != null)
            {
                StartCoroutine(coroutine);
            }
        }
    }

    public abstract int UpgradeStat(_EWeaponStat_ select);

    public abstract IEnumerator ShootTheWeapon();
    //-------------------------------------------- private

    #endregion
}
