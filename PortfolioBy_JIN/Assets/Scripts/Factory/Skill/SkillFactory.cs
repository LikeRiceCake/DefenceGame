using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillFactory : MonoBehaviour
{
    #region //enumeration//
    public enum _ESkillClass_
    {
        escMeteor,
        escMax
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
    public abstract GameObject Create(_ESkillClass_ select);
    //-------------------------------------------- private

    #endregion
}
