using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaArrow : MonoBehaviour
{
    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    int _Attack;
    float _Speed;
    #endregion

    #region //constant//
    //-------------------------------------------- public

    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    Collider2D _opponent;
    #endregion

    #region //property//
    public Collider2D opponent { set { _opponent = value; } }
    public int Attack { set { _Attack = value; } }
    public float Speed { set { _Speed = value; } }
    #endregion

    #region //unityLifeCycle//

    void Update()
    {
        TrackDownEnemy();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public int AttackEnemy(Enemy _opponent)
    {
        return _Attack - _opponent.GetStat(Character._ECharacterStat_.ecsDefence);
    }

    public void TrackDownEnemy()
    {
        Vector2 dir = _opponent.gameObject.transform.position - transform.position;

        transform.Translate(dir.normalized * _Speed * Time.deltaTime);
    }
    //-------------------------------------------- private

    #endregion

    #region //collision//
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<Enemy>().Attacked(AttackEnemy(collision.collider.GetComponent<Enemy>()));
            Destroy(gameObject);
        }
    }
    #endregion
}
