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

    #region //class//
    protected GameObject obj;

    protected ResourceManager resourceManager;
    #endregion
    #region //function//
    public void DataInit()
    {
        resourceManager = ResourceManager.instance;
    }
     
    public abstract GameObject Create(_EWeaponClass_ select);
    #endregion
}
