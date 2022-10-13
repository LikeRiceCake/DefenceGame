using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    #region //enumeration//
    public enum _EDefenceResult_
    {
        edrVictory,
        edrDefeat,
        edrMax
    }
    #endregion

    #region //class//
    UIManager uiManager;

    DataManager dataManager;
    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        uiManager = UIManager.instance;
        dataManager = DataManager.instance;
    }
    #endregion

    #region //function//
    public void Defeat()
    {
        uiManager.SetFrameEndDefence(_EDefenceResult_.edrDefeat);
        SoundManager.instance.SetSFXEndDefence(_EDefenceResult_.edrDefeat);
        SoundManager.instance.PlayAudioSFX();
        uiManager.EndDefenceFrameOn();
    }

    public void Victory()
    {
        if (PrepareManager.instance.isPreviousRound)
            PrepareManager.instance.isPreviousRound = false;
        dataManager.myUserInfo.m_nWave++;
        uiManager.SetFrameEndDefence(_EDefenceResult_.edrVictory);
        SoundManager.instance.SetSFXEndDefence(_EDefenceResult_.edrVictory);
        SoundManager.instance.PlayAudioSFX();
        dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] += (int)(dataManager.myUserInfo.m_nWave * 500 * 2f);
        uiManager.SetTextResourceUI(DataManager._EResource_.erMoney);
        uiManager.EndDefenceFrameOn();
    }
    #endregion
}