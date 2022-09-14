using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetWood : MonoBehaviour
{
    public portPlayerPrefs data;
    public Text choppingText;
    public TimeManager tm;

    float helptime;

    private void Start()
    {
        choppingText.text = "인력이 없습니다";
        StartCoroutine(subTime());
    }

    private void Update()
    {
        if (data.Hire[0] >= 1)
        {
            data.rTime[0] -= Time.deltaTime;
            data.SetResources_Time();
            choppingText.text = "남은 시간 : " + (int)(data.rTime[0] / 60) + "분";
            if (data.rTime[0] <= 360f)
            {
                choppingText.text = "남은 시간 : " + (int)(data.rTime[0]) + "초";
            }
            if (data.rTime[0] <= 0f)
            {
                data.resources[1] += data.Hire[0];
                data.rTime[0] = 3600f;
                data.setResources();
            }
        }
        if (data.Hire[0] <= 0)
        {
            data.rTime[0] = 3600f;
            data.SetResources_Time();
        }
    }

    IEnumerator subTime()
    {
        data.Quit_Time = DateTime.Now.ToString();
        data.SetQuit_Time();
        yield return new WaitForSeconds(0.01f);
        if (tm.subTime.TotalSeconds > 0)
        {
            if (tm.subTime.TotalSeconds <= data.rTime[0])
            {
                data.rTime[0] -= (float)tm.subTime.TotalSeconds;
            }
            else if (tm.subTime.TotalSeconds > data.rTime[0])
            {
                helptime = (float)tm.subTime.TotalSeconds;
                StartCoroutine(Loop());
            }
        }
    }

    IEnumerator Loop()
    {
        if (helptime > data.rTime[0])
        {
            helptime -= data.rTime[0];
            data.rTime[0] -= data.rTime[0];
            yield return new WaitForSeconds(0.01f);
            if (helptime > data.rTime[0])
            {
                StartCoroutine(Loop());
            }
            else if (helptime <= data.rTime[0])
            {
                data.rTime[0] -= helptime;
            }
        }
    }
}
