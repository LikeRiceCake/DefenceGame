using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFactory : SkillFactory
{
    #region //function//
    public override GameObject Create()
    {
        obj = resourceManager.LoadSkillResource("Prefabs/Meteor");

        return Instantiate(obj);
    }
    #endregion
}
