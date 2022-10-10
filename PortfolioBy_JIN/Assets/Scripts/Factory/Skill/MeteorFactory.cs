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
    public override GameObject Create(_ESkillClass_ select)
    {
        switch (select)
        {
            case _ESkillClass_.escMeteor:
                obj = ResourceManager.instance.LoadSkillResource("Prefabs/Meteor");
                break;
            default:
                obj = ResourceManager.instance.LoadSkillResource("Prefabs/Meteor");
                break;
        }

        return Instantiate(obj);
    }
    //-------------------------------------------- private

    #endregion
}
