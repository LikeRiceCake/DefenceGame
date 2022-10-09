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
    public override GameObject Create(_ESoldierClass_ select)
    {
        switch (select)
        {
            case _ESoldierClass_.escNormal:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/NormalSoldier");
                break;
            case _ESoldierClass_.escRare:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/RareSoldier");
                break;
            case _ESoldierClass_.escTank:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/TankSoldier");
                break;
            case _ESoldierClass_.escUniversal:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/UniversalSoldier");
                break;
            case _ESoldierClass_.escAssassin:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/AssassinSoldier");
                break;
            case _ESoldierClass_.escUnknown:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/UnknownSoldier");
                break;
            default:
                obj = ResourceManager.instance.LoadCharacterResource("Prefabs/NormalSoldier");
                break;
        }

        return Instantiate(obj);
    }
    //-------------------------------------------- private

    #endregion
}
