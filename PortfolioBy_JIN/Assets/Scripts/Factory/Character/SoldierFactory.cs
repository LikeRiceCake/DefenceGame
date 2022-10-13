using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : CharacterFactory<SoldierFactory._ESoldierClass_>
{
    #region //enumeration//
    public enum _ESoldierClass_
    {
        escNormal,
        escRare,
        escTank,
        escUniversal,
        escAssassin,
        escUnknown,
        escMax
    }
    #endregion

    #region //function//
    public override GameObject Create(_ESoldierClass_ select)
    {
        switch (select)
        {
            case _ESoldierClass_.escNormal:
                obj = resourceManager.LoadCharacterResource("Prefabs/NormalSoldier");
                break;
            case _ESoldierClass_.escRare:
                obj = resourceManager.LoadCharacterResource("Prefabs/RareSoldier");
                break;
            case _ESoldierClass_.escTank:
                obj = resourceManager.LoadCharacterResource("Prefabs/TankSoldier");
                break;
            case _ESoldierClass_.escUniversal:
                obj = resourceManager.LoadCharacterResource("Prefabs/UniversalSoldier");
                break;
            case _ESoldierClass_.escAssassin:
                obj = resourceManager.LoadCharacterResource("Prefabs/AssassinSoldier");
                break;
            case _ESoldierClass_.escUnknown:
                obj = resourceManager.LoadCharacterResource("Prefabs/UnknownSoldier");
                break;
            default:
                obj = resourceManager.LoadCharacterResource("Prefabs/NormalSoldier");
                break;
        }

        return Instantiate(obj);
    }
    #endregion
}
