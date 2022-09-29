//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using System;


//public class GetStone : MonoBehaviour
//{
//    public portPlayerPrefs data;
//    public Text miningText;
//    public TimeManager tm;

//    float helptime;

//    private void Start()
//    {
//        miningText.text = "인력이 없습니다";
//        StartCoroutine(subTime());
//    }

//    private void Update()
//    {
//        if (data.Hire[1] >= 1)
//        {
//            data.rTime[1] -= Time.deltaTime;
//            data.SetResources_Time();
//            miningText.text = "남은 시간 : " + (int)(data.rTime[1] / 60) + "분";
//            if (data.rTime[1] <= 360f)
//            {
//                miningText.text = "남은 시간 : " + (int)(data.rTime[1]) + "초";
//            }
//            if (data.rTime[1] <= 0f)
//            {
//                data.resources[2] += data.Hire[1];
//                data.rTime[1] = 3600f;
//                data.setResources();
//            }
//        }
//        if (data.Hire[1] <= 0)
//        {
//            data.rTime[1] = 3600f;
//            data.SetResources_Time();
//        }
//    }

//    IEnumerator subTime()
//    {
//        data.Quit_Time = DateTime.Now.ToString();
//        data.SetQuit_Time();
//        yield return new WaitForSeconds(0.01f);
//        if (tm.subTime.TotalSeconds > 0)
//        {
//            if (tm.subTime.TotalSeconds <= data.rTime[1])
//            {
//                data.rTime[1] -= (float)tm.subTime.TotalSeconds;
//            }
//            else if (tm.subTime.TotalSeconds > data.rTime[1])
//            {
//                helptime = (float)tm.subTime.TotalSeconds;
//                StartCoroutine(Loop());
//            }
//        }
//    }

//    IEnumerator Loop()
//    {
//        if (helptime > data.rTime[1])
//        {
//            helptime -= data.rTime[1];
//            data.rTime[1] -= data.rTime[1];
//            yield return new WaitForSeconds(0.01f);
//            if (helptime > data.rTime[1])
//            {
//                StartCoroutine(Loop());
//            }
//            else if (helptime <= data.rTime[1])
//            {
//                data.rTime[1] -= helptime;
//            }
//        }
//    }
//}
