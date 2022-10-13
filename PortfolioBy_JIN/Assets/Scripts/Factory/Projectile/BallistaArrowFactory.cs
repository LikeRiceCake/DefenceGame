using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrowFactory : ProjectileFactory
{
    #region //function//
    public override GameObject Create(_EProjectileClass_ select)
    {
        switch (select)
        {
            case _EProjectileClass_.epcBallistaArrow:
                obj = resourceManager.LoadProjectileResource("Prefabs/BallistaArrow");
                break;
            default:
                obj = resourceManager.LoadProjectileResource("Prefabs/BallistaArrow");
                break;
        }

        return Instantiate(obj);
    }
    #endregion
}
