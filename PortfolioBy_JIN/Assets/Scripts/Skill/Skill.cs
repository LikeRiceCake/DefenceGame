using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    #region //variable//
    float speed;
    #endregion

    #region //constant//
    public const float DeActivateTime = 3.5f;
    public const float XStartPos = -12f;
    public const float XEndPos = 4f;
    public const float YPos = 6f;
    public const float SkillDelay = 30f;
    #endregion

    #region //class//
    protected SkillInfo skillStat;
    #endregion

    #region //unityLifeCycle//
    void Start()
    {
        DataInit();
        Invoke("TimeOut", DeActivateTime);
    }

    private void OnDisable()
    {
        transform.position = new Vector2(Random.Range(XStartPos, XEndPos), YPos);
    }

    void Update()
    {
        Move();
    }
    #endregion

    #region //function//
    public void DataInit()
    {
        skillStat = GetComponent<SkillInfoPocket>().skillStat;

        StatInit();
    }

    public void StatInit()
    {
        speed = skillStat.Speed;
    }

    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    public void TimeOut()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region //collision//
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().Attacked(9999);
            gameObject.SetActive(false);
        }
    }
    #endregion
}
