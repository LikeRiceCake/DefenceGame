using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Quit : MonoBehaviour
{
    #region //function//
    private void OnApplicationQuit()
    {
        if (PrepareManager.instance.isPreviousRound)
            DataManager.instance.myUserInfo.m_nWave = PrepareManager.instance.previousRound;

        if (GameManager.instance.currentSceneState != GameManager._ESceneState_.esMain)
            DataManager.instance.myUserInfo.m_sQuitTime = DateTime.Now.ToString();

        FirebaseDBManager.instance.WriteUpdateData();
    }
    #endregion
}
