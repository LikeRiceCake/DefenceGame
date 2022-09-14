using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons_InCastle : MonoBehaviour
{
    public Image takeSoldier;

    public void goDeffence()
    {
        SceneManager.LoadScene("DeffenceScene");
    }

    public void goOutCastle()
    {
        SceneManager.LoadScene("OutCastle");
    }

    public void CloseTakeSoldier()
    {
        takeSoldier.gameObject.SetActive(false);
    }

    public void OpenTakeSoldier()
    {
        takeSoldier.gameObject.SetActive(true);
    }

    // switch (SceneManager.GetActiveScene().buildIndex)
}
