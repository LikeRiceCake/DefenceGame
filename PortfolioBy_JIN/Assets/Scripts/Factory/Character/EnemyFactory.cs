using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : CharacterFactory<EnemyManager._EEnemyClass_>
{
    #region //function//
    public override GameObject Create(EnemyManager._EEnemyClass_ select)
    {
        switch (select)
        {
            case EnemyManager._EEnemyClass_.eecEnemy:
                obj = resourceManager.LoadCharacterResource("Prefabs/Enemy");
                break;
            default:
                obj = resourceManager.LoadCharacterResource("Prefabs/Enemy");
                break;
        }

        return Instantiate(obj);
    }
    #endregion
}
