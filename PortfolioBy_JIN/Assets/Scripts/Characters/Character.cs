using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IAttack, IAttacked
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
    protected CharacterInfo characterStat;

    protected DataManager dataManager;

    protected Animator animator;

    protected IAttacked target;
    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        dataManager = DataManager.instance;
    }

    private void Start()
    {
        DataInit();
    }
    #endregion

    #region //function//
    public virtual void DataInit()
    {
        characterStat = GetComponent<CharacterInfoPocket>().characterStat;

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
    
    public void Attack() // ��븦 ����
    {
        if(target != null)
        {
            SoundManager.instance.SetAudioSFX("Audios/SFX/Sword");
            SoundManager.instance.PlayAudioSFX();
            target.Attacked(stat.Attack);
        }
    }

    public void Attacked(int _damage) // ������ ��ŭ �� Hp ���� (Attack�ִϸ��̼ǿ��� ���)
    {
        _damage = _damage <= stat.Defence ? 0 : _damage - stat.Defence;
        stat.CurrentHp -= _damage;
        if(stat.CurrentHp <= 0 && myCurrentCharacterState != _ECharacterState_.ecsDie)
        {
            SetCharacterState(_ECharacterState_.ecsDie);
            SetAnimation("isDie");
        }
    }

    public Collider2D GetOpponent()
    {
        return GetComponent<Collider2D>();
    }
    
    public void SetCharacterState(_ECharacterState_ newCharacterState) // ĳ���� ���� ����
    {
        myCurrentCharacterState = newCharacterState;
    }

    public void SetAnimation(string _animation) // �ִϸ��̼� ����
    {
        animator.SetTrigger(_animation);
    }

    public void SetAnimation(string _animation, bool _state) // �ִϸ��̼� ����
    {
        animator.SetBool(_animation, _state);
    }

    public void ObjectOnOff(bool value) // ������Ʈ ��Ȱ��, Ȱ��ȭ (Die�ִϸ��̼ǿ��� ���)
    {
        gameObject.SetActive(value);
    } 

    public void TargetRemove() // ��� �ʱ�ȭ (Die�ִϸ��̼ǿ��� ���)
    {
        target = null;
    }

    public int GetStat(_ECharacterStat_ select) // ���� ��ȯ
    {
        switch (select)
        {
            case _ECharacterStat_.ecsHp:
                return stat.CurrentHp;
            case _ECharacterStat_.ecsAttack:
                return stat.Attack;
            case _ECharacterStat_.ecsDefence:
                return stat.Defence;
            default:
                return 0;
        }
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }

    public abstract int UpgradeStat(_ECharacterStat_ select); // ����, ���� ��ȭ�� �� ������ ����
    #endregion

    #region //collision//
    public abstract void OnTriggerEnter2D(Collider2D collision); // ��븦 ������ ��

    public abstract void OnTriggerStay2D(Collider2D collision); // ���� �ο� ��, �ٸ� ���� ������ ��츦 ���

    public abstract void OnTriggerExit2D(Collider2D collision); // ��븦 ������ ��
    #endregion
}