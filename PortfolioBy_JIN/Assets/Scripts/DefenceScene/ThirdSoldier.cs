using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSoldier : MonoBehaviour
{
    public int Damage;
    public int Hp;
    public float Speed;

    // Start is called before the first frame update
    void Awake()
    {
        Damage = 3;
        Hp = 20;
        Speed = 1.5f;
    }
}
