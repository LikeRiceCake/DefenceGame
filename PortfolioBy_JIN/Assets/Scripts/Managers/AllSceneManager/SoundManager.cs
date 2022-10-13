using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public enum _ESound_
    {
        esBGM,
        esSFX,
        esMax
    }

    #region //class//
    GameManager gameManager;

    ResourceManager resourceManager;

    AudioClip[] audioClips;

    AudioSource[] audioSources;
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

        audioSources = new AudioSource[(int)_ESound_.esMax];
        audioClips = new AudioClip[(int)_ESound_.esMax];

        audioSources = GetComponents<AudioSource>();
    }
    #endregion

    #region //function//
    public void SceneLoadedSounds()
    {
        SetAudioBGM();
        PlayAudioBGM();
    }

    public void SetSFXEndDefence(BattleManager._EDefenceResult_ select) // µðÆæ½º°¡ ³¡³µÀ» ¶§ SFX ¼³Á¤
    {
        switch (select)
        {
            case BattleManager._EDefenceResult_.edrVictory:
                SetAudioSFX("Audios/SFX/Victory");
                PlayAudioSFX();
                break;
            case BattleManager._EDefenceResult_.edrDefeat:
                SetAudioSFX("Audios/SFX/Defeat");
                PlayAudioSFX();
                break;
            default:
                break;
        }
    }

    public void SetAudioSFX(string _key)
    {
        audioClips[(int)_ESound_.esSFX] = resourceManager.LoadAudioResource(_key);
    }

    public void PlayAudioSFX()
    {
        audioSources[(int)_ESound_.esSFX].PlayOneShot(audioClips[(int)_ESound_.esSFX]);
    }

    public void SetAudioBGM()
    {
        switch (gameManager.currentSceneState)
        {
            case GameManager._ESceneState_.esMain:
                audioClips[(int)_ESound_.esBGM] = resourceManager.LoadAudioResource("Audios/BGM/Main");
                break;
            case GameManager._ESceneState_.esInCastle:
                audioClips[(int)_ESound_.esBGM] = resourceManager.LoadAudioResource("Audios/BGM/InCastle");
                break;
            case GameManager._ESceneState_.esOutCastle:
                audioClips[(int)_ESound_.esBGM] = resourceManager.LoadAudioResource("Audios/BGM/OutCastle");
                break;
            case GameManager._ESceneState_.esDefence:
                audioClips[(int)_ESound_.esBGM] = resourceManager.LoadAudioResource("Audios/BGM/Defence");
                break;
            default:
                break;
        }

        audioSources[(int)_ESound_.esBGM].clip = audioClips[(int)_ESound_.esBGM];
    }

    public void PlayAudioBGM()
    {
        audioSources[(int)_ESound_.esBGM].Play();
    }
    #endregion
}
