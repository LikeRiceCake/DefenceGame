using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon's Info", menuName = "Scriptable Object/Weapon's Info")]
public class WeaponInfo : ScriptableObject
{
    public int Attack;
    public float Speed;
    public float RateOfFire;
    public Weapon._EWeaponClass_ myClass;
}
