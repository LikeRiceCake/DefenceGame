using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character의 Stat을 편하게 설정하기 위한 ScriptableObject

[CreateAssetMenu(fileName = "Character's Info", menuName = "Scriptable Object/Character's Info")]
public class CharacterInfo : ScriptableObject
{
    public int MaxHp;
    public int Attack;
    public int Defence;
    public float Speed;
    public Character._ECharacterClass_ myClass;
}
