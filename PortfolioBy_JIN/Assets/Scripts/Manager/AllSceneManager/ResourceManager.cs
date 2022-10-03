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
    public AudioClip LoadAudioResource(string _Key)
    {
        if (audioResource.ContainsKey(_Key))
            return audioResource[_Key];
        else
        {
            audioResource.Add(_Key, Resources.Load<AudioClip>(_Key));
            return audioResource[_Key];
        }
    }

    //-------------------------------------------- private

    #endregion
}
