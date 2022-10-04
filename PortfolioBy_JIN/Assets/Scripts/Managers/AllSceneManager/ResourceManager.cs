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
    //-------------------------------------------- private

    #endregion
}
