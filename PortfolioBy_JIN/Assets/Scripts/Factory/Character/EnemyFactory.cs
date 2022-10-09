using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : CharacterFactory<EnemyFactory._EEnemyClass_>
{
    #region //enumeration//
    public enum _EEnemyClass_
    {
        eecEnemy,
        eecMax
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
    public override GameObject Create(_EEnemyClass_ select)
    {
        switch (select)
        {
            case _EEnemyClass_.eecEnemy:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/Enemy");
                break;
            default:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/Enemy");
                break;
        }

        return Instantiate(obj);
    }
    //-------------------------------------------- private

    #endregion
}
