using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_OutCastle : MonoBehaviour
{
    enum Mineral { Stone, Iron, Gold, Diamond}

    public GameObject forest;
    public GameObject treeTouch;
    
    public GameObject mine;
    public GameObject[] mineralTouch;

    public GameObject[] MineralTouchButton;

    public GameObject[] getText;

    public portPlayerPrefs resources;

    int Max_Hire;

    Mineral mineral;

    private void Start()
    {
        Max_Hire = 5;
        mineral = Mineral.Stone;
    } 

    public void CloseMine()
    {
        mine.gameObject.SetActive(false);
        for (int i = 0; i < mineralTouch.Length; i++)
        {
            mineralTouch[i].gameObject.SetActive(false);
            if(!(i == 0))
            {
                MineralTouchButton[i].gameObject.SetActive(false);
                getText[i].gameObject.SetActive(false);
            }
            else
            {
                MineralTouchButton[i].gameObject.SetActive(true);
                getText[i].gameObject.SetActive(true);
            }
        }
    }

    public void TouchStone()
    {
        getText[0].gameObject.SetActive(true);
        getText[1].gameObject.SetActive(false);
        getText[2].gameObject.SetActive(false);
        getText[3].gameObject.SetActive(false);
        MineralTouchButton[0].gameObject.SetActive(true);
        MineralTouchButton[1].gameObject.SetActive(false);
        MineralTouchButton[2].gameObject.SetActive(false);
        MineralTouchButton[3].gameObject.SetActive(false);
        mineralTouch[0].gameObject.SetActive(true);
        mineralTouch[1].gameObject.SetActive(false);
        mineralTouch[2].gameObject.SetActive(false);
        mineralTouch[3].gameObject.SetActive(false);
    }

    public void TouchIron()
    {
        getText[0].gameObject.SetActive(false);
        getText[1].gameObject.SetActive(true);
        getText[2].gameObject.SetActive(false);
        getText[3].gameObject.SetActive(false);
        MineralTouchButton[0].gameObject.SetActive(false);
        MineralTouchButton[1].gameObject.SetActive(true);
        MineralTouchButton[2].gameObject.SetActive(false);
        MineralTouchButton[3].gameObject.SetActive(false);
        mineralTouch[0].gameObject.SetActive(false);
        mineralTouch[1].gameObject.SetActive(true);
        mineralTouch[2].gameObject.SetActive(false);
        mineralTouch[3].gameObject.SetActive(false);
    }
    public void TouchGold()
    {
        getText[0].gameObject.SetActive(false);
        getText[1].gameObject.SetActive(false);
        getText[2].gameObject.SetActive(true);
        getText[3].gameObject.SetActive(false);
        MineralTouchButton[0].gameObject.SetActive(false);
        MineralTouchButton[1].gameObject.SetActive(false);
        MineralTouchButton[2].gameObject.SetActive(true);
        MineralTouchButton[3].gameObject.SetActive(false);
        mineralTouch[0].gameObject.SetActive(false);
        mineralTouch[1].gameObject.SetActive(false);
        mineralTouch[2].gameObject.SetActive(true);
        mineralTouch[3].gameObject.SetActive(false);
    }
    public void TouchDiamond()
    {
        getText[0].gameObject.SetActive(false);
        getText[1].gameObject.SetActive(false);
        getText[2].gameObject.SetActive(false);
        getText[3].gameObject.SetActive(true);
        MineralTouchButton[0].gameObject.SetActive(false);
        MineralTouchButton[1].gameObject.SetActive(false);
        MineralTouchButton[2].gameObject.SetActive(false);
        MineralTouchButton[3].gameObject.SetActive(true);
        mineralTouch[0].gameObject.SetActive(false);
        mineralTouch[1].gameObject.SetActive(false);
        mineralTouch[2].gameObject.SetActive(false);
        mineralTouch[3].gameObject.SetActive(true);
    }

    public void nextMineral()
    {
        switch (mineral)
        {
            case Mineral.Stone:
                mineral = Mineral.Iron;
                for(int i = 0; i < mineralTouch.Length; i++)
                {
                    mineralTouch[i].gameObject.SetActive(false);
                    if(!(i == 1))
                    {
                        MineralTouchButton[i].gameObject.SetActive(false);
                        getText[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        MineralTouchButton[i].gameObject.SetActive(true);
                        getText[i].gameObject.SetActive(true);
                    }
                }
                break;
            case Mineral.Iron:
                mineral = Mineral.Gold;
                for(int i = 0; i < mineralTouch.Length; i++)
                {
                    mineralTouch[i].gameObject.SetActive(false);
                    if (!(i == 2))
                    {
                        MineralTouchButton[i].gameObject.SetActive(false);
                        getText[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        MineralTouchButton[i].gameObject.SetActive(true);
                        getText[i].gameObject.SetActive(true);
                    }
                }
                break;
            case Mineral.Gold:
                mineral = Mineral.Diamond;
                for(int i = 0; i < mineralTouch.Length; i++)
                {
                    mineralTouch[i].gameObject.SetActive(false);
                    if (!(i == 3))
                    {
                        MineralTouchButton[i].gameObject.SetActive(false);
                        getText[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        MineralTouchButton[i].gameObject.SetActive(true);
                        getText[i].gameObject.SetActive(true);
                    }
                }
                break;
            case Mineral.Diamond:
                mineral = Mineral.Stone;
                for(int i = 0; i < mineralTouch.Length; i++)
                {
                    mineralTouch[i].gameObject.SetActive(false);
                    if (!(i == 0))
                    {
                        MineralTouchButton[i].gameObject.SetActive(false);
                        getText[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        MineralTouchButton[i].gameObject.SetActive(true);
                        getText[i].gameObject.SetActive(true);
                    }
                }
                break;
        }
    }

    public void Hire_Stone()
    {
        if (resources.resources[0] >= 10000 && Max_Hire > resources.Hire[1])
        {
            resources.Hire[1]++;
            resources.resources[0] -= 10000;
            resources.setHire();
            resources.setResources();
        }
    }
    public void Hire_Iron()
    {
        if (resources.resources[0] >= 25000 && Max_Hire > resources.Hire[2])
        {
            resources.Hire[2]++;
            resources.resources[0] -= 25000;
            resources.setHire();
            resources.setResources();
        }
    }
    public void Hire_Gold()
    {
        if (resources.resources[0] >= 40000 && Max_Hire > resources.Hire[3])
        {
            resources.Hire[3]++;
            resources.resources[0] -= 40000;
            resources.setHire();
            resources.setResources();
        }
    }
    public void Hire_Diamond()
    {
        if (resources.resources[0] >= 100000 && Max_Hire > resources.Hire[4])
        {
            resources.Hire[4]++;
            resources.resources[0] -= 100000;
            resources.setHire();
            resources.setResources();
        }
    }
}
