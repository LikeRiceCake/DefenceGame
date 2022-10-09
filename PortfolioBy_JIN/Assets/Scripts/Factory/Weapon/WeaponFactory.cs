using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFactory : MonoBehaviour
{
    #region //enumeration//
    public enum _EWeaponClass_
    {
        ewcBallista,
        ewcMax
    }
    #endregion

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
    protected GameObject obj;
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
    public abstract GameObject Create(_EWeaponClass_ select);
    //-------------------------------------------- private

    #endregion
}
