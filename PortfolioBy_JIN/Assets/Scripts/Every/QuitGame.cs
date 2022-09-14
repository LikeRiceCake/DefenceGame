using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public GameObject QuitFrame;

    bool isQuit;

    void Start()
    {
        isQuit = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isQuit)
            {
                Time.timeScale = 0f;
                QuitFrame.gameObject.SetActive(true);
                isQuit = true;
            }
            else
            {
                Time.timeScale = 1f;
                QuitFrame.gameObject.SetActive(false);
                isQuit = false;
            }
        }
    }

    public void InputQuitKey()
    {
        Application.Quit();
    }
}
