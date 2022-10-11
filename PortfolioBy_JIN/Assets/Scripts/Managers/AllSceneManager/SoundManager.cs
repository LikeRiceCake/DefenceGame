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

    AudioClip audioClipBGM;
    AudioClip[] audioClipSFX;

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
        SetAudioBGM();
        PlayAudioBGM();
    }

    public void SetAudioSFX()
    {
        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                audioSource = GetComponent<AudioSource>();
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/Main");
                break;
            case GameManager._ESceneState_.esInCastle:
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/InCastle");
                break;
            case GameManager._ESceneState_.esOutCastle:
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/OutCastle");
                break;
            case GameManager._ESceneState_.esDefence:
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/Defence");
                break;
            default:
                break;
        }
    }

    public void PlayAudioSFX()
    {
        
    }

    public void SetAudioBGM()
    {
        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                audioSource = GetComponent<AudioSource>();
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/Main");
                break;
            case GameManager._ESceneState_.esInCastle:
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/InCastle");
                break;
            case GameManager._ESceneState_.esOutCastle:
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/OutCastle");
                break;
            case GameManager._ESceneState_.esDefence:
                audioClipBGM = resourceManager.LoadAudioResource("Audios/BGM/Defence");
                break;
            default:
                break;
        }
    }

    public void PlayAudioBGM()
    {
        audioSource.PlayOneShot(audioClipBGM);
    }
    //-------------------------------------------- private

    #endregion
}
