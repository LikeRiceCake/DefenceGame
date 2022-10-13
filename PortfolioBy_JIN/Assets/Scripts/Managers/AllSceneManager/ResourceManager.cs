using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    #region //class//
    Dictionary<string, AudioClip> audioResource = new Dictionary<string, AudioClip>();
    Dictionary<string, GameObject> characterResource = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> weaponResource = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> projectileResource = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> skillResource = new Dictionary<string, GameObject>();
    Dictionary<string, Sprite> spriteResource = new Dictionary<string, Sprite>();
    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }
    #endregion

    #region //function//
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

    public GameObject LoadSkillResource(string _key)
    {
        if (skillResource.ContainsKey(_key))
            return skillResource[_key];
        else
        {
            skillResource.Add(_key, Resources.Load<GameObject>(_key));
            return skillResource[_key];
        }
    }

    public Sprite LoadSpriteResource(string _key)
    {
        if (spriteResource.ContainsKey(_key))
            return spriteResource[_key];
        else
        {
            spriteResource.Add(_key, Resources.Load<Sprite>(_key));
            return spriteResource[_key];
        }
    }
    #endregion
}
