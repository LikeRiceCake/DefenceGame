using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFactory : SkillFactory
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
    public override GameObject Create()
    {
        obj = ResourceManager.instance.LoadSkillResource("Prefabs/Meteor");

        return Instantiate(obj);
    }
    //-------------------------------------------- private

    #endregion
}
