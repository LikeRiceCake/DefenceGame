using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileFactory : MonoBehaviour
{
    #region //enumeration//
    public enum _EProjectileClass_
    {
        epcBallistaArrow,
        ewcMax
    }
    #endregion

    #region //class//
    protected GameObject obj;

    protected ResourceManager resourceManager;
    #endregion

    #region //unityLifeCycle//
    void Start()
    {
        DataInit();
    }
    #endregion

    #region //function//
    public void DataInit()
    {
        resourceManager = ResourceManager.instance;
    }

    public abstract GameObject Create(_EProjectileClass_ select);
    #endregion
}
