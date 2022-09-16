using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour // 제네릭 타입을 이용하여 상속받을 때 타입만 지정하면 자동으로 싱글톤 제작
{
    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    static T _instance = null;
    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //property//
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    _instance = obj.GetComponent<T>();
                }
            }

            return _instance;
        }
    }
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        if (transform.parent != null && transform.root != null)
            DontDestroyOnLoad(this.transform.root.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
            
    }
    #endregion

    #region //function//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion
}
