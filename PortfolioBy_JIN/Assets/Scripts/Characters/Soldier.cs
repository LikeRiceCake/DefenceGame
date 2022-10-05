using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    #region //constant//
    //-------------------------------------------- public
    public const int EnemyLayerMask = 6;

    public const float EyeSight = 4f;
    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    LayerMask layerMask;

    ButtonManager buttonManager;
    #endregion

    #region //unityLifeCycle//
    void Start()
    {
        buttonManager = ButtonManager.instance;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        FindOpponent();

        if (buttonManager.isSoldierUpgraded)
        {
            buttonManager.isSoldierUpgraded = false;
            StatInit();
        }
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public override void DataInit()
    {
        layerMask = EnemyLayerMask;
        base.DataInit();
    }

    public void FindOpponent() // 상대 찾기
    {
        if(opponent == null)
        {
            opponent = Physics2D.OverlapCircle(transform.position, EyeSight, layerMask);
            if (opponent != null)
            {
                SetCharacterState(_ECharacterState_.ecsMove);
                SetAnimation("Move");
            }
        }
    }

    public override void Move()
    {
        if(myCurrentCharacterState == _ECharacterState_.ecsMove)
        {
            Vector2 dir = opponent.gameObject.transform.position - transform.position;

            transform.Translate(dir.normalized * stat.Speed * Time.deltaTime);
        }
    }

    public override int UpgradeStat(_ECharacterStat_ select)
    {
        switch (select)
        {
            case _ECharacterStat_.ecsHp:
                return (int)(dataManager.myUserInfo.m_nSoldierUpgrade[(int)characterStat.myClass] * SoldierIncreaseHp[(int)characterStat.myClass]);
            case _ECharacterStat_.ecsAttack:
                return (int)(dataManager.myUserInfo.m_nSoldierUpgrade[(int)characterStat.myClass] * SoldierIncreaseAttack[(int)characterStat.myClass]);
            case _ECharacterStat_.ecsDefence:
                return (int)(dataManager.myUserInfo.m_nSoldierUpgrade[(int)characterStat.myClass] * SoldierIncreaseDefence[(int)characterStat.myClass]);
            default:
                return 0;
        }
    }
    //-------------------------------------------- private

    #endregion

    #region //collision//
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsMove && collision.collider.CompareTag("Enemy"))
        {
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("Attack");
            opponent = collision.collider;
        }
    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsFight && collision.collider.CompareTag("Enemy"))
        {
            SetCharacterState(_ECharacterState_.ecsIdle);
            SetAnimation("Idle");
            OpponentRemove();
        }
    }
    #endregion
}
