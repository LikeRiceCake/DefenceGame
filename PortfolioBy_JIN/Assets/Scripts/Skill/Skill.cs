using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    #region //enumeration//
    public enum _ESkillClass_
    {
        escMeteor,
        escMax
    }
    #endregion

    #region //constant//
    public const float DestroyTime = 3.5f;
    public const float XStartPos = -12f;
    public const float XEndPos = 4f;
    public const float YPos = 6f;
    public const float SkillDelay = 30f;
    #endregion

    #region //struct//
    public struct _stat
    {
        public int NumberOfObject;
        public float Speed;
        public float RateOfFire;
    }
    _stat stat;
    #endregion

    #region //class//
    //-------------------------------------------- public
    
    //-------------------------------------------- protected
    protected SkillInfo skillStat;
    //-------------------------------------------- private
    #endregion

    #region //unityLifeCycle//
    void Start()
    {
        DataInit();
        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        Move();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        skillStat = GetComponent<SkillInfoPocket>().skillStat;

        StatInit();
    }

    public void StatInit()
    {
        stat.NumberOfObject = skillStat.NumberOfObject;
        stat.Speed = skillStat.Speed;
        stat.RateOfFire = skillStat.RateOfFire;
    }

    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * stat.Speed);
    }
    //-------------------------------------------- private

    #endregion

    #region //collision//
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Attacked(9999);
            Destroy(gameObject);
        }
    }
    #endregion
}
