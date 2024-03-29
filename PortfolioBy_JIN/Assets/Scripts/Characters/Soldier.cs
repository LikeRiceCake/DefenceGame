using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    #region //constant//
    public const float EyeSight = 35f;

    public static readonly float[] SoldierIncreaseHp = { 1f, 1.1f, 2f, 1.3f, 0.5f, 1.7f };
    public static readonly float[] SoldierIncreaseAttack = { 1f, 1.1f, 0.5f, 1.3f, 2f, 1.7f };
    public static readonly float[] SoldierIncreaseDefence = { 0.1f, 0.2f, 0.7f, 0.4f, 0.1f, 0.5f };
    #endregion

    #region //class//
    ButtonManager buttonManager;

    Collider2D opponent;

    LayerMask layerMask;
    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        buttonManager = ButtonManager.instance;
    }

    private void Start()
    {
        DataInit();
    }

    void Update()
    {
        InBattle();

        Upgraded();
    }
    #endregion

    #region //function//
    public override void DataInit()
    {
        layerMask = LayerMask.NameToLayer("Enemy");
        base.DataInit();
    }

    public void InBattle()
    {
        if(GameManager.instance.currentBattleState == GameManager._EBattleState_.egBattle)
        {
            FindOpponent();
            Move();
        }
    }

    public void Upgraded()
    {
        if (GameManager.instance.currentBattleState == GameManager._EBattleState_.egNotBattle && buttonManager.isSoldierUpgraded)
        {
            buttonManager.isSoldierUpgraded = false;
            StatInit();
        }
    }

    public void FindOpponent() // 상대 찾기
    {
        if(opponent == null)
        {
            opponent = Physics2D.OverlapCircle(transform.position, EyeSight, 1 << layerMask);
            if (opponent != null)
            {
                SetCharacterState(_ECharacterState_.ecsMove);
                SetAnimation("isMove");
            }
        }
    }

    public void OpponentRemove() // 상대 초기화 (Die애니메이션에서 사용)
    {
        opponent = null;
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
                return (int)(DataManager.instance.myUserInfo.m_nSoldierUpgrade[(int)characterStat.myClass] * SoldierIncreaseHp[(int)characterStat.myClass]);
            case _ECharacterStat_.ecsAttack:
                return (int)(DataManager.instance.myUserInfo.m_nSoldierUpgrade[(int)characterStat.myClass] * SoldierIncreaseAttack[(int)characterStat.myClass]);
            case _ECharacterStat_.ecsDefence:
                return (int)(DataManager.instance.myUserInfo.m_nSoldierUpgrade[(int)characterStat.myClass] * SoldierIncreaseDefence[(int)characterStat.myClass]);
            default:
                return 0;
        }
    }
    #endregion

    #region //collision//
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsMove && collision.transform.CompareTag("Enemy") && opponent.transform.name == collision.transform.name)
        {
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("isAttack", true);
            target = collision.GetComponent<Enemy>();
        }
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if(myCurrentCharacterState == _ECharacterState_.ecsMove && collision.transform.CompareTag("Enemy") && opponent.transform.name == collision.transform.name)
        {
            print("뎀");
            SetCharacterState(_ECharacterState_.ecsFight);
            SetAnimation("isAttack", true);
            target = collision.GetComponent<Enemy>();
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (myCurrentCharacterState == _ECharacterState_.ecsFight && collision.transform.CompareTag("Enemy"))
        {
            SetCharacterState(_ECharacterState_.ecsIdle);
            SetAnimation("isIdle");
            SetAnimation("isAttack", false);
            TargetRemove();
            OpponentRemove();
        }
    }
    #endregion
}
