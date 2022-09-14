using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSoldier : MonoBehaviour
{
    public int Damage;
    public int Hp;
    public float Speed;

    // Start is called before the first frame update
    void Awake()
    {
        Damage = 2;
        Hp = 6;
        Speed = 2f;
    }
}
