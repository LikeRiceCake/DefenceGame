using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterFactory<T> : MonoBehaviour
{
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

    public abstract GameObject Create(T select);
    #endregion
}
