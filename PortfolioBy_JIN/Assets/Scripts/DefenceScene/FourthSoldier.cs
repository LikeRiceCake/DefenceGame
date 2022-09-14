using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthSoldier : MonoBehaviour
{
    public int Damage;
    public int Hp;
    public float Speed;

    // Start is called before the first frame update
    void Awake()
    {
        Damage = 8;
        Hp = 12;
        Speed = 1f;
    }
}
