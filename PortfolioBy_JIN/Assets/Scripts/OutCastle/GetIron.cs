using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GetIron : MonoBehaviour
{
    public portPlayerPrefs data;
    public Text miningText;
    public TimeManager tm;

    float helptime;

    private void Start()
    {
        miningText.text = "인력이 없습니다";
        StartCoroutine(subTime());
    }

    private void Update()
    {
        if (data.Hire[2] >= 1)
        {
            data.rTime[2] -= Time.deltaTime;
            data.SetResources_Time();
            miningText.text = "남은 시간 : " + (int)(data.rTime[2] / 60) + "분";
            if (data.rTime[2] <= 360f)
            {
                miningText.text = "남은 시간 : " + (int)(data.rTime[2]) + "초";
            }
            if (data.rTime[2] <= 0f)
            {
                data.resources[3] += data.Hire[2];
                data.rTime[2] = 3600f;
                data.setResources();
            }
        }
        if (data.Hire[2] <= 0)
        {
            data.rTime[2] = 3600f;
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
            if (tm.subTime.TotalSeconds <= data.rTime[2])
            {
                data.rTime[2] -= (float)tm.subTime.TotalSeconds;
            }
            else if (tm.subTime.TotalSeconds > data.rTime[2])
            {
                helptime = (float)tm.subTime.TotalSeconds;
                StartCoroutine(Loop());
            }
        }
    }

    IEnumerator Loop()
    {
        if (helptime > data.rTime[2])
        {
            helptime -= data.rTime[2];
            data.rTime[2] -= data.rTime[2];
            yield return new WaitForSeconds(0.01f);
            if (helptime > data.rTime[2])
            {
                StartCoroutine(Loop());
            }
            else if (helptime <= data.rTime[2])
            {
                data.rTime[2] -= helptime;
            }
        }
    }
}
