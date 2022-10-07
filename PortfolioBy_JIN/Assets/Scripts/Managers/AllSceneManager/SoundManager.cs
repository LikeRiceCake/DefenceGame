using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
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

    GameManager gameManager;

    ResourceManager resourceManager;

    AudioClip currentAudioClip;

    AudioSource audioSource;
    #endregion

    #region //property//

    #endregion

    #region //unityLifeCycle//
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        gameManager = GameManager.instance;
        resourceManager = ResourceManager.instance;
    }

    #endregion

    #region //function//
    //-------------------------------------------- public
    public void SceneLoadedSounds()
    {
        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                audioSource = GetComponent<AudioSource>();
                currentAudioClip = resourceManager.LoadAudioResource("Audios/Main");
                break;
            case GameManager._ESceneState_.esInCastle:
                currentAudioClip = resourceManager.LoadAudioResource("Audios/InCastle");
                break;
            case GameManager._ESceneState_.esOutCastle:
                currentAudioClip = resourceManager.LoadAudioResource("Audios/OutCastle");
                break;
            case GameManager._ESceneState_.esDefence:
                currentAudioClip = resourceManager.LoadAudioResource("Audios/Defence");
                break;
            default:
                break;
        }
        SetAudio();
        PlayAudio();
    }

    public void SetAudio()
    {
        audioSource.clip = currentAudioClip;
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }
    //-------------------------------------------- private

    #endregion
}
