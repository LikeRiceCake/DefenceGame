using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaFactory : WeaponFactory
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
    public override GameObject Create(_EWeaponClass_ select)
    {
        switch (select)
        {
            case _EWeaponClass_.ewcBallista:
                obj = ResourceManager.instance.LoadWeaponResource("Prefabs/Ballista");
                break;
            default:
                obj = ResourceManager.instance.LoadWeaponResource("Prefabs/Ballista");
                break;
        }
        return Instantiate(obj);
    }
    //-------------------------------------------- private

    #endregion
}
