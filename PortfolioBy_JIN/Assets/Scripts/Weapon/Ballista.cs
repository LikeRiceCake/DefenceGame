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

    void Update()
    {
        FindOpponent();

        if(buttonManager.isBallistaUpgraded)
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
        projectile = resourceManager.LoadProjectileResource("Prefabs/Arrow");
        base.DataInit();
    }

    public override IEnumerator ShootTheWeapon()
    {
        if (opponent == null)
            StopCoroutine(coroutine);
        GameObject projectileObj = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileObj.GetComponent<BallistaArrow>().opponent = opponent;
        projectileObj.GetComponent<BallistaArrow>().Attack = stat.Attack;
        projectileObj.GetComponent<BallistaArrow>().Speed = stat.Speed;
        yield return new WaitForSeconds(stat.RateOfFire);
    }
    //-------------------------------------------- private

    #endregion
}
