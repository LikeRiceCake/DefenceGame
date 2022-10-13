using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrow : MonoBehaviour, IAttack
{
    #region //struct//
    struct _stat
    {
        public int Attack;
        public float Speed;
    }
    _stat stat;
    #endregion

    #region //class//
    IAttacked _target;
    #endregion

    #region //property//
    public IAttacked target { set { _target = value; } }

    public int sAttack { set { stat.Attack = value; } }

    public float sSpeed { set { stat.Speed = value; } }
    #endregion

    #region //unityLifeCycle//
    void Update()
    {
        TrackDownEnemy();
    }
    #endregion

    #region //function//
    public void Attack()
    {
        _target.Attacked(stat.Attack);
    }

    public void TrackDownEnemy()
    {
        Vector2 dir = _target.GetOpponent().transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Translate(Vector2.right * stat.Speed * Time.deltaTime);
    }
    #endregion

    #region //collision//
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Enemy") && collision.transform.name == _target.GetOpponent().transform.name)
        {
            Attack();
            Destroy(gameObject);
        }
    }
    #endregion
}
