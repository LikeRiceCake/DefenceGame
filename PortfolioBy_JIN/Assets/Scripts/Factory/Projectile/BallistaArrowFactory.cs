using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrowFactory : ProjectileFactory
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
        
    }

    void Update()
    {
        
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public override GameObject Create(_EProjectileClass_ select)
    {
        switch (select)
        {
            case _EProjectileClass_.epcBallistaArrow:
                obj = ResourceManager.instance.LoadProjectileResource("Prefabs/BallistaArrow");
                break;
            default:
                obj = ResourceManager.instance.LoadProjectileResource("Prefabs/BallistaArrow");
                break;
        }
        return Instantiate(obj);
    }
    //-------------------------------------------- private

    #endregion
}
