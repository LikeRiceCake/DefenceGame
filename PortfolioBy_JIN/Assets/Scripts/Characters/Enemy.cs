using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    #region //class//
    EnemyManager _enemyManager;
    #endregion

    #region //property//
    public EnemyManager enemyManager { set { _enemyManager = value; } }
    #endregion

    #region //unityLifeCycle//
    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if(myCurrentCharacterState == _ECharacterState_.ecsIdle)
        {
            SetCharacterState(_ECharacterState_.ecsMove);
            SetAnimation("isMove");
        }
    }

    void OnDisable()
    {
        _enemyManager.CurrentEnemyDecrease();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public override void Move()
    {
        if(myCurrentCharacterState == _ECharacterState_.ecsMove)
        {
            transform.Translate(Vector2.left * stat.Speed * Time.deltaTime);
        }
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
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsMove && collision.transform.CompareTag("Soldier"))
        {
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("isAttack");
            target = collision.GetComponent<Soldier>();
        }
        else if (myCurrentCharacterState == _ECharacterState_.ecsMove && collision.transform.CompareTag("Castle"))
        {
            print("º¯°æ");
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("isC_Attack");
            target = collision.GetComponent<Castle>();
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsFight && collision.transform.CompareTag("Soldier"))
        {
            SetCharacterState(_ECharacterState_.ecsIdle);
            SetAnimation("isIdle");
            TargetRemove();
        }
    }
    #endregion
}
