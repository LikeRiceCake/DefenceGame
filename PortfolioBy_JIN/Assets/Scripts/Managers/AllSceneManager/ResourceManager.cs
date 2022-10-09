using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
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
    Dictionary<string, AudioClip> audioResource = new Dictionary<string, AudioClip>();
    Dictionary<string, GameObject> characterResource = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> weaponResource = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> projectileResource = new Dictionary<string, GameObject>();
    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public AudioClip LoadAudioResource(string _key)
    {
        if (audioResource.ContainsKey(_key))
            return audioResource[_key];
        else
        {
            audioResource.Add(_key, Resources.Load<AudioClip>(_key));
            return audioResource[_key];
        }
    }

    public GameObject LoadCharacterResource(string _key)
    {
        if (characterResource.ContainsKey(_key))
            return characterResource[_key];
        else
        {
            characterResource.Add(_key, Resources.Load<GameObject>(_key));
            return characterResource[_key];
        }
    }

    public GameObject LoadWeaponResource(string _key)
    {
        if (weaponResource.ContainsKey(_key))
            return weaponResource[_key];
        else
        {
            weaponResource.Add(_key, Resources.Load<GameObject>(_key));
            return weaponResource[_key];
        }
    }

    public GameObject LoadProjectileResource(string _key)
    {
        if (projectileResource.ContainsKey(_key))
            return projectileResource[_key];
        else
        {
            projectileResource.Add(_key, Resources.Load<GameObject>(_key));
            return projectileResource[_key];
        }
    }
    //-------------------------------------------- private

    #endregion
}
