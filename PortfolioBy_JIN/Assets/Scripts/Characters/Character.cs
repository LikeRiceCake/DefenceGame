using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    #region //enumeration//
    public enum _ECharacterClass_
    {
        eccNormal,
        eccRare,
        eccTank,
        eccUniversal,
        eccAssassin,
        eccUnknown,
        eccEnemy,
        eccMax
    }

    public enum _ECharacterStat_
    {
        ecsHp,
        ecsAttack,
        ecsDefence,
        ecsMax
    }

    public enum _ECharacterState_
    {
        ecsIdle,
        ecsMove,
        ecsFight,
        ecsDie,
        ecsMax
    } protected _ECharacterState_ myCurrentCharacterState;
    #endregion

    #region //constant//
    public readonly float[] SoldierIncreaseHp =      { 1f,   1.1f, 2f,   1.3f, 0.5f, 1.7f};
    public readonly float[] SoldierIncreaseAttack =  { 1f,   1.1f, 0.5f, 1.3f, 2f,   1.7f};
    public readonly float[] SoldierIncreaseDefence = { 0.1f, 0.2f, 0.7f, 0.4f, 0.1f, 0.5f};
    #endregion

    #region //struct//
    protected struct _stat
    {
        public int MaxHp;
        public int CurrentHp;
        public int Attack;
        public int Defence;
        public float Speed;
    }
    protected _stat stat;
    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- protected
    protected Collider2D opponent;

    protected CharacterInfo characterStat;

    protected Animator animator;

    protected DataManager dataManager;
    //-------------------------------------------- private
    #endregion

    #region //unityLifeCycle//
    void Awake()
    {
        DataInit();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public virtual void DataInit()
    {
        dataManager = DataManager.instance;

        characterStat = GetComponent<CharacterInfo>();

        animator = GetComponent<Animator>();

        StatInit();

        SetCharacterState(_ECharacterState_.ecsIdle);
    }

    public void StatInit() // ĳ������ ���� �Է�
    {
        stat.MaxHp = characterStat.MaxHp + UpgradeStat(_ECharacterStat_.ecsHp);
        stat.CurrentHp = stat.MaxHp;
        stat.Attack = characterStat.Attack + UpgradeStat(_ECharacterStat_.ecsAttack);
        stat.Defence = characterStat.Defence + UpgradeStat(_ECharacterStat_.ecsDefence);
        stat.Speed = characterStat.Speed;
    }

    public abstract void Move(); // �������� ����ϴ� �Լ�

    public int Attack(Character _opponent) // ��밡 ���� �������� ��ȯ
    {
        return stat.Attack - _opponent.stat.Defence;
    }

    public void Attacked(int _damage) // ������ ��ŭ �� Hp ���� (Attack�ִϸ��̼ǿ��� ���)
    {
        stat.CurrentHp -= _damage;
        if(stat.CurrentHp <= 0)
        {
            SetCharacterState(_ECharacterState_.ecsDie);
            SetAnimation("DIe");
        }
    }

    public void SetCharacterState(_ECharacterState_ newCharacterState) // ĳ���� ���� ����
    {
        myCurrentCharacterState = newCharacterState;
    }

    public void SetAnimation(string _animation) // �ִϸ��̼� ����
    {
        animator.SetTrigger(_animation);
    }

    public void ObjectOnOff(bool value) // ������Ʈ ��Ȱ��, Ȱ��ȭ (Die�ִϸ��̼ǿ��� ���)
    {
        gameObject.SetActive(value);
    }

    public void OpponentRemove() // ��� �ʱ�ȭ (Die�ִϸ��̼ǿ��� ���)
    {
        opponent = null;
    }

    public abstract int UpgradeStat(_ECharacterStat_ select); // ����, ���� ��ȭ�� �� ������ ����
    //-------------------------------------------- private

    #endregion

    #region //collision//
    public abstract void OnCollisionEnter2D(Collision2D collision); // ��븦 ������ ��

    public abstract void OnCollisionExit2D(Collision2D collision); // ��븦 ������ ��
    #endregion
}