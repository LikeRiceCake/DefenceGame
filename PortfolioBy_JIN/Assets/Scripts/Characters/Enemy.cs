using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    #region //unityLifeCycle//
    void FixedUpdate()
    {
        Move();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public override void Move()
    {
        if(myCurrentCharacterState == _ECharacterState_.ecsMove)
            transform.Translate(Vector3.left * stat.Speed * Time.deltaTime);
    }

    public override int UpgradeStat(_ECharacterStat_ select)
    {
        switch (select)
        {
            case _ECharacterStat_.ecsHp:
                return (int)(dataManager.myUserInfo.m_nWave / 5 * 1.2f);
            case _ECharacterStat_.ecsAttack:
                return dataManager.myUserInfo.m_nWave / 5;
            case _ECharacterStat_.ecsDefence:
                return dataManager.myUserInfo.m_nWave / 15;
            default:
                return 0;
        }
    }
    //-------------------------------------------- private

    #endregion

    #region //collision//
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsMove && collision.collider.CompareTag("Soldier"))
        {
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("Attack");
            opponent = collision.collider;
        }
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsFight && collision.collider.CompareTag("Soldier"))
        {
            SetCharacterState(_ECharacterState_.ecsIdle);
            SetAnimation("Idle");
            OpponentRemove();
        }
    }
    #endregion
}
