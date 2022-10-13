using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    #region //constant//
    public const int EnemyIncreaseHp = 6;
    public const int EnemyIncreaseAttack = 5;
    public const int EnemyIncreaseDefence = 12;
    #endregion

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
    #endregion

    #region //function//
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
                return dataManager.myUserInfo.m_nWave / EnemyIncreaseHp;
            case _ECharacterStat_.ecsAttack:
                return dataManager.myUserInfo.m_nWave / EnemyIncreaseAttack;
            case _ECharacterStat_.ecsDefence:
                return dataManager.myUserInfo.m_nWave / EnemyIncreaseDefence;
            default:
                return 0;
        }
    }

    public override void Die()
    {
        _enemyManager.CurrentEnemyDecrease();
        dataManager.myUserInfo.m_nResource[(int)DataManager._EResource_.erMoney] += (int)(dataManager.myUserInfo.m_nWave * 150 * 1.5f);
        UIManager.instance.SetTextResourceUI(DataManager._EResource_.erMoney);
        base.Die();
    }
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
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("isC_Attack");
            target = collision.GetComponent<Castle>();
        }
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsMove && collision.transform.CompareTag("Soldier") && target == null)
        {
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("isAttack");
            target = collision.GetComponent<Soldier>();
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsFight && collision.transform.CompareTag("Soldier"))
        {
            SetCharacterState(_ECharacterState_.ecsMove);
            SetAnimation("isMove");
            TargetRemove();
        }
    }
    #endregion
}
