using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown : MonoBehaviour
{
    public Buttons_Deffnece bd;
    public portPlayerPrefs data;

    void OnApplicationQuit()
    {
        if(bd.isBackRound)
        {
            bd.isBackRound = false;
            data.round++;
            data.setRound();
        }
    }
}
