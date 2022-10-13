using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaFactory : WeaponFactory
{
    #region //function//
    public override GameObject Create(_EWeaponClass_ select)
    {
        switch (select)
        {
            case _EWeaponClass_.ewcBallista:
                obj = resourceManager.LoadWeaponResource("Prefabs/Ballista");
                break;
            default:
                obj = resourceManager.LoadWeaponResource("Prefabs/Ballista");
                break;
        }
        return Instantiate(obj);
    }
    #endregion
}
