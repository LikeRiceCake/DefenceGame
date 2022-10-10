using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill's Info", menuName = "Scriptable Object/Skill's Info")]
public class SkillInfo : ScriptableObject
{
    public int NumberOfObject;
    public float Speed;
    public float RateOfFire;
    public Skill._ESkillClass_ myClass;
}
