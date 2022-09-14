using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Main : MonoBehaviour
{
    public void ClickStart_Main()
    {
        SceneManager.LoadScene("InCastle");
    }

}
