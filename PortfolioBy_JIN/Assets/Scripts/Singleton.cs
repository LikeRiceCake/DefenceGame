using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour // ���׸� Ÿ���� �̿��Ͽ� ��ӹ��� �� Ÿ�Ը� �����ϸ� �ڵ����� �̱��� ����
{
    #region //variable//
    static T _instance = null;
    #endregion

    #region //property//
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                DataInit();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }
    }
    #endregion

    #region //unityLifeCycle//
    protected virtual void Awake()
    {
        DataInit();

        if (transform.parent != null && transform.root != null)
            DontDestroyOnLoad(this.transform.root.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    #region //function//
    private static void DataInit()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                _instance = GameObject.Find("Managers").transform.Find(typeof(T).Name).GetComponent<T>();
            }
        }
    }
    #endregion
}
