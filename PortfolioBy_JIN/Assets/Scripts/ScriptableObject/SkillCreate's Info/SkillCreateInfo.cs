using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillCreate's Info", menuName = "Scriptable Object/SkillCreate's Info")]
public class SkillCreateInfo : ScriptableObject
{
    public int NumberOfObject;
    public int RateOfFire;
    public SkillManager._ESkillClass_ myClass;
}
