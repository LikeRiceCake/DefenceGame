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

    public void StatInit() // 캐릭터의 스탯 입력
    {
        stat.MaxHp = characterStat.MaxHp + UpgradeStat(_ECharacterStat_.ecsHp);
        stat.CurrentHp = stat.MaxHp;
        stat.Attack = characterStat.Attack + UpgradeStat(_ECharacterStat_.ecsAttack);
        stat.Defence = characterStat.Defence + UpgradeStat(_ECharacterStat_.ecsDefence);
        stat.Speed = characterStat.Speed;
    }

    public abstract void Move(); // 움직임을 담당하는 함수

    public int Attack(Character _opponent) // 상대가 받을 데미지를 반환
    {
        return stat.Attack - _opponent.stat.Defence;
    }

    public void Attacked(int _damage) // 데미지 만큼 내 Hp 감소 (Attack애니메이션에서 사용)
    {
        stat.CurrentHp -= _damage;
        if(stat.CurrentHp <= 0)
        {
            SetCharacterState(_ECharacterState_.ecsDie);
            SetAnimation("DIe");
        }
    }

    public void SetCharacterState(_ECharacterState_ newCharacterState) // 캐릭터 상태 갱신
    {
        myCurrentCharacterState = newCharacterState;
    }

    public void SetAnimation(string _animation) // 애니메이션 변경
    {
        animator.SetTrigger(_animation);
    }

    public void ObjectOnOff(bool value) // 오브젝트 비활성, 활성화 (Die애니메이션에서 사용)
    {
        gameObject.SetActive(value);
    }

    public void OpponentRemove() // 상대 초기화 (Die애니메이션에서 사용)
    {
        opponent = null;
    }

    public abstract int UpgradeStat(_ECharacterStat_ select); // 병사, 적이 강화된 게 있으면 적용
    //-------------------------------------------- private

    #endregion

    #region //collision//
    public abstract void OnCollisionEnter2D(Collision2D collision); // 상대를 만났을 때

    public abstract void OnCollisionExit2D(Collision2D collision); // 상대를 떠났을 때
    #endregion
}