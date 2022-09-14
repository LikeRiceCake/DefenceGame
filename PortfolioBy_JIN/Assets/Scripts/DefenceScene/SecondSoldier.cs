using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSoldier : MonoBehaviour
{
    public int Damage;
    public int Hp;
    public float Speed;

    // Start is called before the first frame update
    void Awake()
    {
        Damage = 3;
        Hp = 8;
        Speed = 2f;
    }
}
