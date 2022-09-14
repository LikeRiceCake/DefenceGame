using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GetDiamond : MonoBehaviour
{
    public portPlayerPrefs data;
    public Text miningText;
    public TimeManager tm;

    float helptime;

    private void Start()
    {
        miningText.text = "�η��� �����ϴ�";
        StartCoroutine(subTime());
    }

    private void Update()
    {
        if (data.Hire[4] >= 1)
        {
            data.rTime[4] -= Time.deltaTime;
            data.SetResources_Time();
            miningText.text = "���� �ð� : " + (int)(data.rTime[4] / 60) + "��";
            if (data.rTime[4] <= 360f)
            {
                miningText.text = "���� �ð� : " + (int)(data.rTime[4]) + "��";
            }
            if (data.rTime[4] <= 0f)
            {
                data.resources[5] += data.Hire[4];
                data.rTime[4] = 3600f;
                data.setResources();
            }
        }
        if (data.Hire[4] <= 0)
        {
            data.rTime[4] = 3600f;
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
            if (tm.subTime.TotalSeconds <= data.rTime[4])
            {
                data.rTime[4] -= (float)tm.subTime.TotalSeconds;
            }
            else if (tm.subTime.TotalSeconds > data.rTime[4])
            {
                helptime = (float)tm.subTime.TotalSeconds;
                StartCoroutine(Loop());
            }
        }
    }

    IEnumerator Loop()
    {
        if (helptime > data.rTime[4])
        {
            helptime -= data.rTime[4];
            data.rTime[4] -= data.rTime[4];
            yield return new WaitForSeconds(0.01f);
            if (helptime > data.rTime[4])
            {
                StartCoroutine(Loop());
            }
            else if (helptime <= data.rTime[4])
            {
                data.rTime[4] -= helptime;
            }
        }
    }
}
